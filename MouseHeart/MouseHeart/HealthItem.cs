using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MouseHeart
{
    class HealthItem
    {
        public float CurrentLevel { get; set; }

        public void Update()
        {

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
