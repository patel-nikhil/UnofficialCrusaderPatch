using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UCP.Mods
{
    class IncreaseArabSwordsmanWallAttackSpeed : GenericMod
    {
        public IncreaseArabSwordsmanWallAttackSpeed()
        {
            this.IsEnabled = true;

            this.CrusaderChanges.Add(
                new CodeReplacement("u_arabwall", null)
                    .withValue(new InlineValueRetriever() {
                        new byte[] {
                            0x01, 0x02, 0x03, 0x04, 0x06, 0x07, 0x08, 0x09, 0x0A, 0x0B, 0x0C, 0x0D, 0x0E,
                            0x10, 0x11, 0x12, 0x13, 0x14, 0x16, 0x17, 0x18, 0x19, 0x1A, 0x1B, 0x00
                        }
                    }));

            this.ExtremeChanges.Add(
                new CodeReplacement("u_arabwall", null)
                    .withValue(new InlineValueRetriever() {
                        new byte[] {
                            0x01, 0x02, 0x03, 0x04, 0x06, 0x07, 0x08, 0x09, 0x0A, 0x0B, 0x0C, 0x0D, 0x0E,
                            0x10, 0x11, 0x12, 0x13, 0x14, 0x16, 0x17, 0x18, 0x19, 0x1A, 0x1B, 0x00
                        }
                    }));

            ModList.Add(this);
        }
    }
}
