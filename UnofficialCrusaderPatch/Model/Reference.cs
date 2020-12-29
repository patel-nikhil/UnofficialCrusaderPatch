using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UCP
{
    public class Reference
    {
        public int Value { get; set; }

        public int BaseAddress { get; set; }

        public string TargetLabelName { get; set; }

        public Reference(string targetLabelName)
        {
            this.TargetLabelName = targetLabelName;
        }
    }

    public class FixedReference : Reference
    {
        public FixedReference(string targetLabelName) : base(targetLabelName) { }
    }

    public class RelativeReference : Reference
    {
        public RelativeReference(string targetLabelName) : base(targetLabelName) { }
    }
}
