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

    public class AllocatedCodeLabel : Label
    {
        public AllocatedCodeLabel(string identifier) : base()
        {
            this.Identifier = identifier;
            CrusaderLabels.Add(Identifier, this);
            ExtremeLabels.Add(Identifier, this);
        }
    }

    public class AllocatedMemoryLabel : Label
    {
        public AllocatedMemoryLabel(string identifier) : base()
        {
            this.Identifier = identifier;
            CrusaderLabels.Add(Identifier, this);
            ExtremeLabels.Add(Identifier, this);
        }
    }
}
