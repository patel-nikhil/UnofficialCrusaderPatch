using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UCP
{
    internal class SectionHelper
    {
        public List<Section> sectionList;
        public int CodeSectionStart { get; set; }
        public int DataSectionStart { get; set; }

        public SectionHelper(byte[] data)
        {
            sectionList = ReadSections(data);
        }

        static int GetNextMultiple(int baseNumber, int number)
        {
            int multiple = baseNumber + number - 1;
            multiple -= (multiple % baseNumber);
            return multiple;
        }

        List<Section> ReadSections(byte[] data)
        {
            List<Section> sectionList = new List<Section>();
            byte sectionCount = data[286];
            for (int i = 1; i <= sectionCount; i++)
            {
                int sectionStart = 0x1E8 + 40 * i;
                int currentPos = sectionStart;
                string sectionName = "";
                while (data[currentPos] != 0)
                {
                    sectionName += (char)data[currentPos];
                    currentPos++;
                }

                int sectionVirtualDataSize = BitConverter.ToInt32(data, sectionStart + 0x8);
                int sectionVirtualAddress = BitConverter.ToInt32(data, sectionStart + 0xC);
                int sectionRawDataSize = BitConverter.ToInt32(data, sectionStart + 0x10);
                int sectionRawDataOffset = BitConverter.ToInt32(data, sectionStart + 0x14);
                sectionList.Add(new Section()
                    .withName(sectionName)
                    .withNumber(i)
                    .withVirtualDataSize(sectionVirtualDataSize)
                    .withVirtualAddress(sectionVirtualAddress)
                    .withRawDataSize(sectionRawDataSize)
                    .withRawDataOffset(sectionRawDataOffset)
                    );
            }
            return sectionList;
        }

        internal void AddCodeSection(ref byte[] data, int size, out int sectionStart, out int sectionVirtualStart)
        {
            bool ucpSectionExists = false;
            
            int previousSectionRawEnd = 0;
            int previousSectionVirtualEnd = 0;
            int previousSectionNumber = 1;
            foreach (Section currentSection in sectionList)
            {
                if (currentSection.Name.Equals(".ucp"))
                {
                    ucpSectionExists = true;
                    break;
                }
                previousSectionNumber++;
                previousSectionRawEnd = currentSection.RawDataOffset + currentSection.RawDataSize;
                previousSectionVirtualEnd = currentSection.VirtualAddress + currentSection.VirtualDataSize;
            }
            Section section = new Section()
                .withName(".ucp")
                .withNumber(previousSectionNumber)
                .withRawDataOffset(GetNextMultiple(0x1000, previousSectionRawEnd))
                .withRawDataSize(size)
                .withVirtualAddress(GetNextMultiple(0x1000, previousSectionVirtualEnd))
                .withVirtualDataSize(size)
                .withSectionType(SectionType.EXECUTABLE);

            sectionStart = section.RawDataOffset;
            sectionVirtualStart = section.VirtualAddress;
            int originalSectionSize = 0;
            if (!ucpSectionExists)
            {
                sectionList.Add(section);
            }
            else
            {
                Section ucpSection = sectionList.ElementAt(previousSectionNumber);
                originalSectionSize = ucpSection.VirtualDataSize;
                ucpSection
                    .withName(section.Name)
                    .withNumber(section.Number)
                    .withRawDataOffset(section.RawDataOffset)
                    .withRawDataSize(section.RawDataSize)
                    .withVirtualAddress(section.VirtualAddress)
                    .withVirtualDataSize(section.VirtualDataSize)
                    .withSectionType(SectionType.EXECUTABLE);
            }
            AddSection(ref data, section, originalSectionSize);
        }

        internal void AddDataSection(ref byte[] data, int size, out int sectionStart, out int sectionVirtualStart)
        {
            bool ucpDataSectionExists = false;

            int previousSectionRawEnd = 0;
            int previousSectionVirtualEnd = 0;
            int previousSectionNumber = 1;
            foreach (Section currentSection in sectionList)
            {
                if (currentSection.Name.Equals(".ucpdata"))
                {
                    ucpDataSectionExists = true;
                    break;
                }
                previousSectionNumber++;
                previousSectionRawEnd = currentSection.RawDataOffset + currentSection.RawDataSize;
                previousSectionVirtualEnd = currentSection.VirtualAddress + currentSection.VirtualDataSize;
            }
            Section section = new Section()
                .withName(".ucpdata")
                .withNumber(previousSectionNumber)
                .withRawDataOffset(GetNextMultiple(0x1000, previousSectionRawEnd))
                .withRawDataSize(size)
                .withVirtualAddress(GetNextMultiple(0x1000, previousSectionVirtualEnd))
                .withVirtualDataSize(size)
                .withSectionType(SectionType.DATA);

            sectionStart = section.RawDataOffset;
            sectionVirtualStart = section.VirtualAddress;
            int originalSectionSize = 0;
            if (!ucpDataSectionExists)
            {
                sectionList.Add(section);
            }
            else
            {
                Section ucpSection = sectionList.ElementAt(previousSectionNumber);
                originalSectionSize = ucpSection.VirtualDataSize;
                ucpSection
                    .withName(section.Name)
                    .withNumber(section.Number)
                    .withRawDataOffset(section.RawDataOffset)
                    .withRawDataSize(section.RawDataSize)
                    .withVirtualAddress(section.VirtualAddress)
                    .withVirtualDataSize(section.VirtualDataSize)
                    .withSectionType(SectionType.DATA);
            }
            AddSection(ref data, section, originalSectionSize);
        }

        void AddSection(ref byte[] data, Section section, int originalSectionSize)
        {
            int originalImageSize = BitConverter.ToInt32(data, 360);

            WriteSectionCount(data, (byte)section.Number);
            WriteImageSize(data, originalImageSize - originalSectionSize + GetNextMultiple(0x1000, section.VirtualDataSize));
            WriteSectionData(data, section);
            AdjustSectionSize(ref data, section);
        }

        private void AdjustSectionSize(ref byte[] data, Section section)
        {
            if (data.Length != section.RawDataOffset + section.RawDataSize)
            {
                Array.Resize(ref data, GetNextMultiple(0x1000, section.RawDataSize + section.RawDataOffset));
            }
        }

        void WriteSectionCount(byte[] data, byte newSectionCount)
        {
            data[286] = newSectionCount;
        }

        void WriteImageSize(byte[] data, int newSize)
        {
            BitConverter.GetBytes(newSize).CopyTo(data, 360);
        }

        void WriteSectionData(byte[] data, Section section)
        {
            int sectionStart = 0x1E8 + 40 * section.Number;

            int nameOffset = sectionStart;
            foreach (var characterByte in Encoding.ASCII.GetBytes(section.Name))
            {
                data[nameOffset] = characterByte;
                nameOffset++;
            }

            BitConverter.GetBytes(section.VirtualDataSize).CopyTo(data, sectionStart + 0x8);
            BitConverter.GetBytes(section.VirtualAddress).CopyTo(data, sectionStart + 0xC);
            BitConverter.GetBytes(section.RawDataSize).CopyTo(data, sectionStart + 0x10);
            BitConverter.GetBytes(section.RawDataOffset).CopyTo(data, sectionStart + 0x14);

            if (section.SectionType == SectionType.EXECUTABLE) // Set Code, Executable, Readable, Writeable
            {
                data[sectionStart + 0x24] = (byte)0x20;
                data[sectionStart + 0x25] = (byte)0x00;
                data[sectionStart + 0x26] = (byte)0x00;
                data[sectionStart + 0x27] = (byte)0xE0;
            }
            else if (section.SectionType == SectionType.DATA) // Set Initialized Data, Readable, Writeable
            {
                data[sectionStart + 0x24] = (byte)0x40;
                data[sectionStart + 0x25] = (byte)0x00;
                data[sectionStart + 0x26] = (byte)0x00;
                data[sectionStart + 0x27] = (byte)0xC0;
            }
        }
    }
}
