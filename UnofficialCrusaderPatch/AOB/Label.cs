﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UCP
{
    public class Label
    {
        public static Dictionary<string, Label> CrusaderLabels = new Dictionary<string, Label>();
        public static Dictionary<string, Label> ExtremeLabels = new Dictionary<string, Label>();
        public int Address { get; set;  }
        public int Offset { get; }
        public string Identifier { get; set; }

        public string CodeBlockName { get; set; }

        protected Label()
        {

        }

        public Label(string identifier, string codeBlockName)
        {
            this.Identifier = identifier;
            this.CodeBlockName = codeBlockName;
        }

        public Label(string identifier, string codeBlockName, int offset)
        {
            this.Identifier = identifier;
            this.CodeBlockName = codeBlockName;
            this.Offset = offset;
        }

        public void SetAddress(int baseAddress)
        {
            this.Address = baseAddress + Offset;
        }

        public int GetAddress()
        {
            return Address;
        }
    }

    public class InlineLabel : Label {
        public InlineLabel(string identifier) : base()
        {
            this.Identifier = identifier;
            CrusaderLabels.Add(Identifier, this);
            ExtremeLabels.Add(Identifier, this);
        }
    }

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

    public class FixedReference : Reference {
        public FixedReference(string targetLabelName) : base(targetLabelName) { }
    }

    public class RelativeReference : Reference {
        public RelativeReference(string targetLabelName) : base(targetLabelName) { }
    }
}
