using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UCP.Mods
{
    class DisableAIBuildingResourceSleep : GenericMod
    {
        public DisableAIBuildingResourceSleep()
        {
            this.IsEnabled = true;

            CodeReplacement codeReplacement = new CodeReplacement("ai_nosleep", null)
                    .withValue(new InlineValueRetriever() {
                        new byte[]{ 0x30, 0xD2, 0x90 },  // xor dl, dl
                        new SkipPosition(2),
                        new byte[]{ 0x30, 0xC9, 0x90 },  // xor cl, cl
                        new SkipPosition(10),
                        new byte[]{ 0x30, 0xD2, 0x90 },  // xor dl, dl
                        new SkipPosition(8),
                        new byte[]{ 0x30, 0xC9, 0x90 },  // xor cl, cl
                        new SkipPosition(8),
                        new byte[]{ 0x30, 0xD2, 0x90 },  // xor dl, dl
                        new SkipPosition(10),
                        new byte[]{ 0x30, 0xC9, 0x90 },  // xor cl, cl
                        new SkipPosition(10),
                        new byte[]{ 0x30, 0xD2, 0x90 },  // xor dl, dl
                        new SkipPosition(10),
                        new byte[]{ 0x30, 0xC9, 0x90 },  // xor cl, cl
                        new SkipPosition(10),
                        new byte[]{ 0x30, 0xD2, 0x90 },  // xor dl, dl
                        new SkipPosition(10),
                        new byte[]{ 0x30, 0xC9, 0x90 },  // xor cl, cl
                        new SkipPosition(10),
                        new byte[]{ 0x30, 0xD2, 0x90 }   // xor dl, dl
                    });

            this.CrusaderChanges.Add(codeReplacement);
            this.ExtremeChanges.Add(codeReplacement);

            ModList.Add(this);
        }
    }
}
