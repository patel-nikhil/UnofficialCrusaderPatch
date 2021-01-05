using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UCP.Mods
{
    class IncreaseAIAdditionalAttackTroopLimit : GenericMod
    {
        public IncreaseAIAdditionalAttackTroopLimit()
        {
            this.IsEnabled = true;
            CodeReplacement codeReplacement = new CodeReplacement("ai_attacklimit", new int[] { 0 });
            

            this.CrusaderChanges.Add(
                    codeReplacement.withValue(new InlineValueRetriever() {
                        codeReplacement.Parameters[0]
                    }));

            this.ExtremeChanges.Add(
                    codeReplacement.withValue(new InlineValueRetriever() {
                        codeReplacement.Parameters[0]
                    }));

            ModList.Add(this);
        }
    }
}
