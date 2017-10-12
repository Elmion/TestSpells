using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MouseHeart.Effects
{
    class Aging : HealthEffect
    {

        const float  SPEED_AGING = 0.001f;
        public override void Work(Mouse selfMouse)
        {
            base.Work(selfMouse);
            selfMouse.Brain.Sub(SPEED_AGING);
            selfMouse.Heart.Sub(SPEED_AGING);
            selfMouse.Lungs.Sub(SPEED_AGING);
            selfMouse.Pancreas.Sub(SPEED_AGING);
            selfMouse.Liver.Sub(SPEED_AGING);
            
        }
    }
}
