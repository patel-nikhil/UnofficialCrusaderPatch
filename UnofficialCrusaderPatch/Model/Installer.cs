using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using UCP.Mods;
using static UCP.InstallHelper;
using static UCP.Writer;

namespace UCP
{
    public class Installer
    {
        static string SHC_PATH = "C:/Programs/Steam/steamapps/common/Stronghold Crusader Extreme/Stronghold Crusader.exe";
        static string SHCE_PATH = "C:/Programs/Steam/steamapps/common/Stronghold Crusader Extreme/Stronghold_Crusader_Extreme.exe";

        private static byte[] ReadCrusader()
        {
            return File.ReadAllBytes(SHC_PATH);
        }

        private static byte[] ReadExtreme()
        {
            return File.ReadAllBytes(SHCE_PATH);
        }

        public static void InstallMods(bool isExtreme)
        {
            byte[] data = isExtreme ? ReadExtreme() : ReadCrusader();
            SectionHelper writer = new SectionHelper(data);
            InstallData installData = new InstallData();
            AllocatedBytes allocatedBytes = new AllocatedBytes();
            foreach (var mod in GenericMod.ModList)
            {
                List<IChange> changes = isExtreme ? mod.ExtremeChanges : mod.CrusaderChanges;
                List<Label> labels = isExtreme ? mod.CrusaderLabels : mod.ExtremeLabels;
                InitializeMod(data, changes, labels, installData);
            }
            WriteSections(writer, ref data, installData, out int codeSectionStart, out int codeSectionVirtualStart, out int dataSectionStart, out int dataSectionVirtualStart);

            int codeSectionPosition = codeSectionStart, codeSectionVirtualPosition = codeSectionVirtualStart;
            int dataSectionPosition = dataSectionStart, dataSectionVirtualPosition = dataSectionVirtualStart;

            foreach (var mod in GenericMod.ModList)
            {
                List<IChange> changes = isExtreme ? mod.ExtremeChanges : mod.CrusaderChanges;
                InstallCodeReplacementAndRetrieveAllocations(data, changes, isExtreme, ref codeSectionPosition, ref codeSectionVirtualPosition, ref dataSectionPosition, ref dataSectionVirtualPosition);
            }

            if (allocatedBytes.codeAllocations.Count > 0)
            {
                WriteSectionData(data, codeSectionStart, allocatedBytes.codeAllocations);
            }

            if (allocatedBytes.memoryAllocations.Count > 0)
            {
                WriteSectionData(data, dataSectionStart, allocatedBytes.memoryAllocations);
            }
            File.WriteAllBytes("random.exe", data);
        }


        // Initializes labels that are based on fixed offset from an AOB. Does not initialize InlineLabels
        private static void InitializeMod(byte[] data, List<IChange> changes, List<Label> labels, InstallData installData)
        {
            AddressResolver.InitializeFixedLabelAddresses(labels, data);
            foreach (var change in changes)
            {
                AddressResolver.ResolveBaseAddresses(change, data, installData);
            }
        }

        private static void InstallCodeReplacementAndRetrieveAllocations(byte[] data, List<IChange> changes, bool isExtreme, ref int allocatedCodeSectionPosition, ref int allocatedCodeSectionVirtualPosition, ref int allocatedMemorySectionPosition, ref int allocatedMemorySectionVirtualPosition)
        {
            Dictionary<string, Label> labelDictionary = isExtreme ? Label.ExtremeLabels : Label.CrusaderLabels;

            foreach(var change in changes)
            {
                if (change is CodeReplacement)
                {
                    CodeReplacement codeReplacement = change as CodeReplacement;

                    // Get start address for the CodeReplacement
                    AOB aob = AOB.AOBList[codeReplacement.CodeBlockName];
                    aob.SetAddress(data);

                    int currentPosition = aob.Address.Value;

                    // Choose action based on current element
                    foreach (var element in change.GetByteValue())
                    {
                        if (element.value is Label)
                        {
                            continue; // This is a non-code element
                        }
                        else if (element.value is SkipPosition)
                        {
                            currentPosition += (element.value as SkipPosition).Count;
                        }
                        else
                        {
                            currentPosition += WriteCode(
                                element,
                                labelDictionary, 
                                data,
                                currentPosition,
                                allocatedCodeSectionPosition,
                                allocatedCodeSectionVirtualPosition,
                                allocatedMemorySectionPosition,
                                allocatedMemorySectionVirtualPosition, 0);
                        }
                    }
                }
                else if (change is CodeAllocation)
                {
                    CodeAllocation codeReplacement = change as CodeAllocation;

                    // Choose action based on current element
                    foreach (var element in change.GetByteValue())
                    {
                        if (element.value is Label)
                        {
                            continue; // This is a non-code element
                        }
                        else if (element.value is SkipPosition)
                        {
                            allocatedCodeSectionPosition += (element.value as SkipPosition).Count;
                        }
                        else
                        {
                            allocatedCodeSectionPosition += WriteCode(
                                element,
                                labelDictionary,
                                data,
                                allocatedCodeSectionPosition,
                                allocatedCodeSectionPosition,
                                allocatedCodeSectionVirtualPosition,
                                allocatedMemorySectionPosition,
                                allocatedMemorySectionVirtualPosition, 1);
                        }
                    }
                }
                else if (change is MemoryAllocation)
                {
                    MemoryAllocation codeReplacement = change as MemoryAllocation;

                    // Choose action based on current element
                    foreach (var element in change.GetByteValue())
                    {
                        if (element.value is Label)
                        {
                            continue; // This is a non-code element
                        }
                        else if (element.value is SkipPosition)
                        {
                            allocatedMemorySectionPosition += (element.value as SkipPosition).Count;
                        }
                        else
                        {
                            allocatedMemorySectionPosition += WriteCode(
                                element, 
                                labelDictionary, 
                                data,
                                allocatedMemorySectionPosition,
                                allocatedCodeSectionPosition,
                                allocatedCodeSectionVirtualPosition,
                                allocatedMemorySectionPosition,
                                allocatedMemorySectionVirtualPosition, 2);
                        }
                    }
                }
            }
        }
    }
}
