using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UCP.Mods
{
    class DisableDemolishInaccessible : GenericMod
    {
        public DisableDemolishInaccessible()
        {
            this.IsEnabled = true;
            this.CrusaderChanges.Add(
                new CodeReplacement("ai_access", null)
                    .withValue(new InlineValueRetriever() { (byte)0xEB }));

            this.ExtremeChanges.Add(
                new CodeReplacement("ai_access", null)
                    .withValue(new InlineValueRetriever() { (byte)0xEB }));

            ModList.Add(this);
        }
    }
}
