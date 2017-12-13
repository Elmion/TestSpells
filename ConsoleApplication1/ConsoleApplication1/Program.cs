using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        //const int TRYCOUNT = 200000000;
        static void Main(string[] args)
        {
            Item.Init();
            Item item = new Item();
            int countScrols = 0;
            long MoneyCount = 0;
            int GemsCount = 0;
            List<int> perfocarta = new List<int>() { 1, 1, 1, 1, 1,
                                                     1, 1, 1, 1, 1,
                                                     1, 1, 1, 3, 3,
                                                     3, 4, 4, 4, 1,
                                                     1, 1, 1, 1, 3,
                                                     3, 4, 4, 4, 4 };
            while (item.level != 30)
            {

                if (Item.Refine(item, perfocarta[item.level]))
                {
                    countScrols += Item.TableRefine[item.level - 1].scrolls;
                    MoneyCount += Item.TableRefine[item.level - 1].Money;
                    GemsCount += Item.TableRefine[item.level - 1].gems;
                }
                else
                {
                    countScrols += Item.TableRefine[item.level].scrolls;
                    MoneyCount += Item.TableRefine[item.level].Money;
                    GemsCount += Item.TableRefine[item.level].gems;
                }
                Console.WriteLine("".PadLeft(item.level, '='));
            }


            Console.WriteLine("Scroll: "+ countScrols);
            Console.WriteLine("Money: " + MoneyCount);
            Console.WriteLine("GemsCount: " + GemsCount);
            Console.ReadKey();

        }


    }
}
