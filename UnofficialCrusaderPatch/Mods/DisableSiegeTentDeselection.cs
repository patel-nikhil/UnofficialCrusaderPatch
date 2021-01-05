using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UCP.Mods
{
    class DisableSiegeTentDeselection : GenericMod
    {
        public DisableSiegeTentDeselection()
        {
            this.IsEnabled = true;

            this.CrusaderChanges.Add(
                new CodeReplacement("o_engineertent", null)
                    .withValue(new InlineValueRetriever() {
                        new byte[] { 0x90, 0x90, 0x90, 0x90, 0x90, 0x90 }
                    }));

            this.ExtremeChanges.Add(
                new CodeReplacement("o_engineertent", null)
                    .withValue(new InlineValueRetriever() {
                        new byte[] { 0x90, 0x90, 0x90, 0x90, 0x90, 0x90 }
                    }));

            ModList.Add(this);
        }
    }
}
