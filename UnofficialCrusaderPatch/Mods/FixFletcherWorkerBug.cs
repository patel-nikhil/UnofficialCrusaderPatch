using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UCP.Mods
{
    class FixFletcherWorkerBug : GenericMod
    {
        public FixFletcherWorkerBug()
        {
            this.IsEnabled = true;

            this.CrusaderChanges.Add(
                new CodeReplacement("o_fix_fletcher_bug", null)
                    .withValue(new InlineValueRetriever() {
                        new SkipPosition(0x1E),
                        (byte)0x01,
                    }));

            this.ExtremeChanges.Add(
                new CodeReplacement("o_fix_fletcher_bug", null)
                    .withValue(new InlineValueRetriever() {
                        new SkipPosition(0x1E),
                        (byte)0x01,
                    }));

            ModList.Add(this);
        }
    }
}
