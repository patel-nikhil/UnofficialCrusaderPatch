using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using static UCP.Patching.BinElements.Register;
using static UCP.Patching.BinElements.OpCodes;
using static UCP.Patching.BinElements.OpCodes.Condition.Values;

namespace UCP.Mods
{
    class ImproveAIWoodBuying : GenericMod
    {
        public ImproveAIWoodBuying()
        {
            Label.CrusaderLabels.Add("buy_wood", new Label("buy_wood", "ai_buywood", 2));
            Label.ExtremeLabels.Add("buy_wood_xt", new Label("buy_wood_xt", "ai_buywood", 2));

            this.IsEnabled = true;
            this.CrusaderChanges.Add(
                new CodeReplacement("ai_buywood", null)
                    .withValue(new InlineValueRetriever() {
                        (byte)0xE9, new RelativeReference("ai_buywood"),
                        (byte)0x90,
                        new InlineLabel("ai_buywood_ret")
                    }));

            this.ExtremeChanges.Add(
                new CodeReplacement("ai_buywood", null)
                    .withValue(new InlineValueRetriever() { 
                        (byte)0xE9, new RelativeReference("ai_buywood_xt"), 
                        (byte)0x90,
                        new InlineLabel("ai_buywood_ret_xt")
                    }));


            this.CrusaderChanges.Add(
                new CodeAllocation()
                    .withValue(new AllocatedValueRetriever() { 
                        new AllocatedCodeLabel("ai_buywood"),
                        ADD(EBX, 0x02),
                        (byte)0x3B, (byte)0x9E, new FixedReference("buy_wood"),
                        (byte)0xE9, new AllocatedRelativeReference("ai_buywood_ret")
                    }));

            this.ExtremeChanges.Add(
                new CodeAllocation()
                    .withValue(new AllocatedValueRetriever() {
                        new AllocatedCodeLabel("ai_buywood_xt"),
                        ADD(EBX, 0x02),
                        (byte)0x3B, (byte)0x9E, new FixedReference("buy_wood_xt"),
                        (byte)0xE9, new AllocatedRelativeReference("ai_buywood_ret_xt")
                    }));

            ModList.Add(this);
        }
    }
}
