using SpellCore.CharapterSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpellCore
{
    class BaseSpell
    {
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
}
