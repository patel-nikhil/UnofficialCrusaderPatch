using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using static UCP.Patching.BinElements.Register;

namespace UCP.Patching.BinElements
{
    public partial class OpCodes
    {
        public static byte[] XOR(byte[] instruction)
        {
            return instruction;
        }

        public static byte[] XOR(Register reg1, Register reg2)
        {
            switch (reg1)
            {
                case EAX:
                    switch (reg2)
                    {
                        case EAX:
                            return new byte[] { 0x31, 0xC0 };
                        case ECX:
                            return new byte[] { 0x31, 0xC1 };
                        case EDX:
                            return new byte[] { 0x31, 0xC2 };
                        case EBX:
                            return new byte[] { 0x31, 0xC3 };
                        case ESP:
                            return new byte[] { 0x31, 0xC4 };
                        case EBP:
                            return new byte[] { 0x31, 0xC5 };
                        case ESI:
                            return new byte[] { 0x31, 0xC6 };
                        case EDI:
                            return new byte[] { 0x31, 0xC7 };
                    }
                    throw new UnsupportedOperandException();

                case ECX:
                    switch (reg2)
                    {
                        case EAX:
                            return new byte[] { 0x31, 0xC8 };
                        case ECX:
                            return new byte[] { 0x31, 0xC9 };
                        case EDX:
                            return new byte[] { 0x31, 0xCA };
                        case EBX:
                            return new byte[] { 0x31, 0xCB };
                        case ESP:
                            return new byte[] { 0x31, 0xCC };
                        case EBP:
                            return new byte[] { 0x31, 0xCD };
                        case ESI:
                            return new byte[] { 0x31, 0xCE };
                        case EDI:
                            return new byte[] { 0x31, 0xCF };
                    }
                    throw new UnsupportedOperandException();

                case EDX:
                    switch (reg2)
                    {
                        case EAX:
                            return new byte[] { 0x31, 0xD0 };
                        case ECX:
                            return new byte[] { 0x31, 0xD1 };
                        case EDX:
                            return new byte[] { 0x31, 0xD2 };
                        case EBX:
                            return new byte[] { 0x31, 0xD3 };
                        case ESP:
                            return new byte[] { 0x31, 0xD4 };
                        case EBP:
                            return new byte[] { 0x31, 0xD5 };
                        case ESI:
                            return new byte[] { 0x31, 0xD6 };
                        case EDI:
                            return new byte[] { 0x31, 0xD7 };
                    }
                    throw new UnsupportedOperandException();

                case EBX:
                    switch (reg2)
                    {
                        case EAX:
                            return new byte[] { 0x31, 0xD8 };
                        case ECX:
                            return new byte[] { 0x31, 0xD9 };
                        case EDX:
                            return new byte[] { 0x31, 0xDA };
                        case EBX:
                            return new byte[] { 0x31, 0xDB };
                        case ESP:
                            return new byte[] { 0x31, 0xDC };
                        case EBP:
                            return new byte[] { 0x31, 0xDD };
                        case ESI:
                            return new byte[] { 0x31, 0xDE };
                        case EDI:
                            return new byte[] { 0x31, 0xDF };
                    }
                    throw new UnsupportedOperandException();

                case ESP:
                    switch (reg2)
                    {
                        case EAX:
                            return new byte[] { 0x31, 0xE0 };
                        case ECX:
                            return new byte[] { 0x31, 0xE1 };
                        case EDX:
                            return new byte[] { 0x31, 0xE2 };
                        case EBX:
                            return new byte[] { 0x31, 0xE3 };
                        case ESP:
                            return new byte[] { 0x31, 0xE4 };
                        case EBP:
                            return new byte[] { 0x31, 0xE5 };
                        case ESI:
                            return new byte[] { 0x31, 0xE6 };
                        case EDI:
                            return new byte[] { 0x31, 0xE7 };
                    }
                    throw new UnsupportedOperandException();

                case EBP:
                    switch (reg2)
                    {
                        case EAX:
                            return new byte[] { 0x31, 0xE8 };
                        case ECX:
                            return new byte[] { 0x31, 0xE9 };
                        case EDX:
                            return new byte[] { 0x31, 0xEA };
                        case EBX:
                            return new byte[] { 0x31, 0xEB };
                        case ESP:
                            return new byte[] { 0x31, 0xEC };
                        case EBP:
                            return new byte[] { 0x31, 0xED };
                        case ESI:
                            return new byte[] { 0x31, 0xEE };
                        case EDI:
                            return new byte[] { 0x31, 0xEF };
                    }
                    throw new UnsupportedOperandException();

                case ESI:
                    switch (reg2)
                    {
                        case EAX:
                            return new byte[] { 0x31, 0xF0 };
                        case ECX:
                            return new byte[] { 0x31, 0xF1 };
                        case EDX:
                            return new byte[] { 0x31, 0xF2 };
                        case EBX:
                            return new byte[] { 0x31, 0xF3 };
                        case ESP:
                            return new byte[] { 0x31, 0xF4 };
                        case EBP:
                            return new byte[] { 0x31, 0xF5 };
                        case ESI:
                            return new byte[] { 0x31, 0xF6 };
                        case EDI:
                            return new byte[] { 0x31, 0xF7 };
                    }
                    throw new UnsupportedOperandException();

                case EDI:
                    switch (reg2)
                    {
                        case EAX:
                            return new byte[] { 0x31, 0xF8 };
                        case ECX:
                            return new byte[] { 0x31, 0xF9 };
                        case EDX:
                            return new byte[] { 0x31, 0xFA };
                        case EBX:
                            return new byte[] { 0x31, 0xFB };
                        case ESP:
                            return new byte[] { 0x31, 0xFC };
                        case EBP:
                            return new byte[] { 0x31, 0xFD };
                        case ESI:
                            return new byte[] { 0x31, 0xFE };
                        case EDI:
                            return new byte[] { 0x31, 0xFF };
                    }
                    throw new UnsupportedOperandException();
            }
            throw new UnsupportedOperandException();
        }
    }
}
