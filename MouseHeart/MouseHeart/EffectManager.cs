using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MouseHeart
{
    class EffectManager
    {
        List<HealthEffect> MouseEffects = new List<HealthEffect>();
        public Mouse selfMouse;
        public  void  Initialize()
        {
            selfMouse = new Mouse();
            selfMouse.Start();
            AddEffectOnMouse( EffectNames.Aging);
        }
        public void AddEffectOnMouse(EffectNames EffectName)
        {
            switch (EffectName)
            {
                case EffectNames.Aging:
                    {
                        MouseEffects.Add(new Effects.Aging());
                        break;
                    }
            }
        }
        public void Update()
        {
            foreach (HealthEffect effect in MouseEffects) effect.Work(selfMouse);
        }
        public string MouseOrganStatus()
        {
             return                 "Br: " + selfMouse.Brain.CurrentLevel +
                                    " H: "  + selfMouse.Heart.CurrentLevel +
                                    " L: "  + selfMouse.Liver.CurrentLevel +
                                    " Lu: " + selfMouse.Lungs.CurrentLevel +
                                    " Bd: " + selfMouse.Blood.CurrentLevel +
                                    " P: "  + selfMouse.Pancreas.CurrentLevel ;
        }
    }
}
