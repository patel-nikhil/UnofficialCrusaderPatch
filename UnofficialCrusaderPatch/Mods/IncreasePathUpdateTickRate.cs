using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UCP.Mods
{
    class IncreasePathUpdateTickRate : GenericMod
    {
        public IncreasePathUpdateTickRate()
        {
            this.IsEnabled = true;

            this.CrusaderChanges.Add(
                new CodeReplacement("o_increase_path_update_tick_rate", null)
                    .withValue(new InlineValueRetriever() {
                        new SkipPosition(0x25),
                        (byte)0x32
                    }));

            this.ExtremeChanges.Add(
                new CodeReplacement("o_increase_path_update_tick_rate", null)
                    .withValue(new InlineValueRetriever() {
                        new SkipPosition(0x25),
                        (byte)0x32
                    }));

            ModList.Add(this);
        }
    }
}
