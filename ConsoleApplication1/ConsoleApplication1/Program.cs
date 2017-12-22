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

            Random r = new Random();
            List<int> Prices = new List<int>();
            List<FinishArray> arr = new List<FinishArray>();
            // StatisticPreEchance statistic = new StatisticPreEchance();
            List<int> perfocarta = new List<int>() { 0, 0, 0, 0, 0,
                                                         0, 0, 0, 0, 0,
                                                         0, 0, 0, 0, 0,
                                                         0, 0, 0, 0, 0,
                                                         0, 0, 0, 0, 0,
                                                         0, 0, 0, 0, 0 };
            Perfocarta card = new Perfocarta();
            while(card.Increment())
            { 

                Prices.Clear();
                int i = 0;
                while (i < 20)
                {
                    
                    ItemEquipment item = new ItemEquipment();
                    while (item.CurrentRefine <= 29)
                    {
                        item.Refine(card.card[item.CurrentRefine]);

                    }
                    Prices.Add(item.GetBuildPrice(card.card));
                    //item.GetReport(perfocarta);
                    i++;
                }
                Prices = Normalize(Prices, 0.02f, 0.98f);

                FinishArray f = new FinishArray();
                f.card = ConvertPerfocarta(card.card);
                f.price = CalcAvg(Prices);
                arr.Add( f);

            }
            int numPositionTop = 0;
            for (int i = 0; i < arr.Count; i++)
            {
                if (arr[numPositionTop].price < arr[i].price)
                    numPositionTop = i;
            }
            Console.WriteLine("Map:" + arr[numPositionTop].card);
            Console.WriteLine("Price:" + arr[numPositionTop].price);

            Console.ReadKey();
        }

        private class FinishArray
        {
           public  string card;
           public  long price;
        }
        public static string ConvertPerfocarta (List<int> numbers)
        {
            string OUT = "";
            for (int i = 0; i < numbers.Count; i++)
            {
                OUT += numbers[i].ToString();
            }
            return OUT;
        }
        public static long CalcAvg(List<int> numbers)
        {
            long OUT = 0;
            for (int i = 0; i < numbers.Count; i++)
            {
                OUT += numbers[i];
            }
            return OUT / numbers.Count;
        }

        public static List<int> Normalize(List<int> numbers, float MinLimit, float MaxLimit)
        {
            int Min = int.MaxValue;
            int Max = int.MinValue;
            for (int i = 0; i < numbers.Count; i++)
            {
                if (Min > numbers[i]) Min = numbers[i];
                if (Max < numbers[i]) Max = numbers[i];
            }
            //Console.WriteLine("MinIN:" + Min);
            //Console.WriteLine("MaxIN:" + Max);

            Max = (int)(Max * MaxLimit);
            Min = (int)(Max * (Min/Max + MinLimit));
            //Console.WriteLine("MinOUT:" + Min);
            //Console.WriteLine("MaxOUT:" + Max);
            List<int> OUT = new List<int>();
            for (int i = 0; i < numbers.Count; i++)
            {
                if(numbers[i] >= Min && numbers[i] <= Max)
                {
                    OUT.Add(numbers[i]);
                }
            }
            return OUT;
        }
        
        //public class StatisticPreEchance
        //{
        //    public List<int> PreLevelTry = new List<int>();
        //    public int blessedTotal = 0;
        //    public int simpleTotal = 0;
        //    public long MoneyCount = 0;
        //    public int GemsCount = 0;
        //    public StatisticPreEchance()
        //    {
        //        for (int i = 0; i < 30; i++)
        //        {
        //            PreLevelTry.Add(0);
        //        }  
        //    }
        //    public void PrintStatistic()
        //    {
        //        for (int i = 0; i < PreLevelTry.Count; i++)
        //        {
        //            Console.WriteLine((i+1) + " : " + PreLevelTry[i]);
        //        }
        //        Console.WriteLine("SIMPLE : " + simpleTotal);
        //        Console.WriteLine("BLESSED: " + blessedTotal);
        //        Console.WriteLine("MONEY  : " + MoneyCount);
        //        Console.WriteLine("GEMS   : " + GemsCount);
        //    }
        //    public void UpdateStatistic(bool b, int type, int level )
        //    {
        //        if(b)
        //        {
        //            PreLevelTry[level] += Item.TableRefine[level-1].scrolls;
        //        }
        //        else
        //        {
        //            if(level != 7 || level != 10 || level !=20)
        //            PreLevelTry[level] += Item.TableRefine[level - 1].scrolls;
        //        }
                
        //        if(type == 4 || type == 3)
        //        {
        //            blessedTotal += Item.TableRefine[level].scrolls;
        //        }
        //        else
        //        {
        //            simpleTotal += Item.TableRefine[level].scrolls;
        //        }
        //        if (type == 4 || type == 2)
        //        {
        //            GemsCount += Item.TableRefine[level].gems;
        //        }

        //    }
        //}

    }
}
