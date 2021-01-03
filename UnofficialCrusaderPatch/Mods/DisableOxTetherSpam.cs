using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UCP.Mods
{
    class DisableOxTetherSpam : GenericMod
    {
        public DisableOxTetherSpam()
        {
            this.IsEnabled = true;
            this.CrusaderChanges.Add(
                new CodeReplacement("ai_tethers", null)
                    .withValue(new InlineValueRetriever() { (byte)0x90, (byte)0xE9 }));

            this.ExtremeChanges.Add(
                new CodeReplacement("ai_tethers", null)
                    .withValue(new InlineValueRetriever() { (byte)0x90, (byte)0xE9 }));

            ModList.Add(this);
        }
    }
}
