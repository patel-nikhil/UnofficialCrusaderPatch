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
        public int[] Parameters { get; }
        public string CodeBlockName { get => _codeBlockName; }
        public CodeReplacement(string codeBlockName, int[] parameters)
        {
            this.Parameters = parameters;
            this._codeBlockName = codeBlockName;
        }

        public CodeReplacement(string codeBlockName) {
            this._codeBlockName = codeBlockName;
        }

        public CodeReplacement withValue(InlineValueRetriever valueRetriever)
        {
            this.Value = valueRetriever;
            return this;
        }

        public override ValueRetriever GetByteValue()
        {
            return Value;
        }
    }

    internal class CodeAllocation : AbstractChange, IChange
    {
        protected AllocatedValueRetriever Value;
        public int[] Parameters { get; }
        public CodeAllocation(int[] parameters)
        {
            this.Parameters = parameters;
        }

        public CodeAllocation() { }

        public CodeAllocation withValue(AllocatedValueRetriever valueRetriever)
        {
            this.Value = valueRetriever;
            return this;
        }

        public override ValueRetriever GetByteValue()
        {
            return Value;
        }
    }

    internal class MemoryAllocation : AbstractChange, IChange
    {
        protected AllocatedValueRetriever Value;
        public int[] Parameters { get; }
        public MemoryAllocation(int[] parameters)
        {
            this.Parameters = parameters;
        }

        public MemoryAllocation() { }

        public MemoryAllocation withValue(AllocatedValueRetriever valueRetriever)
        {
            this.Value = valueRetriever;
            return this;
        }
        public override ValueRetriever GetByteValue()
        {
            return Value;
        }
    }
}
