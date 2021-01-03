using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using static UCP.Patching.BinElements.Register;

namespace UCP.Patching.BinElements
{
    public partial class OpCodes
    {
        public static byte[] PUSH(byte[] instruction)
        {
            return instruction;
        }

        public static byte[] PUSH(Register reg, byte offsetValue)
        {
            switch (reg)
            {
                case EAX:
                    return new byte[] {
                        0xFF,
                        0x70,
                        (byte)offsetValue
                        };
                case ECX:
                    return new byte[] {
                        0xFF,
                        0x71,
                        (byte)offsetValue
                        };
                case EDX:
                    return new byte[] {
                        0xFF,
                        0x72,
                        (byte)offsetValue
                        };
                case EBX:
                    return new byte[] {
                        0xFF,
                        0x73,
                        (byte)offsetValue
                        };
                case ESP:
                    return new byte[] {
                        0xFF,
                        0x74,
                        0x24,
                        (byte)offsetValue
                        };
                case EBP:
                    return new byte[] {
                        0xFF,
                        0x75,
                        (byte)offsetValue
                        };
                case ESI:
                    return new byte[] {
                        0xFF,
                        0x76,
                        (byte)offsetValue
                        };
                case EDI:
                    return new byte[] {
                        0xFF,
                        0x77,
                        (byte)offsetValue
                        };
            }
            throw new UnsupportedOperandException();
        }

        public static byte[] PUSH(Register reg, Int32 offsetValue)
        {
            if (offsetValue <= SByte.MaxValue && offsetValue >= SByte.MinValue)
            {
                return PUSH(reg, (byte)offsetValue);
            }
            byte[] offsetValueBytes = BitConverter.GetBytes(offsetValue);
            switch (reg)
            {
                case EAX:
                    return new byte[] {
                        0xFF,
                        0xB0,
                        offsetValueBytes[0],
                        offsetValueBytes[1],
                        offsetValueBytes[2],
                        offsetValueBytes[3],
                        };
                case ECX:
                    return new byte[] {
                        0xFF,
                        0xB1,
                        offsetValueBytes[0],
                        offsetValueBytes[1],
                        offsetValueBytes[2],
                        offsetValueBytes[3],
                        };
                case EDX:
                    return new byte[] {
                        0xFF,
                        0xB2,
                        offsetValueBytes[0],
                        offsetValueBytes[1],
                        offsetValueBytes[2],
                        offsetValueBytes[3],
                        };
                case EBX:
                    return new byte[] {
                        0xFF,
                        0xB3,
                        offsetValueBytes[0],
                        offsetValueBytes[1],
                        offsetValueBytes[2],
                        offsetValueBytes[3],
                        };
                case ESP:
                    return new byte[] {
                        0xFF,
                        0xB4,
                        0x24,
                        offsetValueBytes[0],
                        offsetValueBytes[1],
                        offsetValueBytes[2],
                        offsetValueBytes[3],
                        };
                case EBP:
                    return new byte[] {
                        0xFF,
                        0xB5,
                        offsetValueBytes[0],
                        offsetValueBytes[1],
                        offsetValueBytes[2],
                        offsetValueBytes[3],
                        };
                case ESI:
                    return new byte[] {
                        0xFF,
                        0xB6,
                        offsetValueBytes[0],
                        offsetValueBytes[1],
                        offsetValueBytes[2],
                        offsetValueBytes[3],
                        };
                case EDI:
                    return new byte[] {
                        0xFF,
                        0xB7,
                        offsetValueBytes[0],
                        offsetValueBytes[1],
                        offsetValueBytes[2],
                        offsetValueBytes[3],
                        };
            }
            throw new UnsupportedOperandException();
        }

        public static ValueOrAddress[] PUSH(Register offsetReg, Reference reference)
        {
            switch (offsetReg)
            {
                case EAX:
                    return new ValueOrAddress[] {
                        new ValueOrAddress((byte)0xFF),
                        new ValueOrAddress((byte)0xB0),
                        new ValueOrAddress(reference)
                        };
                case ECX:
                    return new ValueOrAddress[] {
                        new ValueOrAddress((byte)0xFF),
                        new ValueOrAddress((byte)0xB1),
                        new ValueOrAddress(reference)
                        };
                case EDX:
                    return new ValueOrAddress[] {
                        new ValueOrAddress((byte)0xFF),
                        new ValueOrAddress((byte)0xB2),
                        new ValueOrAddress(reference)
                        };
                case EBX:
                    return new ValueOrAddress[] {
                        new ValueOrAddress((byte)0xFF),
                        new ValueOrAddress((byte)0xB3),
                        new ValueOrAddress(reference)
                        };
                case ESP:
                    return new ValueOrAddress[] {
                        new ValueOrAddress((byte)0xFF),
                        new ValueOrAddress((byte)0xB4),
                        new ValueOrAddress((byte)0x24),
                        new ValueOrAddress(reference)
                        };
                case EBP:
                    return new ValueOrAddress[] {
                        new ValueOrAddress((byte)0xFF),
                        new ValueOrAddress((byte)0xB5),
                        new ValueOrAddress(reference)
                        };
                case ESI:
                    return new ValueOrAddress[] {
                        new ValueOrAddress((byte)0xFF),
                        new ValueOrAddress((byte)0xB6),
                        new ValueOrAddress(reference)
                        };
                case EDI:
                    return new ValueOrAddress[] {
                        new ValueOrAddress((byte)0xFF),
                        new ValueOrAddress((byte)0xB7),
                        new ValueOrAddress(reference)
                        };
            }
            throw new UnsupportedOperandException();
        }

        public static ValueOrAddress[] PUSH(Reference reference)
        {
            return new ValueOrAddress[]{
                new ValueOrAddress((byte)0xFF),
                new ValueOrAddress((byte)0x35),
                new ValueOrAddress(reference)
            };
        }

        public static byte[] PUSH(sbyte val)
        {
            if (val > 0)
            {
                return new byte[] { 0x6A, (byte)val };
            }
            else
            {
                return new byte[] { 0x68, (byte)Math.Abs(val) };
            }
        }

        public static byte[] PUSH(Int32 val)
        {
            if (val <= SByte.MaxValue && val >= SByte.MinValue)
            {
                return PUSH((sbyte)val);
            }
            if (val > 0x80)
            {
                return (new byte[] { 0x68 }).Concat(BitConverter.GetBytes(val)).ToArray();
            }
            else
            {
                return (new byte[] { 0x68 }).Concat(BitConverter.GetBytes(0xFFFFFFFF + val - 1)).ToArray();
            }
        }

        public static byte[] PUSH(Register reg)
        {
            switch (reg)
            {
                case EAX:
                    return new byte[] { 0x50 };
                case ECX:
                    return new byte[] { 0x51 };
                case EDX:
                    return new byte[] { 0x52 };
                case EBX:
                    return new byte[] { 0x53 };
                case ESP:
                    return new byte[] { 0x54 };
                case EBP:
                    return new byte[] { 0x55 };
                case ESI:
                    return new byte[] { 0x56 };
                case EDI:
                    return new byte[] { 0x57 };
                case ALL:
                    return new byte[] { 0x60 };
                case FLAGS:
                    return new byte[] { 0x66, 0x9C };
            }
            throw new UnsupportedOperandException();
        }
    }
}
