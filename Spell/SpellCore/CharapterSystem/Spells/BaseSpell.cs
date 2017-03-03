using System;
using System.Collections.Generic;

namespace SpellCore.CharapterSystem
{
    class BaseSpell
    {
        // Они тут потому что надо не забыть----------
        int isSee;
        int inRange;
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
        public void Cast(CharapterCard owner, CharapterCard target)
        {

        }
    }
}
