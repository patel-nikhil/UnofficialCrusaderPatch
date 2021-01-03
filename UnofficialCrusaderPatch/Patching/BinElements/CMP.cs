using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using static UCP.Patching.BinElements.Register;

namespace UCP.Patching.BinElements
{
    public partial class OpCodes
    {
        public static byte[] CMP(byte[] instruction)
        {
            return instruction;
        }

        public static byte[] CMP(Register reg, sbyte val)
        {
            switch (reg)
            {
                case EAX:
                    return new byte[] { 0x83, 0xF8, (byte)Math.Abs(val) };
                case ECX:
                    return new byte[] { 0x83, 0xF9, (byte)Math.Abs(val) };
                case EDX:
                    return new byte[] { 0x83, 0xFA, (byte)Math.Abs(val) };
                case EBX:
                    return new byte[] { 0x83, 0xFB, (byte)Math.Abs(val) };
                case ESP:
                    return new byte[] { 0x83, 0xFC, (byte)Math.Abs(val) };
                case EBP:
                    return new byte[] { 0x83, 0xFD, (byte)Math.Abs(val) };
                case ESI:
                    return new byte[] { 0x83, 0xFE, (byte)Math.Abs(val) };
                case EDI:
                    return new byte[] { 0x83, 0xFF, (byte)Math.Abs(val) };
            }
            throw new UnsupportedOperandException();
        }

        public static byte[] CMP(Register reg, Int32 signedValue)
        {

            if (signedValue <= SByte.MaxValue && signedValue >= SByte.MinValue)
            {
                return CMP(reg, (sbyte)signedValue);
            }

            Int32 val = (Int32)(signedValue >= 0 ? signedValue : 0xFFFFFFFF - Math.Abs(signedValue));
            switch (reg)
            {
                case EAX:
                    return (new byte[] { 0x3D }).Concat(BitConverter.GetBytes(val)).ToArray();
                case ECX:
                    return (new byte[] { 0x81, 0xF9 }).Concat(BitConverter.GetBytes(val)).ToArray();
                case EDX:
                    return (new byte[] { 0x81, 0xFA }).Concat(BitConverter.GetBytes(val)).ToArray();
                case EBX:
                    return (new byte[] { 0x81, 0xFB }).Concat(BitConverter.GetBytes(val)).ToArray();
                case ESP:
                    return (new byte[] { 0x81, 0xFC }).Concat(BitConverter.GetBytes(val)).ToArray();
                case EBP:
                    return (new byte[] { 0x81, 0xFD }).Concat(BitConverter.GetBytes(val)).ToArray();
                case ESI:
                    return (new byte[] { 0x81, 0xFE }).Concat(BitConverter.GetBytes(val)).ToArray();
                case EDI:
                    return (new byte[] { 0x81, 0xFF }).Concat(BitConverter.GetBytes(val)).ToArray();
            }
            throw new UnsupportedOperandException();
        }

        public static byte[] CMP(Register reg1, Register reg2)
        {
            switch (reg1)
            {
                case EAX:
                    switch (reg2)
                    {
                        case EAX:
                            return new byte[] { 0x39, 0xC0 };
                        case ECX:
                            return new byte[] { 0x39, 0xC8 };
                        case EDX:
                            return new byte[] { 0x39, 0xD0 };
                        case EBX:
                            return new byte[] { 0x39, 0xD8 };
                        case ESP:
                            return new byte[] { 0x39, 0xE0 };
                        case EBP:
                            return new byte[] { 0x39, 0xE8 };
                        case ESI:
                            return new byte[] { 0x39, 0xF0 };
                        case EDI:
                            return new byte[] { 0x39, 0xF8 };
                    }
                    throw new UnsupportedOperandException();

                case ECX:
                    switch (reg2)
                    {
                        case EAX:
                            return new byte[] { 0x39, 0xC1 };
                        case ECX:
                            return new byte[] { 0x39, 0xC9 };
                        case EDX:
                            return new byte[] { 0x39, 0xD1 };
                        case EBX:
                            return new byte[] { 0x39, 0xD9 };
                        case ESP:
                            return new byte[] { 0x39, 0xE1 };
                        case EBP:
                            return new byte[] { 0x39, 0xE9 };
                        case ESI:
                            return new byte[] { 0x39, 0xF1 };
                        case EDI:
                            return new byte[] { 0x39, 0xF9 };
                    }
                    throw new UnsupportedOperandException();

                case EDX:
                    switch (reg2)
                    {
                        case EAX:
                            return new byte[] { 0x39, 0xC2 };
                        case ECX:
                            return new byte[] { 0x39, 0xCA };
                        case EDX:
                            return new byte[] { 0x39, 0xD2 };
                        case EBX:
                            return new byte[] { 0x39, 0xDA };
                        case ESP:
                            return new byte[] { 0x39, 0xE2 };
                        case EBP:
                            return new byte[] { 0x39, 0xEA };
                        case ESI:
                            return new byte[] { 0x39, 0xF2 };
                        case EDI:
                            return new byte[] { 0x39, 0xFA };
                    }
                    throw new UnsupportedOperandException();

                case EBX:
                    switch (reg2)
                    {
                        case EAX:
                            return new byte[] { 0x39, 0xC3 };
                        case ECX:
                            return new byte[] { 0x39, 0xCB };
                        case EDX:
                            return new byte[] { 0x39, 0xD3 };
                        case EBX:
                            return new byte[] { 0x39, 0xDB };
                        case ESP:
                            return new byte[] { 0x39, 0xE3 };
                        case EBP:
                            return new byte[] { 0x39, 0xEB };
                        case ESI:
                            return new byte[] { 0x39, 0xF3 };
                        case EDI:
                            return new byte[] { 0x39, 0xFB };
                    }
                    throw new UnsupportedOperandException();

                case ESP:
                    switch (reg2)
                    {
                        case EAX:
                            return new byte[] { 0x39, 0xC4 };
                        case ECX:
                            return new byte[] { 0x39, 0xCC };
                        case EDX:
                            return new byte[] { 0x39, 0xD4 };
                        case EBX:
                            return new byte[] { 0x39, 0xDC };
                        case ESP:
                            return new byte[] { 0x39, 0xE4 };
                        case EBP:
                            return new byte[] { 0x39, 0xEC };
                        case ESI:
                            return new byte[] { 0x39, 0xF4 };
                        case EDI:
                            return new byte[] { 0x39, 0xFC };
                    }
                    throw new UnsupportedOperandException();

                case EBP:
                    switch (reg2)
                    {
                        case EAX:
                            return new byte[] { 0x39, 0xC5 };
                        case ECX:
                            return new byte[] { 0x39, 0xCD };
                        case EDX:
                            return new byte[] { 0x39, 0xD5 };
                        case EBX:
                            return new byte[] { 0x39, 0xDD };
                        case ESP:
                            return new byte[] { 0x39, 0xE5 };
                        case EBP:
                            return new byte[] { 0x39, 0xED };
                        case ESI:
                            return new byte[] { 0x39, 0xF5 };
                        case EDI:
                            return new byte[] { 0x39, 0xFD };
                    }
                    throw new UnsupportedOperandException();

                case ESI:
                    switch (reg2)
                    {
                        case EAX:
                            return new byte[] { 0x39, 0xC6 };
                        case ECX:
                            return new byte[] { 0x39, 0xCE };
                        case EDX:
                            return new byte[] { 0x39, 0xD6 };
                        case EBX:
                            return new byte[] { 0x39, 0xDE };
                        case ESP:
                            return new byte[] { 0x39, 0xE6 };
                        case EBP:
                            return new byte[] { 0x39, 0xEE };
                        case ESI:
                            return new byte[] { 0x39, 0xF6 };
                        case EDI:
                            return new byte[] { 0x39, 0xFE };
                    }
                    throw new UnsupportedOperandException();

                case EDI:
                    switch (reg2)
                    {
                        case EAX:
                            return new byte[] { 0x39, 0xC7 };
                        case ECX:
                            return new byte[] { 0x39, 0xCF };
                        case EDX:
                            return new byte[] { 0x39, 0xD7 };
                        case EBX:
                            return new byte[] { 0x39, 0xDF };
                        case ESP:
                            return new byte[] { 0x39, 0xE7 };
                        case EBP:
                            return new byte[] { 0x39, 0xEF };
                        case ESI:
                            return new byte[] { 0x39, 0xF7 };
                        case EDI:
                            return new byte[] { 0x39, 0xFF };
                    }
                    throw new UnsupportedOperandException();
            }
            throw new UnsupportedOperandException();
        }

        public static ValueOrAddress[] CMP(Register reg, Reference reference)
        {
            switch (reg)
            {
                case EAX:
                    return new ValueOrAddress[] {
                        new ValueOrAddress((byte)0x3B),
                        new ValueOrAddress((byte)0x05),
                        new ValueOrAddress(reference)
                        };
                case ECX:
                    return new ValueOrAddress[] {
                        new ValueOrAddress((byte)0x3B),
                        new ValueOrAddress((byte)0x0D),
                        new ValueOrAddress(reference)
                        };
                case EDX:
                    return new ValueOrAddress[] {
                        new ValueOrAddress((byte)0x3B),
                        new ValueOrAddress((byte)0x15),
                        new ValueOrAddress(reference)
                        };
                case EBX:
                    return new ValueOrAddress[] {
                        new ValueOrAddress((byte)0x3B),
                        new ValueOrAddress((byte)0x1D),
                        new ValueOrAddress(reference)
                        };
                case ESP:
                    return new ValueOrAddress[] {
                        new ValueOrAddress((byte)0x3B),
                        new ValueOrAddress((byte)0x25),
                        new ValueOrAddress(reference)
                        };
                case EBP:
                    return new ValueOrAddress[] {
                        new ValueOrAddress((byte)0x3B),
                        new ValueOrAddress((byte)0x2D),
                        new ValueOrAddress(reference)
                        };
                case ESI:
                    return new ValueOrAddress[] {
                        new ValueOrAddress((byte)0x3B),
                        new ValueOrAddress((byte)0x35),
                        new ValueOrAddress(reference)
                        };
                case EDI:
                    return new ValueOrAddress[] {
                        new ValueOrAddress((byte)0x3B),
                        new ValueOrAddress((byte)0x3D),
                        new ValueOrAddress(reference)
                        };
            }
            throw new UnsupportedOperandException();
        }

        public static ValueOrAddress[] CMP(Register reg, Register offsetReg, Reference reference)
        {
            switch (reg)
            {
                case EAX:
                    switch (offsetReg)
                    {
                        case EAX:
                            return new ValueOrAddress[] {
                                new ValueOrAddress((byte)0x3B),
                                new ValueOrAddress((byte)0x80),
                                new ValueOrAddress(reference)
                                };
                        case ECX:
                            return new ValueOrAddress[] {
                                new ValueOrAddress((byte)0x3B),
                                new ValueOrAddress((byte)0x81),
                                new ValueOrAddress(reference)
                                };
                        case EDX:
                            return new ValueOrAddress[] {
                                new ValueOrAddress((byte)0x3B),
                                new ValueOrAddress((byte)0x82),
                                new ValueOrAddress(reference)
                                };
                        case EBX:
                            return new ValueOrAddress[] {
                                new ValueOrAddress((byte)0x3B),
                                new ValueOrAddress((byte)0x83),
                                new ValueOrAddress(reference)
                                };
                        case ESP:
                            return new ValueOrAddress[] {
                                new ValueOrAddress((byte)0x3B),
                                new ValueOrAddress((byte)0x84),
                                new ValueOrAddress((byte)0x24),
                                new ValueOrAddress(reference)
                                };
                        case EBP:
                            return new ValueOrAddress[] {
                                new ValueOrAddress((byte)0x3B),
                                new ValueOrAddress((byte)0x85),
                                new ValueOrAddress(reference)
                                };
                        case ESI:
                            return new ValueOrAddress[] {
                                new ValueOrAddress((byte)0x3B),
                                new ValueOrAddress((byte)0x86),
                                new ValueOrAddress(reference)
                                };
                        case EDI:
                            return new ValueOrAddress[] {
                                new ValueOrAddress((byte)0x3B),
                                new ValueOrAddress((byte)0x87),
                                new ValueOrAddress(reference)
                                };
                    }
                    throw new UnsupportedOperandException();
                case ECX:
                    switch (offsetReg)
                    {
                        case EAX:
                            return new ValueOrAddress[] {
                                new ValueOrAddress((byte)0x3B),
                                new ValueOrAddress((byte)0x88),
                                new ValueOrAddress(reference)
                                };
                        case ECX:
                            return new ValueOrAddress[] {
                                new ValueOrAddress((byte)0x3B),
                                new ValueOrAddress((byte)0x89),
                                new ValueOrAddress(reference)
                                };
                        case EDX:
                            return new ValueOrAddress[] {
                                new ValueOrAddress((byte)0x3B),
                                new ValueOrAddress((byte)0x8A),
                                new ValueOrAddress(reference)
                                };
                        case EBX:
                            return new ValueOrAddress[] {
                                new ValueOrAddress((byte)0x3B),
                                new ValueOrAddress((byte)0x8B),
                                new ValueOrAddress(reference)
                                };
                        case ESP:
                            return new ValueOrAddress[] {
                                new ValueOrAddress((byte)0x3B),
                                new ValueOrAddress((byte)0x8C),
                                new ValueOrAddress((byte)0x24),
                                new ValueOrAddress(reference)
                                };
                        case EBP:
                            return new ValueOrAddress[] {
                                new ValueOrAddress((byte)0x3B),
                                new ValueOrAddress((byte)0x8D),
                                new ValueOrAddress(reference)
                                };
                        case ESI:
                            return new ValueOrAddress[] {
                                new ValueOrAddress((byte)0x3B),
                                new ValueOrAddress((byte)0x8E),
                                new ValueOrAddress(reference)
                                };
                        case EDI:
                            return new ValueOrAddress[] {
                                new ValueOrAddress((byte)0x3B),
                                new ValueOrAddress((byte)0x8F),
                                new ValueOrAddress(reference)
                                };
                    }
                    throw new UnsupportedOperandException();
                case EDX:
                    switch (offsetReg)
                    {
                        case EAX:
                            return new ValueOrAddress[] {
                                new ValueOrAddress((byte)0x3B),
                                new ValueOrAddress((byte)0x90),
                                new ValueOrAddress(reference)
                                };
                        case ECX:
                            return new ValueOrAddress[] {
                                new ValueOrAddress((byte)0x3B),
                                new ValueOrAddress((byte)0x91),
                                new ValueOrAddress(reference)
                                };
                        case EDX:
                            return new ValueOrAddress[] {
                                new ValueOrAddress((byte)0x3B),
                                new ValueOrAddress((byte)0x92),
                                new ValueOrAddress(reference)
                                };
                        case EBX:
                            return new ValueOrAddress[] {
                                new ValueOrAddress((byte)0x3B),
                                new ValueOrAddress((byte)0x93),
                                new ValueOrAddress(reference)
                                };
                        case ESP:
                            return new ValueOrAddress[] {
                                new ValueOrAddress((byte)0x3B),
                                new ValueOrAddress((byte)0x94),
                                new ValueOrAddress((byte)0x24),
                                new ValueOrAddress(reference)
                                };
                        case EBP:
                            return new ValueOrAddress[] {
                                new ValueOrAddress((byte)0x3B),
                                new ValueOrAddress((byte)0x95),
                                new ValueOrAddress(reference)
                                };
                        case ESI:
                            return new ValueOrAddress[] {
                                new ValueOrAddress((byte)0x3B),
                                new ValueOrAddress((byte)0x96),
                                new ValueOrAddress(reference)
                                };
                        case EDI:
                            return new ValueOrAddress[] {
                                new ValueOrAddress((byte)0x3B),
                                new ValueOrAddress((byte)0x97),
                                new ValueOrAddress(reference)
                                };
                    }
                    throw new UnsupportedOperandException();
                case EBX:
                    switch (offsetReg)
                    {
                        case EAX:
                            return new ValueOrAddress[] {
                                new ValueOrAddress((byte)0x3B),
                                new ValueOrAddress((byte)0x98),
                                new ValueOrAddress(reference)
                                };
                        case ECX:
                            return new ValueOrAddress[] {
                                new ValueOrAddress((byte)0x3B),
                                new ValueOrAddress((byte)0x99),
                                new ValueOrAddress(reference)
                                };
                        case EDX:
                            return new ValueOrAddress[] {
                                new ValueOrAddress((byte)0x3B),
                                new ValueOrAddress((byte)0x9A),
                                new ValueOrAddress(reference)
                                };
                        case EBX:
                            return new ValueOrAddress[] {
                                new ValueOrAddress((byte)0x3B),
                                new ValueOrAddress((byte)0x9B),
                                new ValueOrAddress(reference)
                                };
                        case ESP:
                            return new ValueOrAddress[] {
                                new ValueOrAddress((byte)0x3B),
                                new ValueOrAddress((byte)0x9C),
                                new ValueOrAddress((byte)0x24),
                                new ValueOrAddress(reference)
                                };
                        case EBP:
                            return new ValueOrAddress[] {
                                new ValueOrAddress((byte)0x3B),
                                new ValueOrAddress((byte)0x9D),
                                new ValueOrAddress(reference)
                                };
                        case ESI:
                            return new ValueOrAddress[] {
                                new ValueOrAddress((byte)0x3B),
                                new ValueOrAddress((byte)0x9E),
                                new ValueOrAddress(reference)
                                };
                        case EDI:
                            return new ValueOrAddress[] {
                                new ValueOrAddress((byte)0x3B),
                                new ValueOrAddress((byte)0x9F),
                                new ValueOrAddress(reference)
                                };
                    }
                    throw new UnsupportedOperandException();
                case ESP:
                    switch (offsetReg)
                    {
                        case EAX:
                            return new ValueOrAddress[] {
                                new ValueOrAddress((byte)0x3B),
                                new ValueOrAddress((byte)0xA0),
                                new ValueOrAddress(reference)
                                };
                        case ECX:
                            return new ValueOrAddress[] {
                                new ValueOrAddress((byte)0x3B),
                                new ValueOrAddress((byte)0xA1),
                                new ValueOrAddress(reference)
                                };
                        case EDX:
                            return new ValueOrAddress[] {
                                new ValueOrAddress((byte)0x3B),
                                new ValueOrAddress((byte)0xA2),
                                new ValueOrAddress(reference)
                                };
                        case EBX:
                            return new ValueOrAddress[] {
                                new ValueOrAddress((byte)0x3B),
                                new ValueOrAddress((byte)0xA3),
                                new ValueOrAddress(reference)
                                };
                        case ESP:
                            return new ValueOrAddress[] {
                                new ValueOrAddress((byte)0x3B),
                                new ValueOrAddress((byte)0xA4),
                                new ValueOrAddress((byte)0x24),
                                new ValueOrAddress(reference)
                                };
                        case EBP:
                            return new ValueOrAddress[] {
                                new ValueOrAddress((byte)0x3B),
                                new ValueOrAddress((byte)0xA5),
                                new ValueOrAddress(reference)
                                };
                        case ESI:
                            return new ValueOrAddress[] {
                                new ValueOrAddress((byte)0x3B),
                                new ValueOrAddress((byte)0xA6),
                                new ValueOrAddress(reference)
                                };
                        case EDI:
                            return new ValueOrAddress[] {
                                new ValueOrAddress((byte)0x3B),
                                new ValueOrAddress((byte)0xA7),
                                new ValueOrAddress(reference)
                                };
                    }
                    throw new UnsupportedOperandException();
                case EBP:
                    switch (offsetReg)
                    {
                        case EAX:
                            return new ValueOrAddress[] {
                                new ValueOrAddress((byte)0x3B),
                                new ValueOrAddress((byte)0xA8),
                                new ValueOrAddress(reference)
                                };
                        case ECX:
                            return new ValueOrAddress[] {
                                new ValueOrAddress((byte)0x3B),
                                new ValueOrAddress((byte)0xA9),
                                new ValueOrAddress(reference)
                                };
                        case EDX:
                            return new ValueOrAddress[] {
                                new ValueOrAddress((byte)0x3B),
                                new ValueOrAddress((byte)0xAA),
                                new ValueOrAddress(reference)
                                };
                        case EBX:
                            return new ValueOrAddress[] {
                                new ValueOrAddress((byte)0x3B),
                                new ValueOrAddress((byte)0xAB),
                                new ValueOrAddress(reference)
                                };
                        case ESP:
                            return new ValueOrAddress[] {
                                new ValueOrAddress((byte)0x3B),
                                new ValueOrAddress((byte)0xAC),
                                new ValueOrAddress((byte)0x24),
                                new ValueOrAddress(reference)
                                };
                        case EBP:
                            return new ValueOrAddress[] {
                                new ValueOrAddress((byte)0x3B),
                                new ValueOrAddress((byte)0xAD),
                                new ValueOrAddress(reference)
                                };
                        case ESI:
                            return new ValueOrAddress[] {
                                new ValueOrAddress((byte)0x3B),
                                new ValueOrAddress((byte)0xAE),
                                new ValueOrAddress(reference)
                                };
                        case EDI:
                            return new ValueOrAddress[] {
                                new ValueOrAddress((byte)0x3B),
                                new ValueOrAddress((byte)0xAF),
                                new ValueOrAddress(reference)
                                };
                    }
                    throw new UnsupportedOperandException();
                case ESI:
                    switch (offsetReg)
                    {
                        case EAX:
                            return new ValueOrAddress[] {
                                new ValueOrAddress((byte)0x3B),
                                new ValueOrAddress((byte)0xB0),
                                new ValueOrAddress(reference)
                                };
                        case ECX:
                            return new ValueOrAddress[] {
                                new ValueOrAddress((byte)0x3B),
                                new ValueOrAddress((byte)0xB1),
                                new ValueOrAddress(reference)
                                };
                        case EDX:
                            return new ValueOrAddress[] {
                                new ValueOrAddress((byte)0x3B),
                                new ValueOrAddress((byte)0xB2),
                                new ValueOrAddress(reference)
                                };
                        case EBX:
                            return new ValueOrAddress[] {
                                new ValueOrAddress((byte)0x3B),
                                new ValueOrAddress((byte)0xB3),
                                new ValueOrAddress(reference)
                                };
                        case ESP:
                            return new ValueOrAddress[] {
                                new ValueOrAddress((byte)0x3B),
                                new ValueOrAddress((byte)0xB4),
                                new ValueOrAddress((byte)0x24),
                                new ValueOrAddress(reference)
                                };
                        case EBP:
                            return new ValueOrAddress[] {
                                new ValueOrAddress((byte)0x3B),
                                new ValueOrAddress((byte)0xB5),
                                new ValueOrAddress(reference)
                                };
                        case ESI:
                            return new ValueOrAddress[] {
                                new ValueOrAddress((byte)0x3B),
                                new ValueOrAddress((byte)0xB6),
                                new ValueOrAddress(reference)
                                };
                        case EDI:
                            return new ValueOrAddress[] {
                                new ValueOrAddress((byte)0x3B),
                                new ValueOrAddress((byte)0xB7),
                                new ValueOrAddress(reference)
                                };
                    }
                    throw new UnsupportedOperandException();
                case EDI:
                    switch (offsetReg)
                    {
                        case EAX:
                            return new ValueOrAddress[] {
                                new ValueOrAddress((byte)0x3B),
                                new ValueOrAddress((byte)0xB8),
                                new ValueOrAddress(reference)
                                };
                        case ECX:
                            return new ValueOrAddress[] {
                                new ValueOrAddress((byte)0x3B),
                                new ValueOrAddress((byte)0xB9),
                                new ValueOrAddress(reference)
                                };
                        case EDX:
                            return new ValueOrAddress[] {
                                new ValueOrAddress((byte)0x3B),
                                new ValueOrAddress((byte)0xBA),
                                new ValueOrAddress(reference)
                                };
                        case EBX:
                            return new ValueOrAddress[] {
                                new ValueOrAddress((byte)0x3B),
                                new ValueOrAddress((byte)0xBB),
                                new ValueOrAddress(reference)
                                };
                        case ESP:
                            return new ValueOrAddress[] {
                                new ValueOrAddress((byte)0x3B),
                                new ValueOrAddress((byte)0xBC),
                                new ValueOrAddress((byte)0x24),
                                new ValueOrAddress(reference)
                                };
                        case EBP:
                            return new ValueOrAddress[] {
                                new ValueOrAddress((byte)0x3B),
                                new ValueOrAddress((byte)0xBD),
                                new ValueOrAddress(reference)
                                };
                        case ESI:
                            return new ValueOrAddress[] {
                                new ValueOrAddress((byte)0x3B),
                                new ValueOrAddress((byte)0xBE),
                                new ValueOrAddress(reference)
                                };
                        case EDI:
                            return new ValueOrAddress[] {
                                new ValueOrAddress((byte)0x3B),
                                new ValueOrAddress((byte)0xBF),
                                new ValueOrAddress(reference)
                                };
                    }
                    throw new UnsupportedOperandException();
            }
            throw new UnsupportedOperandException();
        }

        public static ValueOrAddress[] CMP(Register offsetReg, Reference reference, Register reg)
        {
            switch (reg)
            {
                case EAX:
                    switch (offsetReg)
                    {
                        case EAX:
                            return new ValueOrAddress[] {
                                new ValueOrAddress((byte)0x39),
                                new ValueOrAddress((byte)0x80),
                                new ValueOrAddress(reference)
                                };
                        case ECX:
                            return new ValueOrAddress[] {
                                new ValueOrAddress((byte)0x39),
                                new ValueOrAddress((byte)0x81),
                                new ValueOrAddress(reference)
                                };
                        case EDX:
                            return new ValueOrAddress[] {
                                new ValueOrAddress((byte)0x39),
                                new ValueOrAddress((byte)0x82),
                                new ValueOrAddress(reference)
                                };
                        case EBX:
                            return new ValueOrAddress[] {
                                new ValueOrAddress((byte)0x39),
                                new ValueOrAddress((byte)0x83),
                                new ValueOrAddress(reference)
                                };
                        case ESP:
                            return new ValueOrAddress[] {
                                new ValueOrAddress((byte)0x39),
                                new ValueOrAddress((byte)0x84),
                                new ValueOrAddress((byte)0x24),
                                new ValueOrAddress(reference)
                                };
                        case EBP:
                            return new ValueOrAddress[] {
                                new ValueOrAddress((byte)0x39),
                                new ValueOrAddress((byte)0x85),
                                new ValueOrAddress(reference)
                                };
                        case ESI:
                            return new ValueOrAddress[] {
                                new ValueOrAddress((byte)0x39),
                                new ValueOrAddress((byte)0x86),
                                new ValueOrAddress(reference)
                                };
                        case EDI:
                            return new ValueOrAddress[] {
                                new ValueOrAddress((byte)0x39),
                                new ValueOrAddress((byte)0x87),
                                new ValueOrAddress(reference)
                                };
                    }
                    throw new UnsupportedOperandException();
                case ECX:
                    switch (offsetReg)
                    {
                        case EAX:
                            return new ValueOrAddress[] {
                                new ValueOrAddress((byte)0x39),
                                new ValueOrAddress((byte)0x88),
                                new ValueOrAddress(reference)
                                };
                        case ECX:
                            return new ValueOrAddress[] {
                                new ValueOrAddress((byte)0x39),
                                new ValueOrAddress((byte)0x89),
                                new ValueOrAddress(reference)
                                };
                        case EDX:
                            return new ValueOrAddress[] {
                                new ValueOrAddress((byte)0x39),
                                new ValueOrAddress((byte)0x8A),
                                new ValueOrAddress(reference)
                                };
                        case EBX:
                            return new ValueOrAddress[] {
                                new ValueOrAddress((byte)0x39),
                                new ValueOrAddress((byte)0x8B),
                                new ValueOrAddress(reference)
                                };
                        case ESP:
                            return new ValueOrAddress[] {
                                new ValueOrAddress((byte)0x39),
                                new ValueOrAddress((byte)0x8C),
                                new ValueOrAddress((byte)0x24),
                                new ValueOrAddress(reference)
                                };
                        case EBP:
                            return new ValueOrAddress[] {
                                new ValueOrAddress((byte)0x39),
                                new ValueOrAddress((byte)0x8D),
                                new ValueOrAddress(reference)
                                };
                        case ESI:
                            return new ValueOrAddress[] {
                                new ValueOrAddress((byte)0x39),
                                new ValueOrAddress((byte)0x8E),
                                new ValueOrAddress(reference)
                                };
                        case EDI:
                            return new ValueOrAddress[] {
                                new ValueOrAddress((byte)0x39),
                                new ValueOrAddress((byte)0x8F),
                                new ValueOrAddress(reference)
                                };
                    }
                    throw new UnsupportedOperandException();
                case EDX:
                    switch (offsetReg)
                    {
                        case EAX:
                            return new ValueOrAddress[] {
                                new ValueOrAddress((byte)0x39),
                                new ValueOrAddress((byte)0x90),
                                new ValueOrAddress(reference)
                                };
                        case ECX:
                            return new ValueOrAddress[] {
                                new ValueOrAddress((byte)0x39),
                                new ValueOrAddress((byte)0x91),
                                new ValueOrAddress(reference)
                                };
                        case EDX:
                            return new ValueOrAddress[] {
                                new ValueOrAddress((byte)0x39),
                                new ValueOrAddress((byte)0x92),
                                new ValueOrAddress(reference)
                                };
                        case EBX:
                            return new ValueOrAddress[] {
                                new ValueOrAddress((byte)0x39),
                                new ValueOrAddress((byte)0x93),
                                new ValueOrAddress(reference)
                                };
                        case ESP:
                            return new ValueOrAddress[] {
                                new ValueOrAddress((byte)0x39),
                                new ValueOrAddress((byte)0x94),
                                new ValueOrAddress((byte)0x24),
                                new ValueOrAddress(reference)
                                };
                        case EBP:
                            return new ValueOrAddress[] {
                                new ValueOrAddress((byte)0x39),
                                new ValueOrAddress((byte)0x95),
                                new ValueOrAddress(reference)
                                };
                        case ESI:
                            return new ValueOrAddress[] {
                                new ValueOrAddress((byte)0x39),
                                new ValueOrAddress((byte)0x96),
                                new ValueOrAddress(reference)
                                };
                        case EDI:
                            return new ValueOrAddress[] {
                                new ValueOrAddress((byte)0x39),
                                new ValueOrAddress((byte)0x97),
                                new ValueOrAddress(reference)
                                };
                    }
                    throw new UnsupportedOperandException();
                case EBX:
                    switch (offsetReg)
                    {
                        case EAX:
                            return new ValueOrAddress[] {
                                new ValueOrAddress((byte)0x39),
                                new ValueOrAddress((byte)0x98),
                                new ValueOrAddress(reference)
                                };
                        case ECX:
                            return new ValueOrAddress[] {
                                new ValueOrAddress((byte)0x39),
                                new ValueOrAddress((byte)0x99),
                                new ValueOrAddress(reference)
                                };
                        case EDX:
                            return new ValueOrAddress[] {
                                new ValueOrAddress((byte)0x39),
                                new ValueOrAddress((byte)0x9A),
                                new ValueOrAddress(reference)
                                };
                        case EBX:
                            return new ValueOrAddress[] {
                                new ValueOrAddress((byte)0x39),
                                new ValueOrAddress((byte)0x9B),
                                new ValueOrAddress(reference)
                                };
                        case ESP:
                            return new ValueOrAddress[] {
                                new ValueOrAddress((byte)0x39),
                                new ValueOrAddress((byte)0x9C),
                                new ValueOrAddress((byte)0x24),
                                new ValueOrAddress(reference)
                                };
                        case EBP:
                            return new ValueOrAddress[] {
                                new ValueOrAddress((byte)0x39),
                                new ValueOrAddress((byte)0x9D),
                                new ValueOrAddress(reference)
                                };
                        case ESI:
                            return new ValueOrAddress[] {
                                new ValueOrAddress((byte)0x39),
                                new ValueOrAddress((byte)0x9E),
                                new ValueOrAddress(reference)
                                };
                        case EDI:
                            return new ValueOrAddress[] {
                                new ValueOrAddress((byte)0x39),
                                new ValueOrAddress((byte)0x9F),
                                new ValueOrAddress(reference)
                                };
                    }
                    throw new UnsupportedOperandException();
                case ESP:
                    switch (offsetReg)
                    {
                        case EAX:
                            return new ValueOrAddress[] {
                                new ValueOrAddress((byte)0x39),
                                new ValueOrAddress((byte)0xA0),
                                new ValueOrAddress(reference)
                                };
                        case ECX:
                            return new ValueOrAddress[] {
                                new ValueOrAddress((byte)0x39),
                                new ValueOrAddress((byte)0xA1),
                                new ValueOrAddress(reference)
                                };
                        case EDX:
                            return new ValueOrAddress[] {
                                new ValueOrAddress((byte)0x39),
                                new ValueOrAddress((byte)0xA2),
                                new ValueOrAddress(reference)
                                };
                        case EBX:
                            return new ValueOrAddress[] {
                                new ValueOrAddress((byte)0x39),
                                new ValueOrAddress((byte)0xA3),
                                new ValueOrAddress(reference)
                                };
                        case ESP:
                            return new ValueOrAddress[] {
                                new ValueOrAddress((byte)0x39),
                                new ValueOrAddress((byte)0xA4),
                                new ValueOrAddress((byte)0x24),
                                new ValueOrAddress(reference)
                                };
                        case EBP:
                            return new ValueOrAddress[] {
                                new ValueOrAddress((byte)0x39),
                                new ValueOrAddress((byte)0xA5),
                                new ValueOrAddress(reference)
                                };
                        case ESI:
                            return new ValueOrAddress[] {
                                new ValueOrAddress((byte)0x39),
                                new ValueOrAddress((byte)0xA6),
                                new ValueOrAddress(reference)
                                };
                        case EDI:
                            return new ValueOrAddress[] {
                                new ValueOrAddress((byte)0x39),
                                new ValueOrAddress((byte)0xA7),
                                new ValueOrAddress(reference)
                                };
                    }
                    throw new UnsupportedOperandException();
                case EBP:
                    switch (offsetReg)
                    {
                        case EAX:
                            return new ValueOrAddress[] {
                                new ValueOrAddress((byte)0x39),
                                new ValueOrAddress((byte)0xA8),
                                new ValueOrAddress(reference)
                                };
                        case ECX:
                            return new ValueOrAddress[] {
                                new ValueOrAddress((byte)0x39),
                                new ValueOrAddress((byte)0xA9),
                                new ValueOrAddress(reference)
                                };
                        case EDX:
                            return new ValueOrAddress[] {
                                new ValueOrAddress((byte)0x39),
                                new ValueOrAddress((byte)0xAA),
                                new ValueOrAddress(reference)
                                };
                        case EBX:
                            return new ValueOrAddress[] {
                                new ValueOrAddress((byte)0x39),
                                new ValueOrAddress((byte)0xAB),
                                new ValueOrAddress(reference)
                                };
                        case ESP:
                            return new ValueOrAddress[] {
                                new ValueOrAddress((byte)0x39),
                                new ValueOrAddress((byte)0xAC),
                                new ValueOrAddress((byte)0x24),
                                new ValueOrAddress(reference)
                                };
                        case EBP:
                            return new ValueOrAddress[] {
                                new ValueOrAddress((byte)0x39),
                                new ValueOrAddress((byte)0xAD),
                                new ValueOrAddress(reference)
                                };
                        case ESI:
                            return new ValueOrAddress[] {
                                new ValueOrAddress((byte)0x39),
                                new ValueOrAddress((byte)0xAE),
                                new ValueOrAddress(reference)
                                };
                        case EDI:
                            return new ValueOrAddress[] {
                                new ValueOrAddress((byte)0x39),
                                new ValueOrAddress((byte)0xAF),
                                new ValueOrAddress(reference)
                                };
                    }
                    throw new UnsupportedOperandException();
                case ESI:
                    switch (offsetReg)
                    {
                        case EAX:
                            return new ValueOrAddress[] {
                                new ValueOrAddress((byte)0x39),
                                new ValueOrAddress((byte)0xB0),
                                new ValueOrAddress(reference)
                                };
                        case ECX:
                            return new ValueOrAddress[] {
                                new ValueOrAddress((byte)0x39),
                                new ValueOrAddress((byte)0xB1),
                                new ValueOrAddress(reference)
                                };
                        case EDX:
                            return new ValueOrAddress[] {
                                new ValueOrAddress((byte)0x39),
                                new ValueOrAddress((byte)0xB2),
                                new ValueOrAddress(reference)
                                };
                        case EBX:
                            return new ValueOrAddress[] {
                                new ValueOrAddress((byte)0x39),
                                new ValueOrAddress((byte)0xB3),
                                new ValueOrAddress(reference)
                                };
                        case ESP:
                            return new ValueOrAddress[] {
                                new ValueOrAddress((byte)0x39),
                                new ValueOrAddress((byte)0xB4),
                                new ValueOrAddress((byte)0x24),
                                new ValueOrAddress(reference)
                                };
                        case EBP:
                            return new ValueOrAddress[] {
                                new ValueOrAddress((byte)0x39),
                                new ValueOrAddress((byte)0xB5),
                                new ValueOrAddress(reference)
                                };
                        case ESI:
                            return new ValueOrAddress[] {
                                new ValueOrAddress((byte)0x39),
                                new ValueOrAddress((byte)0xB6),
                                new ValueOrAddress(reference)
                                };
                        case EDI:
                            return new ValueOrAddress[] {
                                new ValueOrAddress((byte)0x39),
                                new ValueOrAddress((byte)0xB7),
                                new ValueOrAddress(reference)
                                };
                    }
                    throw new UnsupportedOperandException();
                case EDI:
                    switch (offsetReg)
                    {
                        case EAX:
                            return new ValueOrAddress[] {
                                new ValueOrAddress((byte)0x39),
                                new ValueOrAddress((byte)0xB8),
                                new ValueOrAddress(reference)
                                };
                        case ECX:
                            return new ValueOrAddress[] {
                                new ValueOrAddress((byte)0x39),
                                new ValueOrAddress((byte)0xB9),
                                new ValueOrAddress(reference)
                                };
                        case EDX:
                            return new ValueOrAddress[] {
                                new ValueOrAddress((byte)0x39),
                                new ValueOrAddress((byte)0xBA),
                                new ValueOrAddress(reference)
                                };
                        case EBX:
                            return new ValueOrAddress[] {
                                new ValueOrAddress((byte)0x39),
                                new ValueOrAddress((byte)0xBB),
                                new ValueOrAddress(reference)
                                };
                        case ESP:
                            return new ValueOrAddress[] {
                                new ValueOrAddress((byte)0x39),
                                new ValueOrAddress((byte)0xBC),
                                new ValueOrAddress((byte)0x24),
                                new ValueOrAddress(reference)
                                };
                        case EBP:
                            return new ValueOrAddress[] {
                                new ValueOrAddress((byte)0x39),
                                new ValueOrAddress((byte)0xBD),
                                new ValueOrAddress(reference)
                                };
                        case ESI:
                            return new ValueOrAddress[] {
                                new ValueOrAddress((byte)0x39),
                                new ValueOrAddress((byte)0xBE),
                                new ValueOrAddress(reference)
                                };
                        case EDI:
                            return new ValueOrAddress[] {
                                new ValueOrAddress((byte)0x39),
                                new ValueOrAddress((byte)0xBF),
                                new ValueOrAddress(reference)
                                };
                    }
                    throw new UnsupportedOperandException();
            }
            throw new UnsupportedOperandException();
        }

        public static ValueOrAddress[] CMP(Reference reference, Register reg)
        {
            switch (reg)
            {
                case EAX:
                    return new ValueOrAddress[] {
                        new ValueOrAddress((byte)0x39),
                        new ValueOrAddress((byte)0x05),
                        new ValueOrAddress(reference)
                        };
                case ECX:
                    return new ValueOrAddress[] {
                        new ValueOrAddress((byte)0x39),
                        new ValueOrAddress((byte)0x0D),
                        new ValueOrAddress(reference)
                        };
                case EDX:
                    return new ValueOrAddress[] {
                        new ValueOrAddress((byte)0x39),
                        new ValueOrAddress((byte)0x15),
                        new ValueOrAddress(reference)
                        };
                case EBX:
                    return new ValueOrAddress[] {
                        new ValueOrAddress((byte)0x39),
                        new ValueOrAddress((byte)0x1D),
                        new ValueOrAddress(reference)
                        };
                case ESP:
                    return new ValueOrAddress[] {
                        new ValueOrAddress((byte)0x39),
                        new ValueOrAddress((byte)0x25),
                        new ValueOrAddress(reference)
                        };
                case EBP:
                    return new ValueOrAddress[] {
                        new ValueOrAddress((byte)0x39),
                        new ValueOrAddress((byte)0x2D),
                        new ValueOrAddress(reference)
                        };
                case ESI:
                    return new ValueOrAddress[] {
                        new ValueOrAddress((byte)0x39),
                        new ValueOrAddress((byte)0x35),
                        new ValueOrAddress(reference)
                        };
                case EDI:
                    return new ValueOrAddress[] {
                        new ValueOrAddress((byte)0x39),
                        new ValueOrAddress((byte)0x3D),
                        new ValueOrAddress(reference)
                        };
            }
            throw new UnsupportedOperandException();
        }

        public static ValueOrAddress[] CMP(Reference reference, Int32 value)
        {
            byte[] valueBytes = BitConverter.GetBytes(value);
            if (value <= SByte.MaxValue && value >= SByte.MinValue)
            {
                return new ValueOrAddress[] {
                        new ValueOrAddress((byte)0x83),
                        new ValueOrAddress((byte)0x3D),
                        new ValueOrAddress(reference),
                        new ValueOrAddress(valueBytes[0]),
                        new ValueOrAddress(valueBytes[1]),
                        };
            }
            else
            {
                return new ValueOrAddress[] {
                        new ValueOrAddress((byte)0x81),
                        new ValueOrAddress((byte)0x3D),
                        new ValueOrAddress(reference),
                        new ValueOrAddress(valueBytes[0]),
                        new ValueOrAddress(valueBytes[1]),
                        new ValueOrAddress(valueBytes[2]),
                        new ValueOrAddress(valueBytes[3]),
                        };
            }
        }

        public static byte[] CMP(Register reg, Register offsetReg, Int32 offsetValue)
        {
            if (offsetValue <= SByte.MaxValue && offsetValue >= SByte.MinValue)
            {
                return CMP(reg, offsetReg, (byte)offsetValue);
            }

            byte[] offsetValueBytes = BitConverter.GetBytes(offsetValue);
            switch (reg)
            {
                case EAX:
                    switch (offsetReg)
                    {
                        case EAX:
                            return new byte[] {
                                0x3B,
                                0x80,
                                offsetValueBytes[0],
                                offsetValueBytes[1],
                                offsetValueBytes[2],
                                offsetValueBytes[3]
                                };
                        case ECX:
                            return new byte[] {
                                0x3B,
                                0x81,
                                offsetValueBytes[0],
                                offsetValueBytes[1],
                                offsetValueBytes[2],
                                offsetValueBytes[3]
                                };
                        case EDX:
                            return new byte[] {
                                0x3B,
                                0x82,
                                offsetValueBytes[0],
                                offsetValueBytes[1],
                                offsetValueBytes[2],
                                offsetValueBytes[3]
                                };
                        case EBX:
                            return new byte[] {
                                0x3B,
                                0x83,
                                offsetValueBytes[0],
                                offsetValueBytes[1],
                                offsetValueBytes[2],
                                offsetValueBytes[3]
                                };
                        case ESP:
                            return new byte[] {
                                0x3B,
                                0x84,
                                0x24,
                                offsetValueBytes[0],
                                offsetValueBytes[1],
                                offsetValueBytes[2],
                                offsetValueBytes[3]
                                };
                        case EBP:
                            return new byte[] {
                                0x3B,
                                0x85,
                                offsetValueBytes[0],
                                offsetValueBytes[1],
                                offsetValueBytes[2],
                                offsetValueBytes[3]
                                };
                        case ESI:
                            return new byte[] {
                                0x3B,
                                0x86,
                                offsetValueBytes[0],
                                offsetValueBytes[1],
                                offsetValueBytes[2],
                                offsetValueBytes[3]
                                };
                        case EDI:
                            return new byte[] {
                                0x3B,
                                0x87,
                                offsetValueBytes[0],
                                offsetValueBytes[1],
                                offsetValueBytes[2],
                                offsetValueBytes[3]
                                };
                    }
                    throw new UnsupportedOperandException();
                case ECX:
                    switch (offsetReg)
                    {
                        case EAX:
                            return new byte[] {
                                0x3B,
                                0x88,
                                offsetValueBytes[0],
                                offsetValueBytes[1],
                                offsetValueBytes[2],
                                offsetValueBytes[3]
                                };
                        case ECX:
                            return new byte[] {
                                0x3B,
                                0x89,
                                offsetValueBytes[0],
                                offsetValueBytes[1],
                                offsetValueBytes[2],
                                offsetValueBytes[3]
                                };
                        case EDX:
                            return new byte[] {
                                0x3B,
                                0x8A,
                                offsetValueBytes[0],
                                offsetValueBytes[1],
                                offsetValueBytes[2],
                                offsetValueBytes[3]
                                };
                        case EBX:
                            return new byte[] {
                                0x3B,
                                0x8B,
                                offsetValueBytes[0],
                                offsetValueBytes[1],
                                offsetValueBytes[2],
                                offsetValueBytes[3]
                                };
                        case ESP:
                            return new byte[] {
                                0x3B,
                                0x8C,
                                0x24,
                                offsetValueBytes[0],
                                offsetValueBytes[1],
                                offsetValueBytes[2],
                                offsetValueBytes[3]
                                };
                        case EBP:
                            return new byte[] {
                                0x3B,
                                0x8D,
                                offsetValueBytes[0],
                                offsetValueBytes[1],
                                offsetValueBytes[2],
                                offsetValueBytes[3]
                                };
                        case ESI:
                            return new byte[] {
                                0x3B,
                                0x8E,
                                offsetValueBytes[0],
                                offsetValueBytes[1],
                                offsetValueBytes[2],
                                offsetValueBytes[3]
                                };
                        case EDI:
                            return new byte[] {
                                0x3B,
                                0x8F,
                                offsetValueBytes[0],
                                offsetValueBytes[1],
                                offsetValueBytes[2],
                                offsetValueBytes[3]
                                };
                    }
                    throw new UnsupportedOperandException();
                case EDX:
                    switch (offsetReg)
                    {
                        case EAX:
                            return new byte[] {
                                0x3B,
                                0x90,
                                offsetValueBytes[0],
                                offsetValueBytes[1],
                                offsetValueBytes[2],
                                offsetValueBytes[3]
                                };
                        case ECX:
                            return new byte[] {
                                0x3B,
                                0x91,
                                offsetValueBytes[0],
                                offsetValueBytes[1],
                                offsetValueBytes[2],
                                offsetValueBytes[3]
                                };
                        case EDX:
                            return new byte[] {
                                0x3B,
                                0x92,
                                offsetValueBytes[0],
                                offsetValueBytes[1],
                                offsetValueBytes[2],
                                offsetValueBytes[3]
                                };
                        case EBX:
                            return new byte[] {
                                0x3B,
                                0x93,
                                offsetValueBytes[0],
                                offsetValueBytes[1],
                                offsetValueBytes[2],
                                offsetValueBytes[3]
                                };
                        case ESP:
                            return new byte[] {
                                0x3B,
                                0x94,
                                0x24,
                                offsetValueBytes[0],
                                offsetValueBytes[1],
                                offsetValueBytes[2],
                                offsetValueBytes[3]
                                };
                        case EBP:
                            return new byte[] {
                                0x3B,
                                0x95,
                                offsetValueBytes[0],
                                offsetValueBytes[1],
                                offsetValueBytes[2],
                                offsetValueBytes[3]
                                };
                        case ESI:
                            return new byte[] {
                                0x3B,
                                0x96,
                                offsetValueBytes[0],
                                offsetValueBytes[1],
                                offsetValueBytes[2],
                                offsetValueBytes[3]
                                };
                        case EDI:
                            return new byte[] {
                                0x3B,
                                0x97,
                                offsetValueBytes[0],
                                offsetValueBytes[1],
                                offsetValueBytes[2],
                                offsetValueBytes[3]
                                };
                    }
                    throw new UnsupportedOperandException();
                case EBX:
                    switch (offsetReg)
                    {
                        case EAX:
                            return new byte[] {
                                0x3B,
                                0x98,
                                offsetValueBytes[0],
                                offsetValueBytes[1],
                                offsetValueBytes[2],
                                offsetValueBytes[3]
                                };
                        case ECX:
                            return new byte[] {
                                0x3B,
                                0x99,
                                offsetValueBytes[0],
                                offsetValueBytes[1],
                                offsetValueBytes[2],
                                offsetValueBytes[3]
                                };
                        case EDX:
                            return new byte[] {
                                0x3B,
                                0x9A,
                                offsetValueBytes[0],
                                offsetValueBytes[1],
                                offsetValueBytes[2],
                                offsetValueBytes[3]
                                };
                        case EBX:
                            return new byte[] {
                                0x3B,
                                0x9B,
                                offsetValueBytes[0],
                                offsetValueBytes[1],
                                offsetValueBytes[2],
                                offsetValueBytes[3]
                                };
                        case ESP:
                            return new byte[] {
                                0x3B,
                                0x9C,
                                0x24,
                                offsetValueBytes[0],
                                offsetValueBytes[1],
                                offsetValueBytes[2],
                                offsetValueBytes[3]
                                };
                        case EBP:
                            return new byte[] {
                                0x3B,
                                0x9D,
                                offsetValueBytes[0],
                                offsetValueBytes[1],
                                offsetValueBytes[2],
                                offsetValueBytes[3]
                                };
                        case ESI:
                            return new byte[] {
                                0x3B,
                                0x9E,
                                offsetValueBytes[0],
                                offsetValueBytes[1],
                                offsetValueBytes[2],
                                offsetValueBytes[3]
                                };
                        case EDI:
                            return new byte[] {
                                0x3B,
                                0x9F,
                                offsetValueBytes[0],
                                offsetValueBytes[1],
                                offsetValueBytes[2],
                                offsetValueBytes[3]
                                };
                    }
                    throw new UnsupportedOperandException();
                case ESP:
                    switch (offsetReg)
                    {
                        case EAX:
                            return new byte[] {
                                0x3B,
                                0xA0,
                                offsetValueBytes[0],
                                offsetValueBytes[1],
                                offsetValueBytes[2],
                                offsetValueBytes[3]
                                };
                        case ECX:
                            return new byte[] {
                                0x3B,
                                0xA1,
                                offsetValueBytes[0],
                                offsetValueBytes[1],
                                offsetValueBytes[2],
                                offsetValueBytes[3]
                                };
                        case EDX:
                            return new byte[] {
                                0x3B,
                                0xA2,
                                offsetValueBytes[0],
                                offsetValueBytes[1],
                                offsetValueBytes[2],
                                offsetValueBytes[3]
                                };
                        case EBX:
                            return new byte[] {
                                0x3B,
                                0xA3,
                                offsetValueBytes[0],
                                offsetValueBytes[1],
                                offsetValueBytes[2],
                                offsetValueBytes[3]
                                };
                        case ESP:
                            return new byte[] {
                                0x3B,
                                0xA4,
                                0x24,
                                offsetValueBytes[0],
                                offsetValueBytes[1],
                                offsetValueBytes[2],
                                offsetValueBytes[3]
                                };
                        case EBP:
                            return new byte[] {
                                0x3B,
                                0xA5,
                                offsetValueBytes[0],
                                offsetValueBytes[1],
                                offsetValueBytes[2],
                                offsetValueBytes[3]
                                };
                        case ESI:
                            return new byte[] {
                                0x3B,
                                0xA6,
                                offsetValueBytes[0],
                                offsetValueBytes[1],
                                offsetValueBytes[2],
                                offsetValueBytes[3]
                                };
                        case EDI:
                            return new byte[] {
                                0x3B,
                                0xA7,
                                offsetValueBytes[0],
                                offsetValueBytes[1],
                                offsetValueBytes[2],
                                offsetValueBytes[3]
                                };
                    }
                    throw new UnsupportedOperandException();
                case EBP:
                    switch (offsetReg)
                    {
                        case EAX:
                            return new byte[] {
                                0x3B,
                                0xA8,
                                offsetValueBytes[0],
                                offsetValueBytes[1],
                                offsetValueBytes[2],
                                offsetValueBytes[3]
                                };
                        case ECX:
                            return new byte[] {
                                0x3B,
                                0xA9,
                                offsetValueBytes[0],
                                offsetValueBytes[1],
                                offsetValueBytes[2],
                                offsetValueBytes[3]
                                };
                        case EDX:
                            return new byte[] {
                                0x3B,
                                0xAA,
                                offsetValueBytes[0],
                                offsetValueBytes[1],
                                offsetValueBytes[2],
                                offsetValueBytes[3]
                                };
                        case EBX:
                            return new byte[] {
                                0x3B,
                                0xAB,
                                offsetValueBytes[0],
                                offsetValueBytes[1],
                                offsetValueBytes[2],
                                offsetValueBytes[3]
                                };
                        case ESP:
                            return new byte[] {
                                0x3B,
                                0xAC,
                                0x24,
                                offsetValueBytes[0],
                                offsetValueBytes[1],
                                offsetValueBytes[2],
                                offsetValueBytes[3]
                                };
                        case EBP:
                            return new byte[] {
                                0x3B,
                                0xAD,
                                offsetValueBytes[0],
                                offsetValueBytes[1],
                                offsetValueBytes[2],
                                offsetValueBytes[3]
                                };
                        case ESI:
                            return new byte[] {
                                0x3B,
                                0xAE,
                                offsetValueBytes[0],
                                offsetValueBytes[1],
                                offsetValueBytes[2],
                                offsetValueBytes[3]
                                };
                        case EDI:
                            return new byte[] {
                                0x3B,
                                0xAF,
                                offsetValueBytes[0],
                                offsetValueBytes[1],
                                offsetValueBytes[2],
                                offsetValueBytes[3]
                                };
                    }
                    throw new UnsupportedOperandException();
                case ESI:
                    switch (offsetReg)
                    {
                        case EAX:
                            return new byte[] {
                                0x3B,
                                0xB0,
                                offsetValueBytes[0],
                                offsetValueBytes[1],
                                offsetValueBytes[2],
                                offsetValueBytes[3]
                                };
                        case ECX:
                            return new byte[] {
                                0x3B,
                                0xB1,
                                offsetValueBytes[0],
                                offsetValueBytes[1],
                                offsetValueBytes[2],
                                offsetValueBytes[3]
                                };
                        case EDX:
                            return new byte[] {
                                0x3B,
                                0xB2,
                                offsetValueBytes[0],
                                offsetValueBytes[1],
                                offsetValueBytes[2],
                                offsetValueBytes[3]
                                };
                        case EBX:
                            return new byte[] {
                                0x3B,
                                0xB3,
                                offsetValueBytes[0],
                                offsetValueBytes[1],
                                offsetValueBytes[2],
                                offsetValueBytes[3]
                                };
                        case ESP:
                            return new byte[] {
                                0x3B,
                                0xB4,
                                0x24,
                                offsetValueBytes[0],
                                offsetValueBytes[1],
                                offsetValueBytes[2],
                                offsetValueBytes[3]
                                };
                        case EBP:
                            return new byte[] {
                                0x3B,
                                0xB5,
                                offsetValueBytes[0],
                                offsetValueBytes[1],
                                offsetValueBytes[2],
                                offsetValueBytes[3]
                                };
                        case ESI:
                            return new byte[] {
                                0x3B,
                                0xB6,
                                offsetValueBytes[0],
                                offsetValueBytes[1],
                                offsetValueBytes[2],
                                offsetValueBytes[3]
                                };
                        case EDI:
                            return new byte[] {
                                0x3B,
                                0xB7,
                                offsetValueBytes[0],
                                offsetValueBytes[1],
                                offsetValueBytes[2],
                                offsetValueBytes[3]
                                };
                    }
                    throw new UnsupportedOperandException();
                case EDI:
                    switch (offsetReg)
                    {
                        case EAX:
                            return new byte[] {
                                0x3B,
                                0xB8,
                                offsetValueBytes[0],
                                offsetValueBytes[1],
                                offsetValueBytes[2],
                                offsetValueBytes[3]
                                };
                        case ECX:
                            return new byte[] {
                                0x3B,
                                0xB9,
                                offsetValueBytes[0],
                                offsetValueBytes[1],
                                offsetValueBytes[2],
                                offsetValueBytes[3]
                                };
                        case EDX:
                            return new byte[] {
                                0x3B,
                                0xBA,
                                offsetValueBytes[0],
                                offsetValueBytes[1],
                                offsetValueBytes[2],
                                offsetValueBytes[3]
                                };
                        case EBX:
                            return new byte[] {
                                0x3B,
                                0xBB,
                                offsetValueBytes[0],
                                offsetValueBytes[1],
                                offsetValueBytes[2],
                                offsetValueBytes[3]
                                };
                        case ESP:
                            return new byte[] {
                                0x3B,
                                0xBC,
                                0x24,
                                offsetValueBytes[0],
                                offsetValueBytes[1],
                                offsetValueBytes[2],
                                offsetValueBytes[3]
                                };
                        case EBP:
                            return new byte[] {
                                0x3B,
                                0xBD,
                                offsetValueBytes[0],
                                offsetValueBytes[1],
                                offsetValueBytes[2],
                                offsetValueBytes[3]
                                };
                        case ESI:
                            return new byte[] {
                                0x3B,
                                0xBE,
                                offsetValueBytes[0],
                                offsetValueBytes[1],
                                offsetValueBytes[2],
                                offsetValueBytes[3]
                                };
                        case EDI:
                            return new byte[] {
                                0x3B,
                                0xBF,
                                offsetValueBytes[0],
                                offsetValueBytes[1],
                                offsetValueBytes[2],
                                offsetValueBytes[3]
                                };
                    }
                    throw new UnsupportedOperandException();
            }
            throw new UnsupportedOperandException();
        }


        public static byte[] CMP(Register reg, Register offsetReg, byte offsetValue)
        {
            switch (reg)
            {
                case EAX:
                    switch (offsetReg)
                    {
                        case EAX:
                            return new byte[] {
                                0x3B,
                                0x80,
                                offsetValue
                                };
                        case ECX:
                            return new byte[] {
                                0x3B,
                                0x81,
                                offsetValue
                                };
                        case EDX:
                            return new byte[] {
                                0x3B,
                                0x82,
                                offsetValue
                                };
                        case EBX:
                            return new byte[] {
                                0x3B,
                                0x83,
                                offsetValue
                                };
                        case ESP:
                            return new byte[] {
                                0x3B,
                                0x84,
                                0x24,
                                offsetValue
                                };
                        case EBP:
                            return new byte[] {
                                0x3B,
                                0x85,
                                offsetValue
                                };
                        case ESI:
                            return new byte[] {
                                0x3B,
                                0x86,
                                offsetValue
                                };
                        case EDI:
                            return new byte[] {
                                0x3B,
                                0x87,
                                offsetValue
                                };
                    }
                    throw new UnsupportedOperandException();
                case ECX:
                    switch (offsetReg)
                    {
                        case EAX:
                            return new byte[] {
                                0x3B,
                                0x88,
                                offsetValue
                                };
                        case ECX:
                            return new byte[] {
                                0x3B,
                                0x89,
                                offsetValue
                                };
                        case EDX:
                            return new byte[] {
                                0x3B,
                                0x8A,
                                offsetValue
                                };
                        case EBX:
                            return new byte[] {
                                0x3B,
                                0x8B,
                                offsetValue
                                };
                        case ESP:
                            return new byte[] {
                                0x3B,
                                0x8C,
                                0x24,
                                offsetValue
                                };
                        case EBP:
                            return new byte[] {
                                0x3B,
                                0x8D,
                                offsetValue
                                };
                        case ESI:
                            return new byte[] {
                                0x3B,
                                0x8E,
                                offsetValue
                                };
                        case EDI:
                            return new byte[] {
                                0x3B,
                                0x8F,
                                offsetValue
                                };
                    }
                    throw new UnsupportedOperandException();
                case EDX:
                    switch (offsetReg)
                    {
                        case EAX:
                            return new byte[] {
                                0x3B,
                                0x90,
                                offsetValue
                                };
                        case ECX:
                            return new byte[] {
                                0x3B,
                                0x91,
                                offsetValue
                                };
                        case EDX:
                            return new byte[] {
                                0x3B,
                                0x92,
                                offsetValue
                                };
                        case EBX:
                            return new byte[] {
                                0x3B,
                                0x93,
                                offsetValue
                                };
                        case ESP:
                            return new byte[] {
                                0x3B,
                                0x94,
                                0x24,
                                offsetValue
                                };
                        case EBP:
                            return new byte[] {
                                0x3B,
                                0x95,
                                offsetValue
                                };
                        case ESI:
                            return new byte[] {
                                0x3B,
                                0x96,
                                offsetValue
                                };
                        case EDI:
                            return new byte[] {
                                0x3B,
                                0x97,
                                offsetValue
                                };
                    }
                    throw new UnsupportedOperandException();
                case EBX:
                    switch (offsetReg)
                    {
                        case EAX:
                            return new byte[] {
                                0x3B,
                                0x98,
                                offsetValue
                                };
                        case ECX:
                            return new byte[] {
                                0x3B,
                                0x99,
                                offsetValue
                                };
                        case EDX:
                            return new byte[] {
                                0x3B,
                                0x9A,
                                offsetValue
                                };
                        case EBX:
                            return new byte[] {
                                0x3B,
                                0x9B,
                                offsetValue
                                };
                        case ESP:
                            return new byte[] {
                                0x3B,
                                0x9C,
                                0x24,
                                offsetValue
                                };
                        case EBP:
                            return new byte[] {
                                0x3B,
                                0x9D,
                                offsetValue
                                };
                        case ESI:
                            return new byte[] {
                                0x3B,
                                0x9E,
                                offsetValue
                                };
                        case EDI:
                            return new byte[] {
                                0x3B,
                                0x9F,
                                offsetValue
                                };
                    }
                    throw new UnsupportedOperandException();
                case ESP:
                    switch (offsetReg)
                    {
                        case EAX:
                            return new byte[] {
                                0x3B,
                                0xA0,
                                offsetValue
                                };
                        case ECX:
                            return new byte[] {
                                0x3B,
                                0xA1,
                                offsetValue
                                };
                        case EDX:
                            return new byte[] {
                                0x3B,
                                0xA2,
                                offsetValue
                                };
                        case EBX:
                            return new byte[] {
                                0x3B,
                                0xA3,
                                offsetValue
                                };
                        case ESP:
                            return new byte[] {
                                0x3B,
                                0xA4,
                                0x24,
                                offsetValue
                                };
                        case EBP:
                            return new byte[] {
                                0x3B,
                                0xA5,
                                offsetValue
                                };
                        case ESI:
                            return new byte[] {
                                0x3B,
                                0xA6,
                                offsetValue
                                };
                        case EDI:
                            return new byte[] {
                                0x3B,
                                0xA7,
                                offsetValue
                                };
                    }
                    throw new UnsupportedOperandException();
                case EBP:
                    switch (offsetReg)
                    {
                        case EAX:
                            return new byte[] {
                                0x3B,
                                0xA8,
                                offsetValue
                                };
                        case ECX:
                            return new byte[] {
                                0x3B,
                                0xA9,
                                offsetValue
                                };
                        case EDX:
                            return new byte[] {
                                0x3B,
                                0xAA,
                                offsetValue
                                };
                        case EBX:
                            return new byte[] {
                                0x3B,
                                0xAB,
                                offsetValue
                                };
                        case ESP:
                            return new byte[] {
                                0x3B,
                                0xAC,
                                0x24,
                                offsetValue
                                };
                        case EBP:
                            return new byte[] {
                                0x3B,
                                0xAD,
                                offsetValue
                                };
                        case ESI:
                            return new byte[] {
                                0x3B,
                                0xAE,
                                offsetValue
                                };
                        case EDI:
                            return new byte[] {
                                0x3B,
                                0xAF,
                                offsetValue
                                };
                    }
                    throw new UnsupportedOperandException();
                case ESI:
                    switch (offsetReg)
                    {
                        case EAX:
                            return new byte[] {
                                0x3B,
                                0xB0,
                                offsetValue
                                };
                        case ECX:
                            return new byte[] {
                                0x3B,
                                0xB1,
                                offsetValue
                                };
                        case EDX:
                            return new byte[] {
                                0x3B,
                                0xB2,
                                offsetValue
                                };
                        case EBX:
                            return new byte[] {
                                0x3B,
                                0xB3,
                                offsetValue
                                };
                        case ESP:
                            return new byte[] {
                                0x3B,
                                0xB4,
                                0x24,
                                offsetValue
                                };
                        case EBP:
                            return new byte[] {
                                0x3B,
                                0xB5,
                                offsetValue
                                };
                        case ESI:
                            return new byte[] {
                                0x3B,
                                0xB6,
                                offsetValue
                                };
                        case EDI:
                            return new byte[] {
                                0x3B,
                                0xB7,
                                offsetValue
                                };
                    }
                    throw new UnsupportedOperandException();
                case EDI:
                    switch (offsetReg)
                    {
                        case EAX:
                            return new byte[] {
                                0x3B,
                                0xB8,
                                offsetValue
                                };
                        case ECX:
                            return new byte[] {
                                0x3B,
                                0xB9,
                                offsetValue
                                };
                        case EDX:
                            return new byte[] {
                                0x3B,
                                0xBA,
                                offsetValue
                                };
                        case EBX:
                            return new byte[] {
                                0x3B,
                                0xBB,
                                offsetValue
                                };
                        case ESP:
                            return new byte[] {
                                0x3B,
                                0xBC,
                                0x24,
                                offsetValue
                                };
                        case EBP:
                            return new byte[] {
                                0x3B,
                                0xBD,
                                offsetValue
                                };
                        case ESI:
                            return new byte[] {
                                0x3B,
                                0xBE,
                                offsetValue
                                };
                        case EDI:
                            return new byte[] {
                                0x3B,
                                0xBF,
                                offsetValue
                                };
                    }
                    throw new UnsupportedOperandException();
            }
            throw new UnsupportedOperandException();
        }


        public static byte[] CMP(Register offsetReg, Int32 offsetValue, Register reg)
        {
            if (offsetValue <= SByte.MaxValue && offsetValue >= SByte.MinValue)
            {
                return CMP(offsetReg, (byte)offsetValue, reg);
            }

            byte[] offsetValueBytes = BitConverter.GetBytes(offsetValue);
            switch (reg)
            {
                case EAX:
                    switch (offsetReg)
                    {
                        case EAX:
                            return new byte[] {
                                0x39,
                                0x80,
                                offsetValueBytes[0],
                                offsetValueBytes[1],
                                offsetValueBytes[2],
                                offsetValueBytes[3]
                                };
                        case ECX:
                            return new byte[] {
                                0x39,
                                0x81,
                                offsetValueBytes[0],
                                offsetValueBytes[1],
                                offsetValueBytes[2],
                                offsetValueBytes[3]
                                };
                        case EDX:
                            return new byte[] {
                                0x39,
                                0x82,
                                offsetValueBytes[0],
                                offsetValueBytes[1],
                                offsetValueBytes[2],
                                offsetValueBytes[3]
                                };
                        case EBX:
                            return new byte[] {
                                0x39,
                                0x83,
                                offsetValueBytes[0],
                                offsetValueBytes[1],
                                offsetValueBytes[2],
                                offsetValueBytes[3]
                                };
                        case ESP:
                            return new byte[] {
                                0x39,
                                0x84,
                                0x24,
                                offsetValueBytes[0],
                                offsetValueBytes[1],
                                offsetValueBytes[2],
                                offsetValueBytes[3]
                                };
                        case EBP:
                            return new byte[] {
                                0x39,
                                0x85,
                                offsetValueBytes[0],
                                offsetValueBytes[1],
                                offsetValueBytes[2],
                                offsetValueBytes[3]
                                };
                        case ESI:
                            return new byte[] {
                                0x39,
                                0x86,
                                offsetValueBytes[0],
                                offsetValueBytes[1],
                                offsetValueBytes[2],
                                offsetValueBytes[3]
                                };
                        case EDI:
                            return new byte[] {
                                0x39,
                                0x87,
                                offsetValueBytes[0],
                                offsetValueBytes[1],
                                offsetValueBytes[2],
                                offsetValueBytes[3]
                                };
                    }
                    throw new UnsupportedOperandException();
                case ECX:
                    switch (offsetReg)
                    {
                        case EAX:
                            return new byte[] {
                                0x39,
                                0x88,
                                offsetValueBytes[0],
                                offsetValueBytes[1],
                                offsetValueBytes[2],
                                offsetValueBytes[3]
                                };
                        case ECX:
                            return new byte[] {
                                0x39,
                                0x89,
                                offsetValueBytes[0],
                                offsetValueBytes[1],
                                offsetValueBytes[2],
                                offsetValueBytes[3]
                                };
                        case EDX:
                            return new byte[] {
                                0x39,
                                0x8A,
                                offsetValueBytes[0],
                                offsetValueBytes[1],
                                offsetValueBytes[2],
                                offsetValueBytes[3]
                                };
                        case EBX:
                            return new byte[] {
                                0x39,
                                0x8B,
                                offsetValueBytes[0],
                                offsetValueBytes[1],
                                offsetValueBytes[2],
                                offsetValueBytes[3]
                                };
                        case ESP:
                            return new byte[] {
                                0x39,
                                0x8C,
                                0x24,
                                offsetValueBytes[0],
                                offsetValueBytes[1],
                                offsetValueBytes[2],
                                offsetValueBytes[3]
                                };
                        case EBP:
                            return new byte[] {
                                0x39,
                                0x8D,
                                offsetValueBytes[0],
                                offsetValueBytes[1],
                                offsetValueBytes[2],
                                offsetValueBytes[3]
                                };
                        case ESI:
                            return new byte[] {
                                0x39,
                                0x8E,
                                offsetValueBytes[0],
                                offsetValueBytes[1],
                                offsetValueBytes[2],
                                offsetValueBytes[3]
                                };
                        case EDI:
                            return new byte[] {
                                0x39,
                                0x8F,
                                offsetValueBytes[0],
                                offsetValueBytes[1],
                                offsetValueBytes[2],
                                offsetValueBytes[3]
                                };
                    }
                    throw new UnsupportedOperandException();
                case EDX:
                    switch (offsetReg)
                    {
                        case EAX:
                            return new byte[] {
                                0x39,
                                0x90,
                                offsetValueBytes[0],
                                offsetValueBytes[1],
                                offsetValueBytes[2],
                                offsetValueBytes[3]
                                };
                        case ECX:
                            return new byte[] {
                                0x39,
                                0x91,
                                offsetValueBytes[0],
                                offsetValueBytes[1],
                                offsetValueBytes[2],
                                offsetValueBytes[3]
                                };
                        case EDX:
                            return new byte[] {
                                0x39,
                                0x92,
                                offsetValueBytes[0],
                                offsetValueBytes[1],
                                offsetValueBytes[2],
                                offsetValueBytes[3]
                                };
                        case EBX:
                            return new byte[] {
                                0x39,
                                0x93,
                                offsetValueBytes[0],
                                offsetValueBytes[1],
                                offsetValueBytes[2],
                                offsetValueBytes[3]
                                };
                        case ESP:
                            return new byte[] {
                                0x39,
                                0x94,
                                0x24,
                                offsetValueBytes[0],
                                offsetValueBytes[1],
                                offsetValueBytes[2],
                                offsetValueBytes[3]
                                };
                        case EBP:
                            return new byte[] {
                                0x39,
                                0x95,
                                offsetValueBytes[0],
                                offsetValueBytes[1],
                                offsetValueBytes[2],
                                offsetValueBytes[3]
                                };
                        case ESI:
                            return new byte[] {
                                0x39,
                                0x96,
                                offsetValueBytes[0],
                                offsetValueBytes[1],
                                offsetValueBytes[2],
                                offsetValueBytes[3]
                                };
                        case EDI:
                            return new byte[] {
                                0x39,
                                0x97,
                                offsetValueBytes[0],
                                offsetValueBytes[1],
                                offsetValueBytes[2],
                                offsetValueBytes[3]
                                };
                    }
                    throw new UnsupportedOperandException();
                case EBX:
                    switch (offsetReg)
                    {
                        case EAX:
                            return new byte[] {
                                0x39,
                                0x98,
                                offsetValueBytes[0],
                                offsetValueBytes[1],
                                offsetValueBytes[2],
                                offsetValueBytes[3]
                                };
                        case ECX:
                            return new byte[] {
                                0x39,
                                0x99,
                                offsetValueBytes[0],
                                offsetValueBytes[1],
                                offsetValueBytes[2],
                                offsetValueBytes[3]
                                };
                        case EDX:
                            return new byte[] {
                                0x39,
                                0x9A,
                                offsetValueBytes[0],
                                offsetValueBytes[1],
                                offsetValueBytes[2],
                                offsetValueBytes[3]
                                };
                        case EBX:
                            return new byte[] {
                                0x39,
                                0x9B,
                                offsetValueBytes[0],
                                offsetValueBytes[1],
                                offsetValueBytes[2],
                                offsetValueBytes[3]
                                };
                        case ESP:
                            return new byte[] {
                                0x39,
                                0x9C,
                                0x24,
                                offsetValueBytes[0],
                                offsetValueBytes[1],
                                offsetValueBytes[2],
                                offsetValueBytes[3]
                                };
                        case EBP:
                            return new byte[] {
                                0x39,
                                0x9D,
                                offsetValueBytes[0],
                                offsetValueBytes[1],
                                offsetValueBytes[2],
                                offsetValueBytes[3]
                                };
                        case ESI:
                            return new byte[] {
                                0x39,
                                0x9E,
                                offsetValueBytes[0],
                                offsetValueBytes[1],
                                offsetValueBytes[2],
                                offsetValueBytes[3]
                                };
                        case EDI:
                            return new byte[] {
                                0x39,
                                0x9F,
                                offsetValueBytes[0],
                                offsetValueBytes[1],
                                offsetValueBytes[2],
                                offsetValueBytes[3]
                                };
                    }
                    throw new UnsupportedOperandException();
                case ESP:
                    switch (offsetReg)
                    {
                        case EAX:
                            return new byte[] {
                                0x39,
                                0xA0,
                                offsetValueBytes[0],
                                offsetValueBytes[1],
                                offsetValueBytes[2],
                                offsetValueBytes[3]
                                };
                        case ECX:
                            return new byte[] {
                                0x39,
                                0xA1,
                                offsetValueBytes[0],
                                offsetValueBytes[1],
                                offsetValueBytes[2],
                                offsetValueBytes[3]
                                };
                        case EDX:
                            return new byte[] {
                                0x39,
                                0xA2,
                                offsetValueBytes[0],
                                offsetValueBytes[1],
                                offsetValueBytes[2],
                                offsetValueBytes[3]
                                };
                        case EBX:
                            return new byte[] {
                                0x39,
                                0xA3,
                                offsetValueBytes[0],
                                offsetValueBytes[1],
                                offsetValueBytes[2],
                                offsetValueBytes[3]
                                };
                        case ESP:
                            return new byte[] {
                                0x39,
                                0xA4,
                                0x24,
                                offsetValueBytes[0],
                                offsetValueBytes[1],
                                offsetValueBytes[2],
                                offsetValueBytes[3]
                                };
                        case EBP:
                            return new byte[] {
                                0x39,
                                0xA5,
                                offsetValueBytes[0],
                                offsetValueBytes[1],
                                offsetValueBytes[2],
                                offsetValueBytes[3]
                                };
                        case ESI:
                            return new byte[] {
                                0x39,
                                0xA6,
                                offsetValueBytes[0],
                                offsetValueBytes[1],
                                offsetValueBytes[2],
                                offsetValueBytes[3]
                                };
                        case EDI:
                            return new byte[] {
                                0x39,
                                0xA7,
                                offsetValueBytes[0],
                                offsetValueBytes[1],
                                offsetValueBytes[2],
                                offsetValueBytes[3]
                                };
                    }
                    throw new UnsupportedOperandException();
                case EBP:
                    switch (offsetReg)
                    {
                        case EAX:
                            return new byte[] {
                                0x39,
                                0xA8,
                                offsetValueBytes[0],
                                offsetValueBytes[1],
                                offsetValueBytes[2],
                                offsetValueBytes[3]
                                };
                        case ECX:
                            return new byte[] {
                                0x39,
                                0xA9,
                                offsetValueBytes[0],
                                offsetValueBytes[1],
                                offsetValueBytes[2],
                                offsetValueBytes[3]
                                };
                        case EDX:
                            return new byte[] {
                                0x39,
                                0xAA,
                                offsetValueBytes[0],
                                offsetValueBytes[1],
                                offsetValueBytes[2],
                                offsetValueBytes[3]
                                };
                        case EBX:
                            return new byte[] {
                                0x39,
                                0xAB,
                                offsetValueBytes[0],
                                offsetValueBytes[1],
                                offsetValueBytes[2],
                                offsetValueBytes[3]
                                };
                        case ESP:
                            return new byte[] {
                                0x39,
                                0xAC,
                                0x24,
                                offsetValueBytes[0],
                                offsetValueBytes[1],
                                offsetValueBytes[2],
                                offsetValueBytes[3]
                                };
                        case EBP:
                            return new byte[] {
                                0x39,
                                0xAD,
                                offsetValueBytes[0],
                                offsetValueBytes[1],
                                offsetValueBytes[2],
                                offsetValueBytes[3]
                                };
                        case ESI:
                            return new byte[] {
                                0x39,
                                0xAE,
                                offsetValueBytes[0],
                                offsetValueBytes[1],
                                offsetValueBytes[2],
                                offsetValueBytes[3]
                                };
                        case EDI:
                            return new byte[] {
                                0x39,
                                0xAF,
                                offsetValueBytes[0],
                                offsetValueBytes[1],
                                offsetValueBytes[2],
                                offsetValueBytes[3]
                                };
                    }
                    throw new UnsupportedOperandException();
                case ESI:
                    switch (offsetReg)
                    {
                        case EAX:
                            return new byte[] {
                                0x39,
                                0xB0,
                                offsetValueBytes[0],
                                offsetValueBytes[1],
                                offsetValueBytes[2],
                                offsetValueBytes[3]
                                };
                        case ECX:
                            return new byte[] {
                                0x39,
                                0xB1,
                                offsetValueBytes[0],
                                offsetValueBytes[1],
                                offsetValueBytes[2],
                                offsetValueBytes[3]
                                };
                        case EDX:
                            return new byte[] {
                                0x39,
                                0xB2,
                                offsetValueBytes[0],
                                offsetValueBytes[1],
                                offsetValueBytes[2],
                                offsetValueBytes[3]
                                };
                        case EBX:
                            return new byte[] {
                                0x39,
                                0xB3,
                                offsetValueBytes[0],
                                offsetValueBytes[1],
                                offsetValueBytes[2],
                                offsetValueBytes[3]
                                };
                        case ESP:
                            return new byte[] {
                                0x39,
                                0xB4,
                                0x24,
                                offsetValueBytes[0],
                                offsetValueBytes[1],
                                offsetValueBytes[2],
                                offsetValueBytes[3]
                                };
                        case EBP:
                            return new byte[] {
                                0x39,
                                0xB5,
                                offsetValueBytes[0],
                                offsetValueBytes[1],
                                offsetValueBytes[2],
                                offsetValueBytes[3]
                                };
                        case ESI:
                            return new byte[] {
                                0x39,
                                0xB6,
                                offsetValueBytes[0],
                                offsetValueBytes[1],
                                offsetValueBytes[2],
                                offsetValueBytes[3]
                                };
                        case EDI:
                            return new byte[] {
                                0x39,
                                0xB7,
                                offsetValueBytes[0],
                                offsetValueBytes[1],
                                offsetValueBytes[2],
                                offsetValueBytes[3]
                                };
                    }
                    throw new UnsupportedOperandException();
                case EDI:
                    switch (offsetReg)
                    {
                        case EAX:
                            return new byte[] {
                                0x39,
                                0xB8,
                                offsetValueBytes[0],
                                offsetValueBytes[1],
                                offsetValueBytes[2],
                                offsetValueBytes[3]
                                };
                        case ECX:
                            return new byte[] {
                                0x39,
                                0xB9,
                                offsetValueBytes[0],
                                offsetValueBytes[1],
                                offsetValueBytes[2],
                                offsetValueBytes[3]
                                };
                        case EDX:
                            return new byte[] {
                                0x39,
                                0xBA,
                                offsetValueBytes[0],
                                offsetValueBytes[1],
                                offsetValueBytes[2],
                                offsetValueBytes[3]
                                };
                        case EBX:
                            return new byte[] {
                                0x39,
                                0xBB,
                                offsetValueBytes[0],
                                offsetValueBytes[1],
                                offsetValueBytes[2],
                                offsetValueBytes[3]
                                };
                        case ESP:
                            return new byte[] {
                                0x39,
                                0xBC,
                                0x24,
                                offsetValueBytes[0],
                                offsetValueBytes[1],
                                offsetValueBytes[2],
                                offsetValueBytes[3]
                                };
                        case EBP:
                            return new byte[] {
                                0x39,
                                0xBD,
                                offsetValueBytes[0],
                                offsetValueBytes[1],
                                offsetValueBytes[2],
                                offsetValueBytes[3]
                                };
                        case ESI:
                            return new byte[] {
                                0x39,
                                0xBE,
                                offsetValueBytes[0],
                                offsetValueBytes[1],
                                offsetValueBytes[2],
                                offsetValueBytes[3]
                                };
                        case EDI:
                            return new byte[] {
                                0x39,
                                0xBF,
                                offsetValueBytes[0],
                                offsetValueBytes[1],
                                offsetValueBytes[2],
                                offsetValueBytes[3]
                                };
                    }
                    throw new UnsupportedOperandException();
            }
            throw new UnsupportedOperandException();
        }


        public static byte[] CMP(Register offsetReg, byte offsetValue, Register reg)
        {
            switch (reg)
            {
                case EAX:
                    switch (offsetReg)
                    {
                        case EAX:
                            return new byte[] {
                                0x39,
                                0x40,
                                offsetValue
                                };
                        case ECX:
                            return new byte[] {
                                0x39,
                                0x41,
                                offsetValue
                                };
                        case EDX:
                            return new byte[] {
                                0x39,
                                0x42,
                                offsetValue
                                };
                        case EBX:
                            return new byte[] {
                                0x39,
                                0x43,
                                offsetValue
                                };
                        case ESP:
                            return new byte[] {
                                0x39,
                                0x44,
                                0x24,
                                offsetValue
                                };
                        case EBP:
                            return new byte[] {
                                0x39,
                                0x45,
                                offsetValue
                                };
                        case ESI:
                            return new byte[] {
                                0x39,
                                0x46,
                                offsetValue
                                };
                        case EDI:
                            return new byte[] {
                                0x39,
                                0x47,
                                offsetValue
                                };
                    }
                    throw new UnsupportedOperandException();
                case ECX:
                    switch (offsetReg)
                    {
                        case EAX:
                            return new byte[] {
                                0x39,
                                0x48,
                                offsetValue
                                };
                        case ECX:
                            return new byte[] {
                                0x39,
                                0x49,
                                offsetValue
                                };
                        case EDX:
                            return new byte[] {
                                0x39,
                                0x4A,
                                offsetValue
                                };
                        case EBX:
                            return new byte[] {
                                0x39,
                                0x4B,
                                offsetValue
                                };
                        case ESP:
                            return new byte[] {
                                0x39,
                                0x4C,
                                0x24,
                                offsetValue
                                };
                        case EBP:
                            return new byte[] {
                                0x39,
                                0x4D,
                                offsetValue
                                };
                        case ESI:
                            return new byte[] {
                                0x39,
                                0x4E,
                                offsetValue
                                };
                        case EDI:
                            return new byte[] {
                                0x39,
                                0x4F,
                                offsetValue
                                };
                    }
                    throw new UnsupportedOperandException();
                case EDX:
                    switch (offsetReg)
                    {
                        case EAX:
                            return new byte[] {
                                0x39,
                                0x50,
                                offsetValue
                                };
                        case ECX:
                            return new byte[] {
                                0x39,
                                0x51,
                                offsetValue
                                };
                        case EDX:
                            return new byte[] {
                                0x39,
                                0x52,
                                offsetValue
                                };
                        case EBX:
                            return new byte[] {
                                0x39,
                                0x53,
                                offsetValue
                                };
                        case ESP:
                            return new byte[] {
                                0x39,
                                0x54,
                                0x24,
                                offsetValue
                                };
                        case EBP:
                            return new byte[] {
                                0x39,
                                0x55,
                                offsetValue
                                };
                        case ESI:
                            return new byte[] {
                                0x39,
                                0x56,
                                offsetValue
                                };
                        case EDI:
                            return new byte[] {
                                0x39,
                                0x57,
                                offsetValue
                                };
                    }
                    throw new UnsupportedOperandException();
                case EBX:
                    switch (offsetReg)
                    {
                        case EAX:
                            return new byte[] {
                                0x39,
                                0x58,
                                offsetValue
                                };
                        case ECX:
                            return new byte[] {
                                0x39,
                                0x59,
                                offsetValue
                                };
                        case EDX:
                            return new byte[] {
                                0x39,
                                0x5A,
                                offsetValue
                                };
                        case EBX:
                            return new byte[] {
                                0x39,
                                0x5B,
                                offsetValue
                                };
                        case ESP:
                            return new byte[] {
                                0x39,
                                0x5C,
                                0x24,
                                offsetValue
                                };
                        case EBP:
                            return new byte[] {
                                0x39,
                                0x5D,
                                offsetValue
                                };
                        case ESI:
                            return new byte[] {
                                0x39,
                                0x5E,
                                offsetValue
                                };
                        case EDI:
                            return new byte[] {
                                0x39,
                                0x5F,
                                offsetValue
                                };
                    }
                    throw new UnsupportedOperandException();
                case ESP:
                    switch (offsetReg)
                    {
                        case EAX:
                            return new byte[] {
                                0x39,
                                0x60,
                                offsetValue
                                };
                        case ECX:
                            return new byte[] {
                                0x39,
                                0x61,
                                offsetValue
                                };
                        case EDX:
                            return new byte[] {
                                0x39,
                                0x62,
                                offsetValue
                                };
                        case EBX:
                            return new byte[] {
                                0x39,
                                0x63,
                                offsetValue
                                };
                        case ESP:
                            return new byte[] {
                                0x39,
                                0x64,
                                0x24,
                                offsetValue
                                };
                        case EBP:
                            return new byte[] {
                                0x39,
                                0x65,
                                offsetValue
                                };
                        case ESI:
                            return new byte[] {
                                0x39,
                                0x66,
                                offsetValue
                                };
                        case EDI:
                            return new byte[] {
                                0x39,
                                0x67,
                                offsetValue
                                };
                    }
                    throw new UnsupportedOperandException();
                case EBP:
                    switch (offsetReg)
                    {
                        case EAX:
                            return new byte[] {
                                0x39,
                                0x68,
                                offsetValue
                                };
                        case ECX:
                            return new byte[] {
                                0x39,
                                0x69,
                                offsetValue
                                };
                        case EDX:
                            return new byte[] {
                                0x39,
                                0x6A,
                                offsetValue
                                };
                        case EBX:
                            return new byte[] {
                                0x39,
                                0x6B,
                                offsetValue
                                };
                        case ESP:
                            return new byte[] {
                                0x39,
                                0x6C,
                                0x24,
                                offsetValue
                                };
                        case EBP:
                            return new byte[] {
                                0x39,
                                0x6D,
                                offsetValue
                                };
                        case ESI:
                            return new byte[] {
                                0x39,
                                0x6E,
                                offsetValue
                                };
                        case EDI:
                            return new byte[] {
                                0x39,
                                0x6F,
                                offsetValue
                                };
                    }
                    throw new UnsupportedOperandException();
                case ESI:
                    switch (offsetReg)
                    {
                        case EAX:
                            return new byte[] {
                                0x39,
                                0x70,
                                offsetValue
                                };
                        case ECX:
                            return new byte[] {
                                0x39,
                                0x71,
                                offsetValue
                                };
                        case EDX:
                            return new byte[] {
                                0x39,
                                0x72,
                                offsetValue
                                };
                        case EBX:
                            return new byte[] {
                                0x39,
                                0x73,
                                offsetValue
                                };
                        case ESP:
                            return new byte[] {
                                0x39,
                                0x74,
                                0x24,
                                offsetValue
                                };
                        case EBP:
                            return new byte[] {
                                0x39,
                                0x75,
                                offsetValue
                                };
                        case ESI:
                            return new byte[] {
                                0x39,
                                0x76,
                                offsetValue
                                };
                        case EDI:
                            return new byte[] {
                                0x39,
                                0x77,
                                offsetValue
                                };
                    }
                    throw new UnsupportedOperandException();
                case EDI:
                    switch (offsetReg)
                    {
                        case EAX:
                            return new byte[] {
                                0x39,
                                0x78,
                                offsetValue
                                };
                        case ECX:
                            return new byte[] {
                                0x39,
                                0x79,
                                offsetValue
                                };
                        case EDX:
                            return new byte[] {
                                0x39,
                                0x7A,
                                offsetValue
                                };
                        case EBX:
                            return new byte[] {
                                0x39,
                                0x7B,
                                offsetValue
                                };
                        case ESP:
                            return new byte[] {
                                0x39,
                                0x7C,
                                0x24,
                                offsetValue
                                };
                        case EBP:
                            return new byte[] {
                                0x39,
                                0x7D,
                                offsetValue
                                };
                        case ESI:
                            return new byte[] {
                                0x39,
                                0x7E,
                                offsetValue
                                };
                        case EDI:
                            return new byte[] {
                                0x39,
                                0x7F,
                                offsetValue
                                };
                    }
                    throw new UnsupportedOperandException();
            }
            throw new UnsupportedOperandException();
        }
    }
}
