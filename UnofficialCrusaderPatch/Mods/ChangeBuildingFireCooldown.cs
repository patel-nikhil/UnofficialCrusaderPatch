using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UCP.Mods
{
    class ChangeBuildingFireCooldown : GenericMod
    {
        public ChangeBuildingFireCooldown()
        {
            this.IsEnabled = true;

            CodeReplacement codeReplacement = new CodeReplacement("o_firecooldown", new int[] { 0 });
            byte[] parameterBytes = BitConverter.GetBytes(codeReplacement.Parameters[0]);

            this.CrusaderChanges.Add(
                    codeReplacement.withValue(new InlineValueRetriever() {
                        new SkipPosition(8),
                        parameterBytes[0], 
                        parameterBytes[1]
                    }));

            this.ExtremeChanges.Add(
                    codeReplacement.withValue(new InlineValueRetriever() {
                        new SkipPosition(8),
                        parameterBytes[0], 
                        parameterBytes[1]
                    }));

            ModList.Add(this);
        }
    }
}
