using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using static UCP.Patching.BinElements.Register;

namespace UCP.Patching.BinElements
{
    public partial class OpCodes
    {
    }


    [Serializable]
    internal class UnsupportedOperandException : Exception
    {
        public UnsupportedOperandException()
        {
        }

        public UnsupportedOperandException(string message) : base(message)
        {
        }

        public UnsupportedOperandException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected UnsupportedOperandException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
