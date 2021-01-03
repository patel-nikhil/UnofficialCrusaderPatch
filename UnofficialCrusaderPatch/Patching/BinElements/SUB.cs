using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using static UCP.Patching.BinElements.Register;

namespace UCP.Patching.BinElements
{
    public partial class OpCodes
    {
        public static byte[] SUB(byte[] instruction)
        {
            return instruction;
        }

        public static byte[] SUB(Register reg, sbyte signedValue)
        {
            byte val = signedValue < 0 ? (byte)(0xFF - Math.Abs(signedValue) + 1) : (byte)signedValue;
            switch (reg)
            {
                case EAX:
                    return (new byte[] { 0x83, 0xE8, val });
                case ECX:
                    return (new byte[] { 0x83, 0xE9, val });
                case EDX:
                    return (new byte[] { 0x83, 0xEA, val });
                case EBX:
                    return (new byte[] { 0x83, 0xEB, val });
                case ESP:
                    return (new byte[] { 0x83, 0xEC, val });
                case EBP:
                    return (new byte[] { 0x83, 0xED, val });
                case ESI:
                    return (new byte[] { 0x83, 0xEE, val });
                case EDI:
                    return (new byte[] { 0x83, 0xEF, val });
            }
            throw new UnsupportedOperandException();
        }

        public static byte[] SUB(Register reg, Int32 val)
        {
            if (val <= SByte.MaxValue && val >= SByte.MinValue)
            {
                return SUB(reg, (sbyte)val);
            }
            switch (reg)
            {
                case EAX:
                    return (new byte[] { 0x83, 0xE8 }).Concat(BitConverter.GetBytes(val)).ToArray();
                case ECX:
                    return (new byte[] { 0x83, 0xE9 }).Concat(BitConverter.GetBytes(val)).ToArray();
                case EDX:
                    return (new byte[] { 0x83, 0xEA }).Concat(BitConverter.GetBytes(val)).ToArray();
                case EBX:
                    return (new byte[] { 0x83, 0xEB }).Concat(BitConverter.GetBytes(val)).ToArray();
                case ESP:
                    return (new byte[] { 0x83, 0xEC }).Concat(BitConverter.GetBytes(val)).ToArray();
                case EBP:
                    return (new byte[] { 0x83, 0xED }).Concat(BitConverter.GetBytes(val)).ToArray();
                case ESI:
                    return (new byte[] { 0x83, 0xEE }).Concat(BitConverter.GetBytes(val)).ToArray();
                case EDI:
                    return (new byte[] { 0x83, 0xEF }).Concat(BitConverter.GetBytes(val)).ToArray();
            }
            throw new UnsupportedOperandException();
        }

        public static byte[] SUB(Register reg1, Register reg2)
        {
            switch (reg1)
            {
                case EAX:
                    switch (reg2)
                    {
                        case EAX:
                            return new byte[] { 0x29, 0xC0 };
                        case ECX:
                            return new byte[] { 0x29, 0xC1 };
                        case EDX:
                            return new byte[] { 0x29, 0xC2 };
                        case EBX:
                            return new byte[] { 0x29, 0xC3 };
                        case ESP:
                            return new byte[] { 0x29, 0xC4 };
                        case EBP:
                            return new byte[] { 0x29, 0xC5 };
                        case ESI:
                            return new byte[] { 0x29, 0xC6 };
                        case EDI:
                            return new byte[] { 0x29, 0xC7 };
                    }
                    throw new UnsupportedOperandException();

                case ECX:
                    switch (reg2)
                    {
                        case EAX:
                            return new byte[] { 0x29, 0xC8 };
                        case ECX:
                            return new byte[] { 0x29, 0xC9 };
                        case EDX:
                            return new byte[] { 0x29, 0xCA };
                        case EBX:
                            return new byte[] { 0x29, 0xCB };
                        case ESP:
                            return new byte[] { 0x29, 0xCC };
                        case EBP:
                            return new byte[] { 0x29, 0xCD };
                        case ESI:
                            return new byte[] { 0x29, 0xCE };
                        case EDI:
                            return new byte[] { 0x29, 0xCF };
                    }
                    throw new UnsupportedOperandException();

                case EDX:
                    switch (reg2)
                    {
                        case EAX:
                            return new byte[] { 0x29, 0xD0 };
                        case ECX:
                            return new byte[] { 0x29, 0xD1 };
                        case EDX:
                            return new byte[] { 0x29, 0xD2 };
                        case EBX:
                            return new byte[] { 0x29, 0xD3 };
                        case ESP:
                            return new byte[] { 0x29, 0xD4 };
                        case EBP:
                            return new byte[] { 0x29, 0xD5 };
                        case ESI:
                            return new byte[] { 0x29, 0xD6 };
                        case EDI:
                            return new byte[] { 0x29, 0xD7 };
                    }
                    throw new UnsupportedOperandException();

                case EBX:
                    switch (reg2)
                    {
                        case EAX:
                            return new byte[] { 0x29, 0xD8 };
                        case ECX:
                            return new byte[] { 0x29, 0xD9 };
                        case EDX:
                            return new byte[] { 0x29, 0xDA };
                        case EBX:
                            return new byte[] { 0x29, 0xDB };
                        case ESP:
                            return new byte[] { 0x29, 0xDC };
                        case EBP:
                            return new byte[] { 0x29, 0xDD };
                        case ESI:
                            return new byte[] { 0x29, 0xDE };
                        case EDI:
                            return new byte[] { 0x29, 0xDF };
                    }
                    throw new UnsupportedOperandException();

                case ESP:
                    switch (reg2)
                    {
                        case EAX:
                            return new byte[] { 0x29, 0xE0 };
                        case ECX:
                            return new byte[] { 0x29, 0xE1 };
                        case EDX:
                            return new byte[] { 0x29, 0xE2 };
                        case EBX:
                            return new byte[] { 0x29, 0xE3 };
                        case ESP:
                            return new byte[] { 0x29, 0xE4 };
                        case EBP:
                            return new byte[] { 0x29, 0xE5 };
                        case ESI:
                            return new byte[] { 0x29, 0xE6 };
                        case EDI:
                            return new byte[] { 0x29, 0xE7 };
                    }
                    throw new UnsupportedOperandException();

                case EBP:
                    switch (reg2)
                    {
                        case EAX:
                            return new byte[] { 0x29, 0xE8 };
                        case ECX:
                            return new byte[] { 0x29, 0xE9 };
                        case EDX:
                            return new byte[] { 0x29, 0xEA };
                        case EBX:
                            return new byte[] { 0x29, 0xEB };
                        case ESP:
                            return new byte[] { 0x29, 0xEC };
                        case EBP:
                            return new byte[] { 0x29, 0xED };
                        case ESI:
                            return new byte[] { 0x29, 0xEE };
                        case EDI:
                            return new byte[] { 0x29, 0xEF };
                    }
                    throw new UnsupportedOperandException();

                case ESI:
                    switch (reg2)
                    {
                        case EAX:
                            return new byte[] { 0x29, 0xF0 };
                        case ECX:
                            return new byte[] { 0x29, 0xF1 };
                        case EDX:
                            return new byte[] { 0x29, 0xF2 };
                        case EBX:
                            return new byte[] { 0x29, 0xF3 };
                        case ESP:
                            return new byte[] { 0x29, 0xF4 };
                        case EBP:
                            return new byte[] { 0x29, 0xF5 };
                        case ESI:
                            return new byte[] { 0x29, 0xF6 };
                        case EDI:
                            return new byte[] { 0x29, 0xF7 };
                    }
                    throw new UnsupportedOperandException();

                case EDI:
                    switch (reg2)
                    {
                        case EAX:
                            return new byte[] { 0x29, 0xF8 };
                        case ECX:
                            return new byte[] { 0x29, 0xF9 };
                        case EDX:
                            return new byte[] { 0x29, 0xFA };
                        case EBX:
                            return new byte[] { 0x29, 0xFB };
                        case ESP:
                            return new byte[] { 0x29, 0xFC };
                        case EBP:
                            return new byte[] { 0x29, 0xFD };
                        case ESI:
                            return new byte[] { 0x29, 0xFE };
                        case EDI:
                            return new byte[] { 0x29, 0xFF };
                    }
                    throw new UnsupportedOperandException();
            }
            throw new UnsupportedOperandException();
        }
    }
}
