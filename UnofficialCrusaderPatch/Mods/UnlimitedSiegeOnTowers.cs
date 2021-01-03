using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UCP.Mods
{
    class UnlimitedSiegeOnTowers : GenericMod
    {
        public UnlimitedSiegeOnTowers()
        {
            this.IsEnabled = true;
            this.CrusaderChanges.Add(
                new CodeReplacement("ai_towerengines", null)
                    .withValue(new InlineValueRetriever() { (byte)0xEB }));

            this.ExtremeChanges.Add(
                new CodeReplacement("ai_towerengines", null)
                    .withValue(new InlineValueRetriever() { (byte)0xEB }));

            ModList.Add(this);
        }
    }
}
