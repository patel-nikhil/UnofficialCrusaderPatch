using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UCP
{
    public class SkipPosition
    {
        public int Count { get; set; }

        public SkipPosition()
        {
            this.Count = 1;
        }
        public SkipPosition(int count)
        {
            this.Count = count;
        }
    }
}
