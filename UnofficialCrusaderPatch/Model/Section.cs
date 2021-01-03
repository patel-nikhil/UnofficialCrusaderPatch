using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UCP
{
    internal class Section
    {
        public string Name { get; private set; }
        public int Number { get; private set; }
        public int VirtualDataSize { get; private set; }
        public int VirtualAddress { get; private set; }
        public int RawDataSize { get; private set; }
        public int RawDataOffset { get; private set; }

        public SectionType SectionType { get; private set; }

        public Section withName(string name)
        {
            this.Name = name;
            return this;
        }

        public Section withNumber(int number)
        {
            this.Number = number;
            return this;
        }

        public Section withVirtualDataSize(int virtualDataSize)
        {
            this.VirtualDataSize = virtualDataSize;
            return this;
        }

        public Section withVirtualAddress(int virtualAddress)
        {
            this.VirtualAddress = virtualAddress;
            return this;
        }

        public Section withRawDataSize(int rawDataSize)
        {
            this.RawDataSize = rawDataSize;
            return this;
        }

        public Section withRawDataOffset(int rawDataOffset)
        {
            this.RawDataOffset = rawDataOffset;
            return this;
        }

        public Section withSectionType(SectionType sectionType)
        {
            this.SectionType = sectionType;
            return this;
        }
    }

    internal enum SectionType
    {
        EXECUTABLE,
        DATA
    }
}
