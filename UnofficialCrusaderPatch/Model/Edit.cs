using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UCP
{
    public interface IChange
    {
        ValueRetriever GetByteValue();
    }

    internal abstract class AbstractChange {
        public string _codeBlockName;
    }

    internal class CodeReplacement : AbstractChange, IChange
    {
        protected int[] Parameters { get; }
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
        protected int[] Parameters { get; }
        public CodeAllocation(int[] parameters)
        {
            this.Parameters = parameters;
        }

        public CodeAllocation() {
        }

        public virtual ValueRetriever GetByteValue()
        {
            return new ValueRetriever(0x00, 0x90, (byte)Parameters[0], 0x5);
        }
    }

    internal class MemoryAllocation : IChange
    {
        protected int[] Parameters { get; }
        public MemoryAllocation(int[] parameters)
        {
            this.Parameters = parameters;
        }

        public MemoryAllocation() { }

        public virtual ValueRetriever GetByteValue()
        {
            return new ValueRetriever(0x00, 0x90, (byte)Parameters[0], new NumberOrAddress(0x5));
        }
    }
}
