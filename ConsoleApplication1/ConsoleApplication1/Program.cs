using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        //const int TRYCOUNT = 200000000;

        static List<Task> tasks = new List<Task>();
        static List<Experiment> arr = new List<Experiment>();
        static Perfocarta card = new Perfocarta();
        static CancellationTokenSource cts = new CancellationTokenSource();
        static TaskFactory factory = new TaskFactory(
              cts.Token,
              TaskCreationOptions.PreferFairness,
              TaskContinuationOptions.ExecuteSynchronously, TaskScheduler.Current);

        static void Main(string[] args)
        {
            // StatisticPreEchance statistic = new StatisticPreEchance();
            bool test;
            do
            {
                test = OK();
                Task.WaitAll(tasks.ToArray());

            } while (test);

        }
        private static  bool OK()
        {
            tasks.Clear();
            for (int i = 0; i < 5; i++)
            {
                if (!card.Increment()) return false;
                arr.Add(new Experiment(card.Copy()));
                tasks.Add(factory.StartNew(arr[arr.Count-1].Calc));
            }
            return true;
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
