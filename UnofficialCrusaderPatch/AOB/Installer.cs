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

        private static byte[] ReadCrusader()
        {
            return File.ReadAllBytes(SHC_PATH);
        }

        private static byte[] ReadExtreme()
        {
            return File.ReadAllBytes(SHCE_PATH);
        }

        public static void Install(bool isExtreme)
        {
            int codeAllocationCounter = 0;
            int memoryAllocationCounter = 0;

/*            List<byte> codeAllocations = new List<byte>();
            List<byte> memoryAllocations = new List<byte>();*/

            byte[] data = isExtreme ? ReadExtreme() : ReadCrusader();
            Dictionary<string, Label> labelDictionary = isExtreme ? Label.ExtremeLabels : Label.CrusaderLabels;

            Mod mod = new Mod();
            mod.IsEnabled = true;
            if (mod.IsEnabled)
            {
                // Initializes labels that are based on fixed offset from an AOB. Does not initialize InlineLabels
                InitializeFixedLabelAddresses(mod.Labels, data);
                foreach (var change in mod.Changes)
                {
                    ResolveBaseAddresses(change, data, ref codeAllocationCounter, ref memoryAllocationCounter);
                }


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
                                currentPosition = InitializeReferenceAndGetNextPosition(element.value, labelDictionary, data, currentPosition);
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
                }
            }
        }

        // Define base addresses for InlineLabels and References
        private static void ResolveBaseAddresses(IChange change, byte[] data, ref int codeAllocationCounter, ref int memoryAllocationCounter)
        {
            int startPosition;
            if (change is CodeReplacement)
            {
                CodeReplacement codeReplacement = change as CodeReplacement;

                // Get start address for the CodeReplacement
                AOB aob = AOB.AOBList[codeReplacement.CodeBlockName];
                aob.SetAddress(data);
                startPosition = aob.Address.Value;
            }
            else if (change is CodeAllocation)
            {
                startPosition = codeAllocationCounter;
            }
            else if (change is MemoryAllocation)
            {
                startPosition = memoryAllocationCounter;
            }
            else
            {
                throw new Exception();
            }
            
            int currentPosition = startPosition;

            // Initialize labels declared inside change
            foreach (var element in change.GetByteValue())
            {
                if (!element.IsLabel && !element.IsReference)
                {
                    if (element.value is byte)
                    {
                        currentPosition++;
                    }
                    else if (element.value is int)
                    {
                        currentPosition += 4;
                    }
                }
                else if (element.value is InlineLabel) // A label is a non-code marker so do not increment current position
                {
                    (element.value as InlineLabel).Address = currentPosition;
                }
                else if (element.value is Reference)
                {
                    (element.value as Reference).BaseAddress = currentPosition;
                    currentPosition += 4;
                }
            }

            if (change is CodeAllocation)
            {
                codeAllocationCounter += currentPosition - startPosition;
            } else if (change is MemoryAllocation)
            {
                memoryAllocationCounter += currentPosition - startPosition;
            }
        }

        // Assign address to each label defined by an offset within current codeblock
        private static void InitializeFixedLabelAddresses(List<Label> labels, byte[] data)
        {
            foreach (var label in labels)
            {
                string codeBlock = label.CodeBlockName;
                AOB aob = AOB.AOBList[codeBlock];
                aob.SetAddress(data);
                Console.WriteLine(aob.Address.Value);
                label.SetAddress(aob.Address.Value);
            }
        }

        private static int InitializeReferenceAndGetNextPosition(Reference referenceElement, Dictionary<string, Label> labelDictionary, byte[] data, int currentPosition)
        {
            if (referenceElement is FixedReference) // A fixed reference is a 32-bit address so add 4 to current position
            {
                (referenceElement as FixedReference).Value = GetTargetAddress(referenceElement, labelDictionary, data);
                return currentPosition +4;
            }
            else if (referenceElement is RelativeReference) // A relative reference can be a 8-bit or 32-bit address so determine and increment appropriately
            {
                int offset = currentPosition - GetTargetAddress(referenceElement, labelDictionary, data);
                (referenceElement as FixedReference).Value = offset;
                return currentPosition + 4;
            }
            else
            {
                throw new Exception();
            }
        }

        private static int GetTargetAddress(Reference reference, Dictionary<string, Label> labelDictionary, byte[] data)
        {
            string targetLabelName = reference.TargetLabelName;
            Label targetLabel = labelDictionary[targetLabelName];

            string codeBlock = targetLabel.CodeBlockName;
            AOB aob = AOB.AOBList[codeBlock];
            aob.SetAddress(data);
            targetLabel.SetAddress(aob.Address.Value);
            return targetLabel.Address;
        }

        private static void WriteData(NumberOrAddress element, byte[] data)
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
