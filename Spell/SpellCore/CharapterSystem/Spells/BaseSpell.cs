using SpellCore.Time;
using System;
using System.Collections.Generic;

namespace SpellCore.CharapterSystem
{
    class BaseSpell 
    {
        // Они тут потому что надо не забыть----------
        int isSee;
        int inRange;
        internal int CastingTime { get; set; }
        internal int FlyTime { get; set; }
        internal SpellStage StageSpell { get; set; }
    //--------------------------------------------
    Dictionary<ITrigger, IEffect> EffectProcess;

        public void Execute()
        {
            foreach (ITrigger trigger in EffectProcess.Keys)
            {
                if (trigger.Check())
                    EffectProcess[trigger].PutOnBoard();
            }
        }
    }
    internal enum SpellStage
    {
        CastingStart,
        CastingProcess,
        CastingEnd,
        Fly,
        Collision,
        Apply
    }
}
