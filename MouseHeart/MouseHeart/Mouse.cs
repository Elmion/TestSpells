using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MouseHeart
{
    class Mouse
    {

        public HealthItem HP;
        public HealthItem Hangry;
        public HealthItem Stamina;

        public HealthItem Brain;
        public HealthItem Heart;
        public HealthItem Liver;
        public HealthItem Pancreas;
        public HealthItem Lungs;
        public HealthItem Blood;

        public Mouse()
        {
         HP = new HealthItem();
         Hangry = new HealthItem();
         Stamina = new HealthItem();

         Brain = new HealthItem();
         Heart = new HealthItem();
         Liver = new HealthItem();
         Pancreas = new HealthItem();
         Lungs = new HealthItem();
         Blood = new HealthItem();
    }
        public void Start()
        {

            Brain.CurrentLevel = 100; 
            Heart.CurrentLevel = 100;
            Liver.CurrentLevel = 100;
            Pancreas.CurrentLevel = 100;
            Lungs.CurrentLevel = 100;
            Blood.CurrentLevel = 100;
        } 
        
    }
   

}
