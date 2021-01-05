using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UCP.Mods
{
    class FixBakersDisappearing : GenericMod
    {
        public FixBakersDisappearing()
        {
            this.IsEnabled = true;

            this.CrusaderChanges.Add(
                new CodeReplacement("o_fix_baker_disappear", null)
                    .withValue(new InlineValueRetriever() {
                        new SkipPosition(0x13),
                        (byte)0x90, (byte)0x90, (byte)0x90,
                        (byte)0x90, (byte)0x90, (byte)0x90,
                        (byte)0x90, (byte)0x90, (byte)0x90
                    }));

            this.ExtremeChanges.Add(
                new CodeReplacement("o_fix_baker_disappear", null)
                    .withValue(new InlineValueRetriever() {
                        new SkipPosition(0x13),
                        (byte)0x90, (byte)0x90, (byte)0x90,
                        (byte)0x90, (byte)0x90, (byte)0x90,
                        (byte)0x90, (byte)0x90, (byte)0x90
                    }));

            ModList.Add(this);
        }
    }
}
