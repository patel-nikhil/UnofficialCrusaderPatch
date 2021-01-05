using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UCP.Mods
{
    class IncreaseSpearmanArrowResistance : GenericMod
    {
        public IncreaseSpearmanArrowResistance()
        {
            this.IsEnabled = true;

            this.CrusaderChanges.Add(
                new CodeReplacement("u_spearbow", null)
                    .withValue(new InlineValueRetriever() {
                        2000
                    }));

            this.ExtremeChanges.Add(
                new CodeReplacement("u_spearbow", null)
                    .withValue(new InlineValueRetriever() {
                        2000
                    }));

            this.CrusaderChanges.Add(
                new CodeReplacement("u_spearxbow", null)
                    .withValue(new InlineValueRetriever() {
                        9999
                    }));

            this.ExtremeChanges.Add(
                new CodeReplacement("u_spearxbow", null)
                    .withValue(new InlineValueRetriever() {
                        9999
                    }));

            ModList.Add(this);
        }
    }
}
