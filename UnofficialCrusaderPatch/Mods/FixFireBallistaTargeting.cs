using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using static UCP.Patching.BinElements.Register;
using static UCP.Patching.BinElements.OpCodes;
using static UCP.Patching.BinElements.OpCodes.Condition.Values;

namespace UCP.Mods
{
    class FixFireBallistaTargeting : GenericMod
    {
        public FixFireBallistaTargeting()
        {
            this.IsEnabled = true;
            this.CrusaderChanges.Add(
                new CodeReplacement("u_fireballistamonk", null)
                    .withValue(new InlineValueRetriever() { (byte)0x00 }));

            this.ExtremeChanges.Add(
                new CodeReplacement("u_fireballistamonk", null)
                    .withValue(new InlineValueRetriever() { (byte)0x00 }));


            this.CrusaderChanges.Add(
                new CodeReplacement("u_fireballistatunneler", null)
                    .withValue(new InlineValueRetriever() { new SkipPosition(13), (byte)0xE9, new RelativeReference("fbal_tunnel"), (byte)0x90, new InlineLabel("fbal_tunnel_ret") }));

            this.ExtremeChanges.Add(
                new CodeReplacement("u_fireballistatunneler", null)
                    .withValue(new InlineValueRetriever() { new SkipPosition(13), (byte)0xE9, new RelativeReference("fbal_tunnel_xt"), (byte)0x90, new InlineLabel("fbal_tunnel_ret_xt") }));

            this.CrusaderChanges.Add(
                new CodeAllocation()
                    .withValue(new AllocatedValueRetriever() { new AllocatedCodeLabel("fbal_tunnel"),
                            CMP(EAX, 5), //  cmp eax,05
                            PUSH(FLAGS), //  pushf
                            ADD(EAX, -0x16), //  add eax,-0x16
                            POP(FLAGS), //  popf
                            JMP(NOTEQUALS, 0x05), //  jne short 5
                            MOV(EAX, 5), //  mov eax,05
                            CMP(EAX, 0x37), //  cmp eax,37
                        (byte)0xE9, new AllocatedRelativeReference("fbal_tunnel_ret") }));

            this.ExtremeChanges.Add(
                new CodeAllocation()
                    .withValue(new AllocatedValueRetriever() { new AllocatedCodeLabel("fbal_tunnel_xt"),
                            CMP(EAX, 5), //  cmp eax,05
                            PUSH(FLAGS), //  pushf
                            ADD(EAX, -0x16), //  add eax,-0x16
                            POP(FLAGS), //  popf
                            JMP(NOTEQUALS, 0x05), //  jne short 5
                            MOV(EAX, 5), //  mov eax,05
                            CMP(EAX, 0x37), //  cmp eax,37
                        (byte)0xE9, new AllocatedRelativeReference("fbal_tunnel_ret_xt") }));


            ModList.Add(this);
        }
    }
}
