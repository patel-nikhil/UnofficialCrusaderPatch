using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UCP
{
    public class InstallHelper
    {
        public class InstallData
        {
            public int CodeAllocationCounter { get; set; }
            public int MemoryAllocationCounter { get; set; }

            public InstallData()
            {
                CodeAllocationCounter = 0;
                MemoryAllocationCounter = 0;
            }
        }

        public class AllocatedBytes
        {
            public List<byte> codeAllocations { get; set; }
            public List<byte> memoryAllocations { get; set; }

            public AllocatedBytes()
            {
                codeAllocations = new List<byte>();
                memoryAllocations = new List<byte>();
            }
        }
    }
}
