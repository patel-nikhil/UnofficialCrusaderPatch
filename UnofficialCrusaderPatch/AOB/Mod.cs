using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UCP
{
    class Mod
    {
        public bool IsEnabled { get; set; }

        public List<Label> Labels = new List<Label>();
        public List<IChange> Changes = new List<IChange>();

        public Mod()
        {
            Label.CrusaderLabels.Add("label1", new Label("label1", "ai_fix_crusader_archers_pitch_attr", 0));
            Label.CrusaderLabels.Add("ai_fix_crusader_archers_pitch_attr", new Label("ai_fix_crusader_archers_pitch_attr", "ai_fix_crusader_archers_pitch_attr", 0));
            Label.CrusaderLabels.Add("label3", new Label("label3", "ai_fix_crusader_archers_pitch_attr", 1));

            Label.ExtremeLabels.Add("label1", new Label("label1", "ai_fix_crusader_archers_pitch_attr", 0));
            Label.ExtremeLabels.Add("ai_fix_crusader_archers_pitch_attr", new Label("ai_fix_crusader_archers_pitch_attr", "ai_fix_crusader_archers_pitch_attr", 0));
            Label.ExtremeLabels.Add("label3", new Label("label3", "ai_fix_crusader_archers_pitch_attr", 1));

            /*Label.CrusaderLabels.Add("mylabel", new Label("ai_fix_crusader_archers_pitch_attr", 0));*/
            Changes.Add(new ExtremeBar("ai_fix_crusader_archers_pitch_attr", new int[] { 0, 0 }));
/*            Changes.Add(new CodeReplacement("ai_fix_crusader_archers_pitch_attr"));
            Changes.Add(new CodeAllocation("ai_fix_crusader_archers_pitch_attr"));
            Changes.Add(new MemoryAllocation("ai_fix_crusader_archers_pitch_attr"));*/

        }
    }

    class ExtremeBar: CodeReplacement
    {
        public ValueRetriever Value;

        public ExtremeBar(string codeBlockName, int[] parameters) : base(codeBlockName, parameters)
        {
            /*this.Value = new ValueRetriever((byte)10, Parameters[0], new FixedReference("ai_fix_crusader_archers_pitch_attr"), new RelativeReference("label3"), new InlineLabel("label2"));*/
            this.Value = new ValueRetriever((byte)10, Parameters[0], new FixedReference("ai_fix_crusader_archers_pitch_attr"), new RelativeReference("label3"), new InlineLabel("label2"));
        }

        public override ValueRetriever GetByteValue()
        {
            return Value;
        }
    }
}


/*new Change("o_xtreme", ChangeType.Other, false)
{
    new DefaultHeader("o_xtreme")
    {
        // 0057CAC5 disable manabar rendering
        BinNops.CreateEdit("o_xtreme_bar1", 10),
                    
        // 4DA3E0 disable manabar clicks
        BinBytes.CreateEdit("o_xtreme_bar2", 0xC3),
    }
},*/