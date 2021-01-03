using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using static UCP.Patching.BinElements.Register;

namespace UCP.Patching.BinElements
{
    public partial class OpCodes
    {
        public static byte[] JMP(byte[] instruction)
        {
            return instruction;
        }

        public static byte[] JMP(Condition.Values cond, sbyte offset)
        {
            switch (cond)
            {
                case Condition.Values.EQUALS:
                    return new byte[] { 0x74, (byte)Math.Abs(offset) };
                case Condition.Values.NOTEQUALS:
                    return new byte[] { 0x75, (byte)Math.Abs(offset) };
                case Condition.Values.LESS:
                    return new byte[] { 0x7C, (byte)Math.Abs(offset) };
                case Condition.Values.GREATERTHANEQUALS:
                    return new byte[] { 0x7D, (byte)Math.Abs(offset) };
                case Condition.Values.LESSTHANEQUALS:
                    return new byte[] { 0x7E, (byte)Math.Abs(offset) };
                case Condition.Values.GREATER:
                    return new byte[] { 0x7F, (byte)Math.Abs(offset) };
                case Condition.Values.UNCONDITIONAL:
                    return new byte[] { 0xEB, (byte)Math.Abs(offset) };
            }
            throw new UnsupportedOperandException();
        }

        public class Condition
        {
            public enum Values
            {
                EQUALS,
                NOTEQUALS,
                LESS,
                LESSTHANEQUALS,
                GREATER,
                GREATERTHANEQUALS,
                UNCONDITIONAL
            }

            public static Condition.Values GetOpposite(Condition.Values cond)
            {
                switch (cond)
                {
                    case Condition.Values.EQUALS:
                        return Condition.Values.NOTEQUALS;
                    case Condition.Values.NOTEQUALS:
                        return Condition.Values.EQUALS;
                    case Condition.Values.LESS:
                        return Condition.Values.GREATERTHANEQUALS;
                    case Condition.Values.LESSTHANEQUALS:
                        return Condition.Values.GREATER;
                    case Condition.Values.GREATER:
                        return Condition.Values.LESSTHANEQUALS;
                    case Condition.Values.GREATERTHANEQUALS:
                        return Condition.Values.LESS;
                    default:
                        return Condition.Values.UNCONDITIONAL;
                }
            }
        }
    }
}
