using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Experiment
    {
        private List<int> card;
        private List<int> Prices;
        public Experiment(List<int> card)
            {
                this.card = new List<int>(card);
                Prices = new List<int>();
            }       
        public void Calc()
            {
                int i = 0;
                while (i < 20000)
                {
                    
                    ItemEquipment item = new ItemEquipment();
                    while (item.CurrentRefine <= 29)
                    {
                        item.Refine(card[item.CurrentRefine]);
                    }
                    Prices.Add(item.GetBuildPrice(card));
                    //item.GetReport(perfocarta);
                    i++;
                }
            }
    }
}
