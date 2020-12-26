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
            byte[] data = isExtreme ? extremeData : crusaderData;
            Dictionary<string, Label> labelDictionary = isExtreme ? Label.ExtremeLabels : Label.CrusaderLabels;

            Mod mod = new Mod();
            mod.IsEnabled = true;
            if (mod.IsEnabled)
            {
                // Assign address to each label defined by codeblock offset
                foreach(var label in mod.Labels)
                {
                    string codeBlock = label.CodeBlockName;
                    AOB aob = AOB.AOBList[codeBlock];
                    aob.SetAddress(data);
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
                        aob.SetAddress(data);

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
                            else if (element.value is Reference)
                            {
                                currentPosition = InitializeReferenceAndGetNextPosition(element.value, labelDictionary, currentPosition);
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
                            else
                            {
                                WriteData(element, data);
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

        private static int InitializeReferenceAndGetNextPosition(Reference referenceElement, Dictionary<string, Label> labelDictionary, int currentPosition)
        {
            if (referenceElement is FixedReference) // A fixed reference is a 32-bit address so add 4 to current position
            {
                (referenceElement as FixedReference).Value = GetTargetAddress((referenceElement as Reference), labelDictionary);
                return currentPosition +4;
            }
            else if (referenceElement is RelativeReference) // A relative reference can be a 8-bit or 32-bit address so determine and increment appropriately
            {
                int offset = currentPosition - GetTargetAddress((referenceElement as Reference), labelDictionary);
                (referenceElement as FixedReference).Value = offset;
                if (offset < 0x7F && offset > 0x80)
                {
                    return currentPosition + 1;
                }
                else
                {
                    return currentPosition + 4;
                }
            }
            else
            {
                throw new Exception();
            }
        }

        private static void WriteData(ByteOrAddress element, byte[] data)
        {
            if (element.value is FixedReference) // Write 32-bit value
            {
                var value = (element.value as FixedReference).Value;
                WriteValue(value, data);
            }
            else if (element.value is RelativeReference) // Write 8-bit or 32-bit value as appropriate
            {
                var value = (element.value as RelativeReference).Value;
                WriteRelativeAddress(value, data);
            }
            else
            {
                byte value = (byte)element.value; // Write single byte
                WriteSingleByte(value, data);
            }
        }

        private static int GetTargetAddress(Reference reference, Dictionary<string, Label> labelDictionary)
        {
            string targetLabel = reference.TargetLabelName;
            return labelDictionary[targetLabel].Address;
        }

        private static void WriteSingleByte(byte value, byte[] data)
        {

        }

        private static void WriteValue(int value, byte[] data)
        {

        }

        private static void WriteRelativeAddress(int value, byte[] data)
        {
            if (value < 0x7F && value > 0x80)
            {
                WriteSingleByte((byte)value, data);
            }
            else
            {
                WriteValue(value, data);
            }
        }
    }
}
