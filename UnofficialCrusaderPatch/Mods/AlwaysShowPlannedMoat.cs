using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UCP.Mods
{
    class AlwaysShowPlannedMoat : GenericMod
    {
        public AlwaysShowPlannedMoat()
        {
            this.IsEnabled = true;

            this.CrusaderChanges.Add(
                new CodeReplacement("o_moatvisibility", null)
                    .withValue(new InlineValueRetriever() {
                        new SkipPosition(0x24),
                        (byte)0x15
                    }));

            this.ExtremeChanges.Add(
                new CodeReplacement("o_moatvisibility", null)
                    .withValue(new InlineValueRetriever() {
                        new SkipPosition(0x24),
                        (byte)0x15
                    }));

            ModList.Add(this);
        }
    }
}
