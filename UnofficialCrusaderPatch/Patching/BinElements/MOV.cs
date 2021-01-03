using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using static UCP.Patching.BinElements.Register;

namespace UCP.Patching.BinElements
{
    public partial class OpCodes
    {
        public static byte[] MOV(byte[] instruction)
        {
            return instruction;
        }

        public static byte[] MOV(Register reg, Int32 signedValue)
        {
            Int32 val = (Int32)(signedValue >= 0 ? signedValue : 0xFFFFFFFF - Math.Abs(signedValue));
            switch (reg)
            {
                case EAX:
                    return (new byte[] { 0xB8 }).Concat(BitConverter.GetBytes(val)).ToArray();

                case ECX:
                    return (new byte[] { 0xB9 }).Concat(BitConverter.GetBytes(val)).ToArray();

                case EDX:
                    return (new byte[] { 0xBA }).Concat(BitConverter.GetBytes(val)).ToArray();

                case EBX:
                    return (new byte[] { 0xBB }).Concat(BitConverter.GetBytes(val)).ToArray();

                case ESP:
                    return (new byte[] { 0xBC }).Concat(BitConverter.GetBytes(val)).ToArray();

                case EBP:
                    return (new byte[] { 0xBD }).Concat(BitConverter.GetBytes(val)).ToArray();

                case ESI:
                    return (new byte[] { 0xBE }).Concat(BitConverter.GetBytes(val)).ToArray();

                case EDI:
                    return (new byte[] { 0xBF }).Concat(BitConverter.GetBytes(val)).ToArray();
            }
            throw new UnsupportedOperandException();
        }

        public static byte[] MOV(Register reg1, Register reg2)
        {
            switch (reg1)
            {
                case EAX:
                    switch (reg2)
                    {
                        case EAX:
                            return new byte[] { 0x8B, 0xC0 };
                        case ECX:
                            return new byte[] { 0x8B, 0xC1 };
                        case EDX:
                            return new byte[] { 0x8B, 0xC2 };
                        case EBX:
                            return new byte[] { 0x8B, 0xC3 };
                        case ESP:
                            return new byte[] { 0x8B, 0xC4 };
                        case EBP:
                            return new byte[] { 0x8B, 0xC5 };
                        case ESI:
                            return new byte[] { 0x8B, 0xC6 };
                        case EDI:
                            return new byte[] { 0x8B, 0xC7 };
                    }
                    throw new UnsupportedOperandException();

                case ECX:
                    switch (reg2)
                    {
                        case EAX:
                            return new byte[] { 0x8B, 0xC8 };
                        case ECX:
                            return new byte[] { 0x8B, 0xC9 };
                        case EDX:
                            return new byte[] { 0x8B, 0xCA };
                        case EBX:
                            return new byte[] { 0x8B, 0xCB };
                        case ESP:
                            return new byte[] { 0x8B, 0xCC };
                        case EBP:
                            return new byte[] { 0x8B, 0xCD };
                        case ESI:
                            return new byte[] { 0x8B, 0xCE };
                        case EDI:
                            return new byte[] { 0x8B, 0xCF };
                    }
                    throw new UnsupportedOperandException();

                case EDX:
                    switch (reg2)
                    {
                        case EAX:
                            return new byte[] { 0x8B, 0xD0 };
                        case ECX:
                            return new byte[] { 0x8B, 0xD1 };
                        case EDX:
                            return new byte[] { 0x8B, 0xD2 };
                        case EBX:
                            return new byte[] { 0x8B, 0xD3 };
                        case ESP:
                            return new byte[] { 0x8B, 0xD4 };
                        case EBP:
                            return new byte[] { 0x8B, 0xD5 };
                        case ESI:
                            return new byte[] { 0x8B, 0xD6 };
                        case EDI:
                            return new byte[] { 0x8B, 0xD7 };
                    }
                    throw new UnsupportedOperandException();

                case EBX:
                    switch (reg2)
                    {
                        case EAX:
                            return new byte[] { 0x8B, 0xD8 };
                        case ECX:
                            return new byte[] { 0x8B, 0xD9 };
                        case EDX:
                            return new byte[] { 0x8B, 0xDA };
                        case EBX:
                            return new byte[] { 0x8B, 0xDB };
                        case ESP:
                            return new byte[] { 0x8B, 0xDC };
                        case EBP:
                            return new byte[] { 0x8B, 0xDD };
                        case ESI:
                            return new byte[] { 0x8B, 0xDE };
                        case EDI:
                            return new byte[] { 0x8B, 0xDF };
                    }
                    throw new UnsupportedOperandException();

                case ESP:
                    switch (reg2)
                    {
                        case EAX:
                            return new byte[] { 0x8B, 0xE0 };
                        case ECX:
                            return new byte[] { 0x8B, 0xE1 };
                        case EDX:
                            return new byte[] { 0x8B, 0xE2 };
                        case EBX:
                            return new byte[] { 0x8B, 0xE3 };
                        case ESP:
                            return new byte[] { 0x8B, 0xE4 };
                        case EBP:
                            return new byte[] { 0x8B, 0xE5 };
                        case ESI:
                            return new byte[] { 0x8B, 0xE6 };
                        case EDI:
                            return new byte[] { 0x8B, 0xE7 };
                    }
                    throw new UnsupportedOperandException();

                case EBP:
                    switch (reg2)
                    {
                        case EAX:
                            return new byte[] { 0x8B, 0xE8 };
                        case ECX:
                            return new byte[] { 0x8B, 0xE9 };
                        case EDX:
                            return new byte[] { 0x8B, 0xEA };
                        case EBX:
                            return new byte[] { 0x8B, 0xEB };
                        case ESP:
                            return new byte[] { 0x8B, 0xEC };
                        case EBP:
                            return new byte[] { 0x8B, 0xED };
                        case ESI:
                            return new byte[] { 0x8B, 0xEE };
                        case EDI:
                            return new byte[] { 0x8B, 0xEF };
                    }
                    throw new UnsupportedOperandException();

                case ESI:
                    switch (reg2)
                    {
                        case EAX:
                            return new byte[] { 0x8B, 0xF0 };
                        case ECX:
                            return new byte[] { 0x8B, 0xF1 };
                        case EDX:
                            return new byte[] { 0x8B, 0xF2 };
                        case EBX:
                            return new byte[] { 0x8B, 0xF3 };
                        case ESP:
                            return new byte[] { 0x8B, 0xF4 };
                        case EBP:
                            return new byte[] { 0x8B, 0xF5 };
                        case ESI:
                            return new byte[] { 0x8B, 0xF6 };
                        case EDI:
                            return new byte[] { 0x8B, 0xF7 };
                    }
                    throw new UnsupportedOperandException();

                case EDI:
                    switch (reg2)
                    {
                        case EAX:
                            return new byte[] { 0x8B, 0xF8 };
                        case ECX:
                            return new byte[] { 0x8B, 0xF9 };
                        case EDX:
                            return new byte[] { 0x8B, 0xFA };
                        case EBX:
                            return new byte[] { 0x8B, 0xFB };
                        case ESP:
                            return new byte[] { 0x8B, 0xFC };
                        case EBP:
                            return new byte[] { 0x8B, 0xFD };
                        case ESI:
                            return new byte[] { 0x8B, 0xFE };
                        case EDI:
                            return new byte[] { 0x8B, 0xFF };
                    }
                    throw new UnsupportedOperandException();
            }
            throw new UnsupportedOperandException();
        }

    }
}
