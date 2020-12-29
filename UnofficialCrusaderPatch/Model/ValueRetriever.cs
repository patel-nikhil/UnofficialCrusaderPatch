using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UCP
{
    public class ValueRetriever : IEnumerable<NumberOrAddress>
    {
        public List<NumberOrAddress> Elements = new List<NumberOrAddress>();

        public ValueRetriever(params object[] values)
        {
            foreach (var elem in values)
            {
                if (elem is byte)
                {
                    this.Add((byte)elem);
                }
                else if (elem is byte[])
                {
                    foreach (var byteElement in (byte[])elem)
                    {
                        this.Add((byte)byteElement);
                    }
                }
                else if (elem is int)
                {
                    this.Add((int)elem);
                }
                else if (elem is Reference)
                {
                    this.Add(new NumberOrAddress((Reference)elem));
                }
                else if (elem is InlineLabel)
                {
                    this.Add(new NumberOrAddress((InlineLabel)elem));
                }
                else if (elem is NumberOrAddress)
                {
                    this.Add((NumberOrAddress)elem);
                }
            };
        }

        public void Add(byte value)
        {
            this.Elements.Add(new NumberOrAddress(value));
        }

        public void Add(int value)
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
