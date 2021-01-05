﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UCP.Mods
{
    class SetAIRecruitmentInterval : GenericMod
    {
        public SetAIRecruitmentInterval()
        {
            this.IsEnabled = true;


            // AI_OFFSET = AI_INDEX * 169

            // recruit interval: 023FC8E8 + AI_OFFSET * 4 + 164

            // start of game offsets?
            // rat offset: 0xA9  => 1, 1, 1
            // snake offset: 0x152 => 1, 0, 1
            // pig offset: 0x1FB => 1, 1, 4
            // wolf offset: 0x2A4 => 4, 1, 4
            // saladin offset: 0x34D => 1, 1, 1
            // kalif offset: 0x3F6 => 0, 1, 0
            // sultan offset: 0x49F  => 8, 8, 4
            // richard offset: 0x548  => 1, 1, 1
            // frederick offset: 0x5F1  => 4, 1, 4
            // philipp offset: 0x69A  => 4, 4, 4
            // wazir offset: 0x743  => 1, 1, 1
            // emir offset: 0x7EC  => 0, 1, 0
            // nizar offset: 0x895  => 4, 8, 1
            // sheriff offset: 0x93E  => 4, 1, 4
            // marshal offset: 0x9E7  => 1, 1, 4
            // abbot offset: 0xA90  => 1, 1, 1

            // +4, normal2
            // +8, turned up?

            // sets the recruitment interval to 1 for all AIs
            // 004D3B41 mov eax, 1

            this.CrusaderChanges.Add(
                new CodeReplacement("ai_recruitinterval", null)
                    .withValue(new InlineValueRetriever() {
                        (byte)0xB8, (byte)0x01, (byte)0, (byte)0, (byte)0, (byte)0x90, (byte)0x90
                    }));

            this.ExtremeChanges.Add(
                new CodeReplacement("ai_recruitinterval", null)
                    .withValue(new InlineValueRetriever() {
                        (byte)0xB8, (byte)0x01, (byte)0, (byte)0, (byte)0, (byte)0x90, (byte)0x90
                    }));

            ModList.Add(this);
        }
    }
}
