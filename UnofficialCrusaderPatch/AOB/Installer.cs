using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace UCP
{
    public class Installer
    {
        static string SHC_PATH = "C:/Programs/Steam/steamapps/common/Stronghold Crusader Extreme/Stronghold Crusader.exe";
        static string SHCE_PATH = "C:/Programs/Steam/steamapps/common/Stronghold Crusader Extreme/Stronghold_Crusader_Extreme.exe";

        static byte[] crusaderData;
        static byte[] extremeData;
        public static void Initialize()
        {
            crusaderData = File.ReadAllBytes(SHC_PATH);
            extremeData = File.ReadAllBytes(SHCE_PATH);
        }

        public static void Install()
        {
            bool isExtreme = true;

            Mod mod = new Mod();
            mod.IsEnabled = true;
            if (mod.IsEnabled)
            {
                // Assign address to each label defined by codeblock offset
                foreach(var label in mod.Labels)
                {
                    string codeBlock = label.CodeBlockName;
                    AOB aob = AOB.AOBList[codeBlock];
                    aob.SetAddress(crusaderData);
                    Console.WriteLine(aob.Address.Value);
                    label.SetAddress(aob.Address.Value);
                }
                
                // Install each change in the Mod
                foreach(var change in mod.Changes)
                {
                    if (change is CodeReplacement)
                    {
                        CodeReplacement codeReplacement = change as CodeReplacement;

                        // Get start address for the CodeReplacement
                        AOB aob = AOB.AOBList[codeReplacement.CodeBlockName];
                        aob.SetAddress(crusaderData);

                        int startPosition = aob.Address.Value;
                        int currentPosition = aob.Address.Value;

                        // Initialize labels declared inside change
                        foreach (var element in change.GetByteValue())
                        {
                            if (!element.IsLabel && !element.IsReference)
                            {
                                currentPosition++;
                            }
                            else if (element.value is InlineLabel) // A label is a non-code marker so do not increment current position
                            {
                                (element.value as InlineLabel).Address = currentPosition;
                            }
                            else if (element.value is FixedReference) // A fixed reference is a 32-bit address so add 4 to current position
                            {
                                (element.value as FixedReference).Value = GetTargetAddress((element.value as Reference), isExtreme);
                                currentPosition += 4;
                            }
                            else if (element.value is RelativeReference) // A relative reference can be a 8-bit or 32-bit address so determine and increment appropriately
                            {
                                int offset = currentPosition - GetTargetAddress((element.value as Reference), isExtreme);
                                (element.value as FixedReference).Value = offset;
                                if (offset < 0x7F && offset > 0x80)
                                {
                                    currentPosition += 1;
                                }
                                else
                                {
                                    currentPosition += 4;
                                }
                            }
                        }

                        currentPosition = startPosition;

                        // Choose action based on current element
                        foreach (var element in change.GetByteValue())
                        {
                            if (element.value is InlineLabel)
                            {
                                continue; // This is a non-code element
                            }
                            else if (element.value is FixedReference)
                            {
                                // write value
                                var value = (element.value as FixedReference).Value;
                            }
                            else if (element.value is RelativeReference)
                            {
                                // write value
                                var value = (element.value as RelativeReference).Value;
                            }
                            else
                            {
                                var value = (byte)element.value;
                            }
                        }
                    }
                    else if (change is CodeAllocation)
                    {

                    }
                    else if (change is MemoryAllocation)
                    {

                    }
                }
            }
        }

        private static int GetTargetAddress(Reference reference, bool isExtreme)
        {
            string targetLabel = reference.TargetLabelName;
            return isExtreme ? Label.ExtremeLabels[targetLabel].Address : Label.CrusaderLabels[targetLabel].Address;
        }
    }
}
