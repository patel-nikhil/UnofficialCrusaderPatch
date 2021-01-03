using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UCP
{
    public interface ValueRetriever : IEnumerable<AssemblyElement>
    {
    }

    public class InlineValueRetriever : ValueRetriever, IEnumerable<AssemblyElement>
    {
        public List<AssemblyElement> Elements = new List<AssemblyElement>();

        public InlineValueRetriever()
        {

        }

        public void Add(SkipPosition value)
        {
            this.Elements.Add(new AssemblyElement(value));
        }

        public void Add(byte value)
        {
            this.Elements.Add(new AssemblyElement(value));
        }

        public void Add(byte[] value)
        {
            foreach(var elem in value)
            {
                this.Elements.Add(new AssemblyElement(elem));
            }
        }

        public void Add(ValueOrAddress[] value)
        {
            foreach (var elem in value)
            {
                this.Elements.Add(new AssemblyElement(elem.value));
            }
        }

        public void Add(int value)
        {
            this.Elements.Add(new AssemblyElement(value));
        }

        public void Add(int[] value)
        {
            foreach (var elem in value)
            {
                this.Elements.Add(new AssemblyElement(elem));
            }
        }

        public void Add(InlineLabel value)
        {
            this.Elements.Add(new AssemblyElement(value));
        }

        public void Add(FixedReference value)
        {
            this.Elements.Add(new AssemblyElement(value));
        }

        public void Add(RelativeReference value)
        {
            this.Elements.Add(new AssemblyElement(value));
        }

        public void Add(AssemblyElement value)
        {
            this.Elements.Add(value);
        }

        public IEnumerator<AssemblyElement> GetEnumerator()
        {
            return ((IEnumerable<AssemblyElement>)Elements).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable)Elements).GetEnumerator();
        }
    }


    public class AllocatedValueRetriever : ValueRetriever, IEnumerable<AssemblyElement>
    {
        public List<AssemblyElement> Elements = new List<AssemblyElement>();

        public AllocatedValueRetriever()
        {

        }

        public void Add(SkipPosition value)
        {
            this.Elements.Add(new AssemblyElement(value));
        }

        public void Add(byte value)
        {
            this.Elements.Add(new AssemblyElement(value));
        }

        public void Add(byte[] value)
        {
            foreach (var elem in value)
            {
                this.Elements.Add(new AssemblyElement(elem));
            }
        }

        public void Add(int value)
        {
            this.Elements.Add(new AssemblyElement(value));
        }

        public void Add(int[] value)
        {
            foreach (var elem in value)
            {
                this.Elements.Add(new AssemblyElement(elem));
            }
        }

        public void Add(AllocatedCodeLabel value)
        {
            this.Elements.Add(new AssemblyElement(value));
        }

        public void Add(AllocatedMemoryLabel value)
        {
            this.Elements.Add(new AssemblyElement(value));
        }

        public void Add(FixedReference value)
        {
            this.Elements.Add(new AssemblyElement(value));
        }

        public void Add(AllocatedRelativeReference value)
        {
            this.Elements.Add(new AssemblyElement(value));
        }

        public void Add(AssemblyElement value)
        {
            this.Elements.Add(value);
        }

        public IEnumerator<AssemblyElement> GetEnumerator()
        {
            return ((IEnumerable<AssemblyElement>)Elements).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable)Elements).GetEnumerator();
        }
    }
}
