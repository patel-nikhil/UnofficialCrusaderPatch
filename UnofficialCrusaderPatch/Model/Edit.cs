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

    internal abstract class AbstractChange
    {
        public abstract ValueRetriever GetByteValue();
    }


    internal class CodeReplacement : AbstractChange, IChange
    {
        string _codeBlockName;

        protected InlineValueRetriever Value;
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

        public override ValueRetriever GetByteValue()
        {
            return Value;
        }
    }

    internal class CodeAllocation : AbstractChange, IChange
    {
        protected AllocatedValueRetriever Value;
        protected int[] Parameters { get; }
        public CodeAllocation(int[] parameters)
        {
            this.Parameters = parameters;
        }

        public CodeAllocation() { }
        public override ValueRetriever GetByteValue()
        {
            return Value;
        }
    }

    internal class MemoryAllocation : AbstractChange, IChange
    {
        protected AllocatedValueRetriever Value;
        protected int[] Parameters { get; }
        public MemoryAllocation(int[] parameters)
        {
            this.Parameters = parameters;
        }

        public MemoryAllocation() { }
        public override ValueRetriever GetByteValue()
        {
            return Value;
        }
    }
}
