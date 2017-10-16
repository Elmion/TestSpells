using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MouseHeart
{
    class HealthItem
    {
        СalculationFormula Formula;
        public float CurrentLevel { get; set; }

        public void Update()
        {
           // CurrentLevel = Formula.Calculation();
        }
        public float GetStatus()
        {
            return 0;
        }
        public void Restore(float x)
        {
            CurrentLevel += x;
        }
        public void Sub(float x) 
        {
            CurrentLevel -= x;
        }
        public void RemoveEffect()
        {

        }
    }
}
