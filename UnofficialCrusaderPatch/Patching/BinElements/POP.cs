using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using static UCP.Patching.BinElements.Register;

namespace UCP.Patching.BinElements
{
    public partial class OpCodes
    {
        public static byte[] POP(byte[] instruction)
        {
            return instruction;
        }

        public static byte[] POP(Register reg)
        {
            switch (reg)
            {
                case EAX:
                    return new byte[] { 0x58 };
                case ECX:
                    return new byte[] { 0x59 };
                case EDX:
                    return new byte[] { 0x5A };
                case EBX:
                    return new byte[] { 0x5B };
                case ESP:
                    return new byte[] { 0x5C };
                case EBP:
                    return new byte[] { 0x5D };
                case ESI:
                    return new byte[] { 0x5E };
                case EDI:
                    return new byte[] { 0x5F };
                case ALL:
                    return new byte[] { 0x61 };
                case FLAGS:
                    return new byte[] { 0x66, 0x9D };
            }
            throw new UnsupportedOperandException();
        }
    }
}
