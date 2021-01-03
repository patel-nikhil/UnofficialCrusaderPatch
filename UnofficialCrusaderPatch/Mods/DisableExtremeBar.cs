using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UCP.Mods
{
    class DisableExtremeBar : GenericMod
    {
        public DisableExtremeBar()
        {
            this.IsEnabled = true;
            this.ExtremeChanges.Add(
                new CodeReplacement("o_xtreme_bar1", null)
                    .withValue(new InlineValueRetriever() { (byte)0x90, (byte)0x90, (byte)0x90, (byte)0x90, (byte)0x90, (byte)0x90, (byte)0x90, (byte)0x90, (byte)0x90, (byte)0x90 }));

            this.ExtremeChanges.Add(
                new CodeReplacement("o_xtreme_bar2", null)
                    .withValue(new InlineValueRetriever() { (byte)0xC3 }));

            ModList.Add(this);
        }
    }
}
