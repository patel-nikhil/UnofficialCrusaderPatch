using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UCP
{
    internal interface IChange
    {
        ValueRetriever GetByteValue();
    }

    internal abstract class Change {
        public string _codeBlockName;
    }

    internal class CodeReplacement : Change, IChange
    {
        private int[] Parameters { get; }
        public string CodeBlockName { get => _codeBlockName; }
        public CodeReplacement(string codeBlockName, int[] parameters)
        {
            this.Parameters = parameters;
            this._codeBlockName = codeBlockName;
        }

        public CodeReplacement(string codeBlockName) {
            this._codeBlockName = codeBlockName;
        }

        public virtual ValueRetriever GetByteValue()
        {
            return new ValueRetriever(0x00, 0x90, (byte)Parameters[0], 0x5);
        }
    }

    internal class CodeAllocation : IChange
    {
        private int[] Parameters { get; }
        public CodeAllocation(int[] parameters)
        {
            this.Parameters = parameters;
        }

        public CodeAllocation() {
        }

        public ValueRetriever GetByteValue()
        {
            return new ValueRetriever(0x00, 0x90, (byte)Parameters[0], 0x5);
        }
    }

    internal class MemoryAllocation : IChange
    {
        private int[] Parameters { get; }
        public MemoryAllocation(int[] parameters)
        {
            this.Parameters = parameters;
        }

        public MemoryAllocation() { }

        public ValueRetriever GetByteValue()
        {
            return new ValueRetriever(0x00, 0x90, (byte)Parameters[0], new ByteOrAddress(0x5));
        }
    }


    class ValueRetriever : IEnumerable<ByteOrAddress>
    {
        public List<ByteOrAddress> Elements = new List<ByteOrAddress>();

        public ValueRetriever(params object[] values)
        {
            foreach (var elem in values) { 
                if (elem is byte)
                {
                    this.Add((byte)elem);
                }
                else if (elem is ByteOrAddress)
                {
                    this.Add((ByteOrAddress)elem);
                }
                
            };
        }

        public void Add(byte value)
        {
            this.Elements.Add(new ByteOrAddress(value));
        }

        public void Add(ByteOrAddress value)
        {
            this.Elements.Add(value);
        }

        public IEnumerator<ByteOrAddress> GetEnumerator()
        {
            return ((IEnumerable<ByteOrAddress>)Elements).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable)Elements).GetEnumerator();
        }
    }

    public class ByteOrAddress
    {
        public dynamic value { get; }

        public ByteOrAddress(byte element)
        {
            this.value = element;
        }

        public ByteOrAddress(InlineLabel element)
        {
            this.value = element;
        }

        public ByteOrAddress(Reference element)
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
