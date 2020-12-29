using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UCP
{
    public class NumberOrAddress
    {
        public dynamic value { get; }

        public NumberOrAddress(byte element)
        {
            this.value = element;
        }

        public NumberOrAddress(int element)
        {
            this.value = element;
        }

        public NumberOrAddress(InlineLabel element)
        {
            this.value = element;
        }

        public NumberOrAddress(AllocatedCodeLabel element)
        {
            this.value = element;
        }

        public NumberOrAddress(AllocatedMemoryLabel element)
        {
            this.value = element;
        }

        public NumberOrAddress(Reference element)
        {
            this.value = element;
        }

        public bool IsLabel => this.value is Label;
        public bool IsReference => this.value is Reference;

        public override int GetHashCode()
        {
            return this.value.GetHashCode();
        }
    }
}
