using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UCP.Mods
{
    public abstract class GenericMod
    {
        public static List<GenericMod> ModList = new List<GenericMod>();

        public bool IsEnabled { get; set; }
        public string Identifier { get; set; }
        public List<Label> CrusaderLabels = new List<Label>();
        public List<Label> ExtremeLabels = new List<Label>();
        public List<IChange> CrusaderChanges = new List<IChange>();
        public List<IChange> ExtremeChanges = new List<IChange>();

        public bool HasCrusaderChange => CrusaderChanges.Count > 0;
        public bool HasExtremeChange => ExtremeChanges.Count > 0;

        static GenericMod()
        {
            new DisableExtremeBar();
            new FixFireBallistaTargeting();
            new DisableDemolishInaccessible();
            new DisableOxTetherSpam();
            new FixLaddermenEnclosedKeep();
            new UnlimitedSiegeOnTowers();
            new ImproveAIWoodBuying();
        }
    }
}