using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UCP.Mods
{
    class FreeTradingPost : GenericMod
    {
        public FreeTradingPost()
        {
            this.IsEnabled = true;

            this.CrusaderChanges.Add(
                new CodeReplacement("o_freetrader", null)
                    .withValue(new InlineValueRetriever() {
                        (byte)0x00
                    }));

            this.ExtremeChanges.Add(
                new CodeReplacement("o_freetrader", null)
                    .withValue(new InlineValueRetriever() {
                        (byte)0x00
                    }));

            ModList.Add(this);
        }
    }
}
