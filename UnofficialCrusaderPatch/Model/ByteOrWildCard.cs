using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UCP
{
    public class ByteOrWildCard
    {
        dynamic value;

        public ByteOrWildCard(byte element)
        {
            this.value = element;
        }

        public ByteOrWildCard(short element)
        {
            this.value = element;
        }

        public ByteOrWildCard(WildCard element)
        {
            this.value = element;
        }

        public bool IsWildCard => this.value is WildCard;

        public int IntValue
        {
            get
            {
                if (this.value is byte)
                {
                    return (int)this.value;
                }
                else
                {
                    return 0x100;
                }
            }
        }

        public static bool operator ==(ByteOrWildCard first, ByteOrWildCard second)
        {
            if (first == null || second == null)
            {
                return false;
            }

            if (first.value is byte)
            {
                if (second.value is byte)
                {
                    return first.value == second.value;
                }
                else if (second.value is WildCard)
                {
                    return true;
                }
            }
            else
            {
                if (second.value is byte || second.value is WildCard)
                {
                    return true;
                }
            }
            return false;
        }

        public static bool operator !=(ByteOrWildCard first, ByteOrWildCard second)
        {
            if (first == null || second == null)
            {
                return true;
            }

            if (first.value is byte || first.value is int)
            {
                if (second.value is byte || second.value is int)
                {
                    return first.value != second.value;
                }
                else if (second.value is WildCard)
                {
                    return false;
                }
            }
            else
            {
                if (second.value is byte || second.value is int || second.value is WildCard)
                {
                    return false;
                }
            }
            return true;
        }

        public override bool Equals(object obj)
        {
            if (obj is ByteOrWildCard)
            {
                return (obj as ByteOrWildCard) == this;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return this.value.GetHashCode();
        }
    }

    public class WildCard
    {
        private WildCard() { }
        public static WildCard Instance { get; } = new WildCard();
    }
}
