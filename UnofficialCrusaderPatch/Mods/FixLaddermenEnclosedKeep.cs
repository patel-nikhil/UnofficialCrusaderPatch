using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UCP.Mods
{
    class FixLaddermenEnclosedKeep : GenericMod
    {
        public FixLaddermenEnclosedKeep()
        {
            this.IsEnabled = true;
            this.CrusaderChanges.Add(
                new CodeReplacement("ai_fix_laddermen_with_enclosed_keep", null)
                    .withValue(new InlineValueRetriever() { (byte)0x6A, (byte)0x01 }));

            this.ExtremeChanges.Add(
                new CodeReplacement("ai_fix_laddermen_with_enclosed_keep", null)
                    .withValue(new InlineValueRetriever() { (byte)0x6A, (byte)0x01 }));

            ModList.Add(this);
        }
    }
}
