using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

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
            List<Mod> modList = new List<Mod>();

            Mod testMod = new Mod();
            testMod.IsEnabled = true;
            modList.Add(testMod);

            byte[] data = isExtreme ? ReadExtreme() : ReadCrusader();
            SectionHelper writer = new SectionHelper(data);
            InstallData installData = new InstallData();
            AllocatedBytes allocatedBytes = new AllocatedBytes();
            foreach (var mod in modList)
            {
                InitializeMod(data, mod, installData, allocatedBytes);
            }
            int codeSectionStart, codeSectionVirtualStart, dataSectionStart, dataSectionVirtualStart;
            WriteSections(writer, ref data, installData, out codeSectionStart, out codeSectionVirtualStart, out dataSectionStart, out dataSectionVirtualStart);

            foreach (var mod in modList)
            {
                InstallCodeReplacementAndRetrieveAllocations(data, mod, isExtreme, installData, allocatedBytes, codeSectionStart, codeSectionVirtualStart, dataSectionStart, dataSectionVirtualStart);
            }

            WriteSectionData(data, codeSectionStart, allocatedBytes.codeAllocations);
            WriteSectionData(data, dataSectionStart, allocatedBytes.memoryAllocations);
            /*installData.CodeAllocationCounter = 0x1000;
            installData.MemoryAllocationCounter = 0x1000;*/
            File.WriteAllBytes("random.exe", data);
        }

        private static void InitializeMod(byte[] data, Mod mod, InstallData installData, AllocatedBytes allocatedBytes)
        {
            // Initializes labels that are based on fixed offset from an AOB. Does not initialize InlineLabels
            AddressResolver.InitializeFixedLabelAddresses(mod.Labels, data);
            foreach (var change in mod.Changes)
            {
                AddressResolver.ResolveBaseAddresses(change, data, installData);
            }
        }

        private static void InstallCodeReplacementAndRetrieveAllocations(byte[] data, Mod mod, bool isExtreme, InstallData installData, AllocatedBytes allocatedBytes, int allocatedCodeSectionStart, int allocatedCodeSectionVirtualStart, int allocatedMemorySectionStart, int allocatedMemorySectionVirtualStart)
        {
            Dictionary<string, Label> labelDictionary = isExtreme ? Label.ExtremeLabels : Label.CrusaderLabels;

            foreach(var change in mod.Changes)
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
                        else
                        {
                            currentPosition += WriteCode(element, labelDictionary, data, currentPosition, allocatedCodeSectionStart, allocatedCodeSectionVirtualStart, allocatedMemorySectionStart, allocatedMemorySectionVirtualStart, 0);
                        }
                    }
                }
                else if (change is CodeAllocation)
                {
                    CodeAllocation codeReplacement = change as CodeAllocation;
                    int currentPosition = allocatedCodeSectionStart;

                    // Choose action based on current element
                    foreach (var element in change.GetByteValue())
                    {
                        if (element.value is Label)
                        {
                            continue; // This is a non-code element
                        }
                        else
                        {
                            currentPosition += WriteCode(element, labelDictionary, data, currentPosition, allocatedCodeSectionStart, allocatedCodeSectionVirtualStart, allocatedMemorySectionStart, allocatedMemorySectionVirtualStart, 1);
                        }
                    }
                }
                else if (change is MemoryAllocation)
                {
                    MemoryAllocation codeReplacement = change as MemoryAllocation;
                    int currentPosition = allocatedMemorySectionStart;

                    // Choose action based on current element
                    foreach (var element in change.GetByteValue())
                    {
                        if (element.value is Label)
                        {
                            continue; // This is a non-code element
                        }
                        else
                        {
                            currentPosition += WriteCode(element, labelDictionary, data, currentPosition, allocatedCodeSectionStart, allocatedCodeSectionVirtualStart, allocatedMemorySectionStart, allocatedMemorySectionVirtualStart, 2);
                        }
                    }
                }
            }
        }

/*        private static int InitializeReferenceAndGetNextPosition(Reference referenceElement, Dictionary<string, Label> labelDictionary, byte[] data, int currentPosition)
        {
            if (referenceElement is FixedReference) // A fixed reference is a 32-bit address so add 4 to current position
            {
                (referenceElement as FixedReference).Value = AddressResolver.GetTargetAddress(referenceElement, labelDictionary, data);
                return currentPosition +4;
            }
            else if (referenceElement is RelativeReference) // A relative reference can be a 8-bit or 32-bit address so determine and increment appropriately
            {
                int offset = currentPosition - AddressResolver.GetTargetAddress(referenceElement, labelDictionary, data);
                (referenceElement as RelativeReference).Value = offset;
                return currentPosition + 4;
            }
            else
            {
                throw new Exception();
            }
        }*/
    }
}
