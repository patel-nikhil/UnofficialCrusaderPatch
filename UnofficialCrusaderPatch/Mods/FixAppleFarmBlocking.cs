using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using static UCP.Patching.BinElements.Register;
using static UCP.Patching.BinElements.OpCodes;
using static UCP.Patching.BinElements.OpCodes.Condition.Values;

namespace UCP.Mods
{
    class FixAppleFarmBlocking : GenericMod
    {
        public FixAppleFarmBlocking()
        {
            this.IsEnabled = true;

            this.CrusaderChanges.Add(
                new CodeReplacement("u_fireballistatunneler", null)
                    .withValue(new InlineValueRetriever() { new SkipPosition(11), (byte)0xE9, new RelativeReference("u_fix_applefarm_blocking"), new InlineLabel("u_fix_applefarm_blocking_ret") }));

            this.ExtremeChanges.Add(
                new CodeReplacement("u_fireballistatunneler", null)
                    .withValue(new InlineValueRetriever() { new SkipPosition(11), (byte)0xE9, new RelativeReference("u_fix_applefarm_blocking_xt"), new InlineLabel("u_fix_applefarm_blocking_ret_xt") }));

            this.CrusaderChanges.Add(
                new CodeAllocation()
                    .withValue(new AllocatedValueRetriever() { new AllocatedCodeLabel("u_fix_applefarm_blocking"),
                            0x81, 0x47, 0x14, 0x02, 0x00, 0x00, 0x00, // add [edi+14],00000002
                            0x81, 0x47, 0x18, 0x02, 0x00, 0x00, 0x00, // add [edi+18],00000002
                            0x5F, // pop edi
                        (byte)0xE9, new AllocatedRelativeReference("u_fix_applefarm_blocking_ret") }));

            this.ExtremeChanges.Add(
                new CodeAllocation()
                    .withValue(new AllocatedValueRetriever() { new AllocatedCodeLabel("u_fix_applefarm_blocking_xt"),
                            0x81, 0x47, 0x14, 0x02, 0x00, 0x00, 0x00, // add [edi+14],00000002
                            0x81, 0x47, 0x18, 0x02, 0x00, 0x00, 0x00, // add [edi+18],00000002
                            0x5F, // pop edi
                        (byte)0xE9, new AllocatedRelativeReference("u_fix_applefarm_blocking_ret_xt") }));


            ModList.Add(this);
        }
    }
}
