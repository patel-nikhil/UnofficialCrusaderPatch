using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UCP.Mods
{
    class MakeGatehouseMoreResponsive : GenericMod
    {
        public MakeGatehouseMoreResponsive()
        {
            this.IsEnabled = true;

            this.CrusaderChanges.Add(
                new CodeReplacement("o_gatedistance", null)
                    .withValue(new InlineValueRetriever() {
                        140
                    }));

            this.ExtremeChanges.Add(
                new CodeReplacement("o_gatedistance", null)
                    .withValue(new InlineValueRetriever() {
                        140
                    }));

            this.CrusaderChanges.Add(
                new CodeReplacement("o_gatetime", null)
                    .withValue(new InlineValueRetriever() {
                        BitConverter.GetBytes((short)100)
                    }));

            this.ExtremeChanges.Add(
                new CodeReplacement("o_gatetime", null)
                    .withValue(new InlineValueRetriever() {
                        BitConverter.GetBytes((short)100)
                    }));

            ModList.Add(this);
        }
    }
}
