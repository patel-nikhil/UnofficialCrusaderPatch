using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UCP
{
    public interface ValueRetriever : IEnumerable<NumberOrAddress>
    {
    }

    public class InlineValueRetriever : ValueRetriever, IEnumerable<NumberOrAddress>
    {
        public List<NumberOrAddress> Elements = new List<NumberOrAddress>();

        public InlineValueRetriever()
        {

        }

        public void Add(SkipPosition value)
        {
            this.Elements.Add(new NumberOrAddress(value));
        }

        public void Add(byte value)
        {
            this.Elements.Add(new NumberOrAddress(value));
        }

        public void Add(byte[] value)
        {
            foreach(var elem in value)
            {
                this.Elements.Add(new NumberOrAddress(elem));
            }
        }

        public void Add(int value)
        {
            this.Elements.Add(new NumberOrAddress(value));
        }

        public void Add(int[] value)
        {
            foreach (var elem in value)
            {
                this.Elements.Add(new NumberOrAddress(elem));
            }
        }

        public void Add(InlineLabel value)
        {
            this.Elements.Add(new NumberOrAddress(value));
        }

        public void Add(FixedReference value)
        {
            this.Elements.Add(new NumberOrAddress(value));
        }

        public void Add(RelativeReference value)
        {
            this.Elements.Add(new NumberOrAddress(value));
        }

        public void Add(NumberOrAddress value)
        {
            this.Elements.Add(value);
        }

        public IEnumerator<NumberOrAddress> GetEnumerator()
        {
            return ((IEnumerable<NumberOrAddress>)Elements).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable)Elements).GetEnumerator();
        }
    }


    public class AllocatedValueRetriever : ValueRetriever, IEnumerable<NumberOrAddress>
    {
        public List<NumberOrAddress> Elements = new List<NumberOrAddress>();

        public AllocatedValueRetriever()
        {

        }

        public void Add(SkipPosition value)
        {
            this.Elements.Add(new NumberOrAddress(value));
        }

        public void Add(byte value)
        {
            this.Elements.Add(new NumberOrAddress(value));
        }

        public void Add(byte[] value)
        {
            foreach (var elem in value)
            {
                this.Elements.Add(new NumberOrAddress(elem));
            }
        }

        public void Add(int value)
        {
            this.Elements.Add(new NumberOrAddress(value));
        }

        public void Add(int[] value)
        {
            foreach (var elem in value)
            {
                this.Elements.Add(new NumberOrAddress(elem));
            }
        }

        public void Add(AllocatedCodeLabel value)
        {
            this.Elements.Add(new NumberOrAddress(value));
        }

        public void Add(AllocatedMemoryLabel value)
        {
            this.Elements.Add(new NumberOrAddress(value));
        }

        public void Add(FixedReference value)
        {
            this.Elements.Add(new NumberOrAddress(value));
        }

        public void Add(AllocatedRelativeReference value)
        {
            this.Elements.Add(new NumberOrAddress(value));
        }

        public void Add(NumberOrAddress value)
        {
            this.Elements.Add(value);
        }

        public IEnumerator<NumberOrAddress> GetEnumerator()
        {
            return ((IEnumerable<NumberOrAddress>)Elements).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable)Elements).GetEnumerator();
        }
    }
}
