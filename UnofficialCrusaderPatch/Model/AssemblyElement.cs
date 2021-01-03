using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UCP
{
    public class AssemblyElement
    {
        public dynamic value { get; }

        public AssemblyElement(byte element)
        {
            this.value = element;
        }

        public AssemblyElement(int element)
        {
            this.value = element;
        }

        public AssemblyElement(SkipPosition element)
        {
            this.value = element;
        }

        public AssemblyElement(InlineLabel element)
        {
            this.value = element;
        }

        public AssemblyElement(AllocatedCodeLabel element)
        {
            this.value = element;
        }

        public AssemblyElement(AllocatedMemoryLabel element)
        {
            this.value = element;
        }

        public AssemblyElement(Reference element)
        {
            this.value = element;
        }

        public bool IsLabel => this.value is Label;
        public bool IsReference => this.value is Reference;

        public bool IsSkip => this.value is SkipPosition;

        public override int GetHashCode()
        {
            return this.value.GetHashCode();
        }
    }

    public class ValueOrAddress
    {
        public dynamic value { get; }

        public ValueOrAddress(byte element)
        {
            this.value = element;
        }

        public ValueOrAddress(int element)
        {
            this.value = element;
        }
        public ValueOrAddress(Reference element)
        {
            this.value = element;
        }
        public override int GetHashCode()
        {
            return this.value.GetHashCode();
        }
    }
}
