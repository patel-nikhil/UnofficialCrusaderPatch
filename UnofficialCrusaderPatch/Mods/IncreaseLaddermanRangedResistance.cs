using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UCP.Mods
{
    class IncreaseLaddermanRangedResistance : GenericMod
    {
        public IncreaseLaddermanRangedResistance()
        {
            this.IsEnabled = true;

            this.CrusaderChanges.Add(
                new CodeReplacement("u_ladderarmor_bow", null)
                    .withValue(new InlineValueRetriever() {
                        420
                    }));

            this.ExtremeChanges.Add(
                new CodeReplacement("u_ladderarmor_bow", null)
                    .withValue(new InlineValueRetriever() {
                        420
                    }));



            this.CrusaderChanges.Add(
                new CodeReplacement("u_ladderarmor_sling", null)
                    .withValue(new InlineValueRetriever() {
                        1000
                    }));

            this.ExtremeChanges.Add(
                new CodeReplacement("u_ladderarmor_sling", null)
                    .withValue(new InlineValueRetriever() {
                        1000
                    }));


            this.CrusaderChanges.Add(
                new CodeReplacement("u_ladderarmor_xbow", null)
                    .withValue(new InlineValueRetriever() {
                        1000
                    }));

            this.ExtremeChanges.Add(
                new CodeReplacement("u_ladderarmor_xbow", null)
                    .withValue(new InlineValueRetriever() {
                        1000
                    }));


            this.CrusaderChanges.Add(
                new CodeReplacement("u_laddergold", null)
                    .withValue(new InlineValueRetriever() {
                        (byte)0xF7
                    }));

            this.ExtremeChanges.Add(
                new CodeReplacement("u_laddergold", null)
                    .withValue(new InlineValueRetriever() {
                        (byte)0xF7
                    }));


            this.CrusaderChanges.Add(
                new CodeReplacement("ui_fix_laddermen_cost_display_in_engineers_guild", null)
                    .withValue(new InlineValueRetriever() {
                        (byte)0xBB, (byte)0x14
                    }));

            this.ExtremeChanges.Add(
                new CodeReplacement("ui_fix_laddermen_cost_display_in_engineers_guild", null)
                    .withValue(new InlineValueRetriever() {
                        (byte)0xBB, (byte)0x14
                    }));

            ModList.Add(this);
        }
    }
}
