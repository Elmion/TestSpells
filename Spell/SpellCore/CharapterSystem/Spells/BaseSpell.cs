using SpellCore.Time;
using System;
using System.Collections.Generic;

namespace SpellCore.CharapterSystem
{
    class BaseSpell 
    {
        // Они тут потому что надо не забыть----------
        bool Canceled; //заклинание отменено но ещё не удалено
        Guid id;
        int isSee;
        int inRange;
        internal int CastingTime { get; set; }
        internal int FlyTime { get; set; }
        internal SpellStage StageSpell { get; set; }
    //--------------------------------------------
        List<IEffect> EffectProcess;

        public List<IEffect> Execute()
        {
            
            List<IEffect> effectsOUT = new List<IEffect>();
            foreach (IEffect effect in EffectProcess)
            {
                if (effect.Check())
                    effectsOUT.Add(effect.Execute());
            }
            return effectsOUT;
        }
        public void Setup(object owner, object target)
        {
            StageSpell = SpellStage.CastingStart;
            foreach (IEffect effect in EffectProcess)
            {
                effect.owner = owner;
                effect.target = target;
                effect.SetupActions();
                effect.SetupEffectPower();
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
