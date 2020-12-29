using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using static UCP.InstallHelper;
using static UCP.AddressResolver;

namespace UCP
{
    internal class Writer
    {
        internal static void WriteSections(SectionHelper writer, ref byte[] data, InstallData installData, out int codeSectionStart, out int codeSectionVirtualStart, out int dataSectionStart, out int dataSectionVirtualStart)
        {
            writer.AddCodeSection(ref data, installData.CodeAllocationCounter, out codeSectionStart, out codeSectionVirtualStart);
            writer.AddDataSection(ref data, installData.MemoryAllocationCounter, out dataSectionStart, out dataSectionVirtualStart);
        }

        internal static void WriteSectionData(byte[] data, int rawDataOffset, List<byte> bytesToWrite)
        {
            bytesToWrite.ToArray().CopyTo(data, rawDataOffset);
        }

        internal static int WriteCode(NumberOrAddress element, Dictionary<string, Label> labelDictionary, byte[] data, int currentPosition, int allocatedCodeSectionStart, int allocatedCodeSectionVirtualStart, int allocatedMemorySectionStart, int allocatedMemorySectionVirtualStart, int section)
        {
            if (element.value is FixedReference) // Write 32-bit value
            {
                var addressValue = 0x400000 + GetTargetAddress(element.value, labelDictionary, data, allocatedCodeSectionVirtualStart, allocatedMemorySectionVirtualStart);
                WriteValue(addressValue, data, currentPosition);
                return 4;
            }
            else if (element.value is RelativeReference) // Write 32-bit value. Potential 8-bit instruction is ignored to reduce complexity
            {
                var addressValue = GetTargetAddress(element.value, labelDictionary, data, allocatedCodeSectionVirtualStart, allocatedMemorySectionVirtualStart);
                RelativeReference relativeReference = element.value as RelativeReference;
                int offset = addressValue - relativeReference.BaseAddress - 4;
                WriteValue(offset, data, currentPosition);
                return 4;
            }
            else if (element.value is AllocatedRelativeReference) // Write 32-bit value. Potential 8-bit instruction is ignored to reduce complexity
            {
                var addressValue = GetTargetAddress(element.value, labelDictionary, data, allocatedCodeSectionVirtualStart, allocatedMemorySectionVirtualStart);
                AllocatedRelativeReference relativeReference = element.value as AllocatedRelativeReference;
                int offset = addressValue - relativeReference.BaseAddress - 4 - (section == 1 ? allocatedCodeSectionVirtualStart : allocatedMemorySectionVirtualStart);
                WriteValue(offset, data, currentPosition);
                return 4;
            }
            else if (element.value is byte)
            {
                byte value = (byte)element.value; // Write single byte
                WriteSingleByte(value, data, currentPosition);
                return 1;
            }
            else if (element.value is int)
            {
                int value = (int)element.value; // Write 32-bit integer
                WriteValue(value, data, currentPosition);
                return 4;
            }
            else
            {
                throw new Exception();
            }
        }

        internal static void WriteSingleByte(byte value, byte[] data, int currentPosition)
        {
            data[currentPosition] = value;
            /*Console.WriteLine(value);*/
        }

        internal static void WriteValue(int value, byte[] data, int currentPosition)
        {
            BitConverter.GetBytes(value).CopyTo(data, currentPosition);
            /*Console.WriteLine(value);*/
        }

        /*private static void WriteRelativeAddress(int value, byte[] data)
        {
            if (value < 0x7F && value > 0x80)
            {
                WriteSingleByte((byte)value, data);
            }
            else
            {
                WriteValue(value, data);
            }
        }*/
    }
}
