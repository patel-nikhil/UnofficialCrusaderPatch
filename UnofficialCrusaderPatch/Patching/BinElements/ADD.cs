using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using static UCP.Patching.BinElements.Register;

namespace UCP.Patching.BinElements
{
    public partial class OpCodes
    {
        public static byte[] ADD(byte[] instruction)
        {
            return instruction;
        }

        public static byte[] ADD(Register reg, sbyte signedValue)
        {
            byte val = signedValue < 0 ? (byte)(0xFF - Math.Abs(signedValue) + 1) : (byte)signedValue;
            switch (reg)
            {
                case EAX:
                    return (new byte[] { 0x83, 0xC0, val });
                case ECX:
                    return (new byte[] { 0x83, 0xC1, val });
                case EDX:
                    return (new byte[] { 0x83, 0xC2, val });
                case EBX:
                    return (new byte[] { 0x83, 0xC3, val });
                case ESP:
                    return (new byte[] { 0x83, 0xC4, val });
                case EBP:
                    return (new byte[] { 0x83, 0xC5, val });
                case ESI:
                    return (new byte[] { 0x83, 0xC6, val });
                case EDI:
                    return (new byte[] { 0x83, 0xC7, val });
            }
            throw new UnsupportedOperandException();
        }

        public static byte[] ADD(Register reg, Int32 val)
        {
            if (val <= SByte.MaxValue && val >= SByte.MinValue)
            {
                return ADD(reg, (sbyte)val);
            }
            switch (reg)
            {
                case EAX:
                    return (new byte[] { 0x83, 0xC0 }).Concat(BitConverter.GetBytes(val)).ToArray();
                case ECX:
                    return (new byte[] { 0x83, 0xC1 }).Concat(BitConverter.GetBytes(val)).ToArray();
                case EDX:
                    return (new byte[] { 0x83, 0xC2 }).Concat(BitConverter.GetBytes(val)).ToArray();
                case EBX:
                    return (new byte[] { 0x83, 0xC3 }).Concat(BitConverter.GetBytes(val)).ToArray();
                case ESP:
                    return (new byte[] { 0x83, 0xC4 }).Concat(BitConverter.GetBytes(val)).ToArray();
                case EBP:
                    return (new byte[] { 0x83, 0xC5 }).Concat(BitConverter.GetBytes(val)).ToArray();
                case ESI:
                    return (new byte[] { 0x83, 0xC6 }).Concat(BitConverter.GetBytes(val)).ToArray();
                case EDI:
                    return (new byte[] { 0x83, 0xC7 }).Concat(BitConverter.GetBytes(val)).ToArray();
            }
            throw new UnsupportedOperandException();
        }

        public static byte[] ADD(Register reg1, Register reg2)
        {
            switch (reg1)
            {
                case EAX:
                    switch (reg2)
                    {
                        case EAX:
                            return new byte[] { 0x01, 0xC0 };
                        case ECX:
                            return new byte[] { 0x01, 0xC1 };
                        case EDX:
                            return new byte[] { 0x01, 0xC2 };
                        case EBX:
                            return new byte[] { 0x01, 0xC3 };
                        case ESP:
                            return new byte[] { 0x01, 0xC4 };
                        case EBP:
                            return new byte[] { 0x01, 0xC5 };
                        case ESI:
                            return new byte[] { 0x01, 0xC6 };
                        case EDI:
                            return new byte[] { 0x01, 0xC7 };
                    }
                    throw new UnsupportedOperandException();

                case ECX:
                    switch (reg2)
                    {
                        case EAX:
                            return new byte[] { 0x01, 0xC8 };
                        case ECX:
                            return new byte[] { 0x01, 0xC9 };
                        case EDX:
                            return new byte[] { 0x01, 0xCA };
                        case EBX:
                            return new byte[] { 0x01, 0xCB };
                        case ESP:
                            return new byte[] { 0x01, 0xCC };
                        case EBP:
                            return new byte[] { 0x01, 0xCD };
                        case ESI:
                            return new byte[] { 0x01, 0xCE };
                        case EDI:
                            return new byte[] { 0x01, 0xCF };
                    }
                    throw new UnsupportedOperandException();

                case EDX:
                    switch (reg2)
                    {
                        case EAX:
                            return new byte[] { 0x01, 0xD0 };
                        case ECX:
                            return new byte[] { 0x01, 0xD1 };
                        case EDX:
                            return new byte[] { 0x01, 0xD2 };
                        case EBX:
                            return new byte[] { 0x01, 0xD3 };
                        case ESP:
                            return new byte[] { 0x01, 0xD4 };
                        case EBP:
                            return new byte[] { 0x01, 0xD5 };
                        case ESI:
                            return new byte[] { 0x01, 0xD6 };
                        case EDI:
                            return new byte[] { 0x01, 0xD7 };
                    }
                    throw new UnsupportedOperandException();

                case EBX:
                    switch (reg2)
                    {
                        case EAX:
                            return new byte[] { 0x01, 0xD8 };
                        case ECX:
                            return new byte[] { 0x01, 0xD9 };
                        case EDX:
                            return new byte[] { 0x01, 0xDA };
                        case EBX:
                            return new byte[] { 0x01, 0xDB };
                        case ESP:
                            return new byte[] { 0x01, 0xDC };
                        case EBP:
                            return new byte[] { 0x01, 0xDD };
                        case ESI:
                            return new byte[] { 0x01, 0xDE };
                        case EDI:
                            return new byte[] { 0x01, 0xDF };
                    }
                    throw new UnsupportedOperandException();

                case ESP:
                    switch (reg2)
                    {
                        case EAX:
                            return new byte[] { 0x01, 0xE0 };
                        case ECX:
                            return new byte[] { 0x01, 0xE1 };
                        case EDX:
                            return new byte[] { 0x01, 0xE2 };
                        case EBX:
                            return new byte[] { 0x01, 0xE3 };
                        case ESP:
                            return new byte[] { 0x01, 0xE4 };
                        case EBP:
                            return new byte[] { 0x01, 0xE5 };
                        case ESI:
                            return new byte[] { 0x01, 0xE6 };
                        case EDI:
                            return new byte[] { 0x01, 0xE7 };
                    }
                    throw new UnsupportedOperandException();

                case EBP:
                    switch (reg2)
                    {
                        case EAX:
                            return new byte[] { 0x01, 0xE8 };
                        case ECX:
                            return new byte[] { 0x01, 0xE9 };
                        case EDX:
                            return new byte[] { 0x01, 0xEA };
                        case EBX:
                            return new byte[] { 0x01, 0xEB };
                        case ESP:
                            return new byte[] { 0x01, 0xEC };
                        case EBP:
                            return new byte[] { 0x01, 0xED };
                        case ESI:
                            return new byte[] { 0x01, 0xEE };
                        case EDI:
                            return new byte[] { 0x01, 0xEF };
                    }
                    throw new UnsupportedOperandException();
                case ESI:
                    switch (reg2)
                    {
                        case EAX:
                            return new byte[] { 0x01, 0xF0 };
                        case ECX:
                            return new byte[] { 0x01, 0xF1 };
                        case EDX:
                            return new byte[] { 0x01, 0xF2 };
                        case EBX:
                            return new byte[] { 0x01, 0xF3 };
                        case ESP:
                            return new byte[] { 0x01, 0xF4 };
                        case EBP:
                            return new byte[] { 0x01, 0xF5 };
                        case ESI:
                            return new byte[] { 0x01, 0xF6 };
                        case EDI:
                            return new byte[] { 0x01, 0xF7 };
                    }
                    throw new UnsupportedOperandException();

                case EDI:
                    switch (reg2)
                    {
                        case EAX:
                            return new byte[] { 0x01, 0xF8 };
                        case ECX:
                            return new byte[] { 0x01, 0xF9 };
                        case EDX:
                            return new byte[] { 0x01, 0xFA };
                        case EBX:
                            return new byte[] { 0x01, 0xFB };
                        case ESP:
                            return new byte[] { 0x01, 0xFC };
                        case EBP:
                            return new byte[] { 0x01, 0xFD };
                        case ESI:
                            return new byte[] { 0x01, 0xFE };
                        case EDI:
                            return new byte[] { 0x01, 0xFF };
                    }
                    throw new UnsupportedOperandException();
            }
            throw new UnsupportedOperandException();
        }
    }
}
