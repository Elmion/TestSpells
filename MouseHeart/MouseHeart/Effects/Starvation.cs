using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MouseHeart.Effects
{
    class Starvation : HealthEffect
    {
        int stage = 0;

        public override void Work(Mouse selfMouse)
        {
            base.Work(selfMouse);

            if (selfMouse.Hangry.CurrentLevel >= 80)
            {
                //Cытая мышка прибавляет в стамине

            }
            if(selfMouse.Hangry.CurrentLevel < 80 && selfMouse.Hangry.CurrentLevel < 50)
            {
                //Легкий голод доставялет легкий дискомфорт

            }
            if (selfMouse.Hangry.CurrentLevel < 80 && selfMouse.Hangry.CurrentLevel < 50)
            {
                //Легкий голод доставялет легкий дискомфорт

            }

        }
        

    }
}
