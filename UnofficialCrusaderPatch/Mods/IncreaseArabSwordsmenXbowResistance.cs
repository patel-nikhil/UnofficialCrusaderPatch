using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UCP.Mods
{
    class IncreaseArabSwordsmenXbowResistance : GenericMod
    {
        public IncreaseArabSwordsmenXbowResistance()
        {
            this.IsEnabled = true;

            this.CrusaderChanges.Add(
                new CodeReplacement("u_arabxbow", null)
                    .withValue(new InlineValueRetriever() {
                        3500
                    }));

            this.ExtremeChanges.Add(
                new CodeReplacement("u_arabxbow", null)
                    .withValue(new InlineValueRetriever() {
                        3500
                    }));

            ModList.Add(this);
        }
    }
}
