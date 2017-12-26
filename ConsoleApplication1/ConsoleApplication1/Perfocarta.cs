using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Perfocarta
    {

        public List<int> card;
        public Perfocarta()
        {
            card = new List<int>() { 0, 0, 0, 0, 0,
                                                         0, 0, 0, 0, 0,
                                                         0, 0, 0, 0, 0,
                                                         0, 0, 0, 0, 0,
                                                         0, 0, 0, 0, 0,
                                                         0, 0, 0, 0, 0 };
        }
        public List<int> Copy()
        {
            return new List<int>(card);
        }
        public bool Increment()
        {
                card[0]++;

                card = Recurce(card, 0);
                if (card[29] >= 4)  return false;
                 return true;
        }
        List<int> Recurce(List<int> f,int positon)
        {
            if (positon < f.Count - 1)
            {
                if (f[positon] == 4)
                {
                    f[positon] = 0;

                    f[positon + 1]++;
                    f = Recurce(f, ++positon);

                }
            }
            return f;
        }
    }
}
