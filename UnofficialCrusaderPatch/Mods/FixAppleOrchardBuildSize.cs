using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UCP.Mods
{
    class FixAppleOrchardBuildSize : GenericMod
    {
        public FixAppleOrchardBuildSize()
        {
            this.IsEnabled = true;

            this.CrusaderChanges.Add(
                new CodeReplacement("fix_apple_orchard_build_size", null)
                    .withValue(new InlineValueRetriever() {
                        new SkipPosition(16),
                        (byte)0x0A
                    }));

            this.ExtremeChanges.Add(
                new CodeReplacement("fix_apple_orchard_build_size", null)
                    .withValue(new InlineValueRetriever() {
                        new SkipPosition(16),
                        (byte)0x0A
                    }));

            ModList.Add(this);
        }
    }
}
