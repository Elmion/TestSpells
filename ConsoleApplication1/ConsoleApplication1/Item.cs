using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    public class ItemEquipment
    {
        List<RefinePoint> points = new List<RefinePoint>();
        public int CurrentRefine = 0;
        public ItemEquipment()
        {
            for (int i = 0; i < 30; i++)
            {
                points.Add(new RefinePoint(i));
            }
            points[7].Stable = true;
            points[10].Stable = true;
            points[20].Stable = true;
        }
        public bool Refine(int typeRefine)
        {
            int RefinedBy = 0;
            switch (typeRefine)
            {
                case 0:
                    {
                        RefinedBy = points[CurrentRefine].Refine(1, false);
                        break;
                    }
                case 1:
                    {
                        RefinedBy = points[CurrentRefine].Refine(1, true);
                        break;
                    }
                case 2:
                    {
                        RefinedBy = points[CurrentRefine].Refine(2, false);

                        break;
                    }
                case 3:
                    {
                        RefinedBy = points[CurrentRefine].Refine(2, true);
                        break;
                    }
                default:
                    break;
            }
            if (RefinedBy > 0)
            {
                if (CurrentRefine + RefinedBy > 30) RefinedBy = 30 - CurrentRefine;
                if (RefinedBy == 1) CurrentRefine++;
                if (RefinedBy == 2) { points[CurrentRefine + 1].RefineAuto(); CurrentRefine += 2; }
                if (RefinedBy == 3) { points[CurrentRefine + 1].RefineAuto(); points[CurrentRefine + 2].RefineAuto(); CurrentRefine += 3; }
                return true;
            }
            if (RefinedBy == -1) {
                                    CurrentRefine--;
                                    return false;
                                 }
            return true;
        }
        public void GetReport(List<int> Perfocarta)
        {
            for (int i = 0; i < 6; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write(((i * 5 + j) + ": ").PadRight(4));
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write((points[i * 5 + j].RefineTry.ToString()).PadLeft(7));
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write("|");
                }
                Console.WriteLine();
            }
            Console.WriteLine("Кри: " + GetBuildPrice(Perfocarta));
            Console.WriteLine();
        }
        public int GetBuildPrice(List<int> Perfocarta)
        {
            const int  gemPrice = 700;
            const int blessPrice = 741;
            const int simplePrice = 51;
            int TotalPrice = 0;
            for (int i = 0; i < Perfocarta.Count; i++)
            {
                switch (Perfocarta[i])
                {
                    case 0:
                        TotalPrice += simplePrice * points[i].RefineTry* DicRifine.GetRifinePropetryFor(i).scrolls;
                        break;
                    case 1:
                        TotalPrice += simplePrice * points[i].RefineTry * DicRifine.GetRifinePropetryFor(i).scrolls + gemPrice * points[i].RefineTry *DicRifine.GetRifinePropetryFor(i).gems;
                        break;
                    case 2:
                        TotalPrice += blessPrice * points[i].RefineTry * DicRifine.GetRifinePropetryFor(i).scrolls;
                        break;
                    case 3:
                        TotalPrice += blessPrice * points[i].RefineTry * DicRifine.GetRifinePropetryFor(i).scrolls + gemPrice * points[i].RefineTry * DicRifine.GetRifinePropetryFor(i).gems;
                        break;
                }   
            }
            return TotalPrice;
        }


    }
    public class DicRifine
    {
        private readonly static List<RefinePointProperty> TableRefine = new List<RefinePointProperty>();
        public static Random rnd = new Random();
        static DicRifine()
        {
            TableRefine.Add(new RefinePointProperty() { toLevel = 1, chance = 100, Money = 3400, scrolls = 1, gems = 1 });
            TableRefine.Add(new RefinePointProperty() { toLevel = 2, chance = 100, Money = 3400, scrolls = 1, gems = 1 });
            TableRefine.Add(new RefinePointProperty() { toLevel = 3, chance = 100, Money = 3400, scrolls = 1, gems = 1 });
            TableRefine.Add(new RefinePointProperty() { toLevel = 4, chance = 90, Money = 3400, scrolls = 1, gems = 1 });
            TableRefine.Add(new RefinePointProperty() { toLevel = 5, chance = 80, Money = 3400, scrolls = 1, gems = 1 });
            TableRefine.Add(new RefinePointProperty() { toLevel = 6, chance = 70, Money = 16700, scrolls = 2, gems = 2 });
            TableRefine.Add(new RefinePointProperty() { toLevel = 7, chance = 60, Money = 16700, scrolls = 2, gems = 2 });
            TableRefine.Add(new RefinePointProperty() { toLevel = 8, chance = 50, Money = 16700, scrolls = 2, gems = 3 });
            TableRefine.Add(new RefinePointProperty() { toLevel = 9, chance = 45, Money = 16700, scrolls = 2, gems = 3 });
            TableRefine.Add(new RefinePointProperty() { toLevel = 10, chance = 45, Money = 16700, scrolls = 2, gems = 4 });
            TableRefine.Add(new RefinePointProperty() { toLevel = 11, chance = 45, Money = 33400, scrolls = 3, gems = 4 });
            TableRefine.Add(new RefinePointProperty() { toLevel = 12, chance = 45, Money = 33400, scrolls = 3, gems = 5 });
            TableRefine.Add(new RefinePointProperty() { toLevel = 13, chance = 45, Money = 33400, scrolls = 3, gems = 5 });
            TableRefine.Add(new RefinePointProperty() { toLevel = 14, chance = 40, Money = 33400, scrolls = 3, gems = 6 });
            TableRefine.Add(new RefinePointProperty() { toLevel = 15, chance = 40, Money = 33400, scrolls = 3, gems = 6 });
            TableRefine.Add(new RefinePointProperty() { toLevel = 16, chance = 40, Money = 33400, scrolls = 4, gems = 7 });
            TableRefine.Add(new RefinePointProperty() { toLevel = 17, chance = 40, Money = 66700, scrolls = 4, gems = 7 });
            TableRefine.Add(new RefinePointProperty() { toLevel = 18, chance = 40, Money = 66700, scrolls = 4, gems = 8 });
            TableRefine.Add(new RefinePointProperty() { toLevel = 19, chance = 35, Money = 66700, scrolls = 4, gems = 8 });
            TableRefine.Add(new RefinePointProperty() { toLevel = 20, chance = 35, Money = 66700, scrolls = 4, gems = 9 });
            TableRefine.Add(new RefinePointProperty() { toLevel = 21, chance = 35, Money = 66700, scrolls = 5, gems = 9 });
            TableRefine.Add(new RefinePointProperty() { toLevel = 22, chance = 35, Money = 66700, scrolls = 5, gems = 10 });
            TableRefine.Add(new RefinePointProperty() { toLevel = 23, chance = 35, Money = 66700, scrolls = 5, gems = 10 });
            TableRefine.Add(new RefinePointProperty() { toLevel = 24, chance = 30, Money = 66700, scrolls = 5, gems = 11 });
            TableRefine.Add(new RefinePointProperty() { toLevel = 25, chance = 30, Money = 66700, scrolls = 5, gems = 11 });
            TableRefine.Add(new RefinePointProperty() { toLevel = 26, chance = 30, Money = 66700, scrolls = 6, gems = 12 });
            TableRefine.Add(new RefinePointProperty() { toLevel = 27, chance = 30, Money = 100000, scrolls = 6, gems = 12 });
            TableRefine.Add(new RefinePointProperty() { toLevel = 28, chance = 30, Money = 100000, scrolls = 6, gems = 13 });
            TableRefine.Add(new RefinePointProperty() { toLevel = 29, chance = 25, Money = 100000, scrolls = 6, gems = 13 });
            TableRefine.Add(new RefinePointProperty() { toLevel = 30, chance = 25, Money = 100000, scrolls = 6, gems = 14 });
        }
        public static RefinePointProperty GetRifinePropetryFor(int level)
        {
            return TableRefine[level];
        }
    }
    public class RefinePoint
    {
        public bool Stable = false;
        public bool Rifined = false;
        public int RefineTry = 0;
        RefinePointProperty property;
        public RefinePoint(int level)
        {
            property = DicRifine.GetRifinePropetryFor(level);
        }
        public void RefineAuto()
        {
            Rifined = true;
        }
        public int Refine(int typescroll, bool useGems)
        {
            RefineTry++;
            int rn = 0;
            lock(DicRifine.rnd)
            {
                rn = DicRifine.rnd.Next(1, 100);
            }
                    switch (typescroll)
                    {
                        //simple
                        case 1:
                            if (rn <= property.chance)
                            {
                                Rifined = true;
                                return 1;
                            }
                            else
                            {
                                if (Stable || useGems) return 0;
                                Rifined = false;
                                return -1;
                            }
                        //bless
                        case 2:
                            {
                                if (rn <= property.chance)
                                {
                                    Rifined = true;
                                    lock (DicRifine.rnd) return DicRifine.rnd.Next(1, 4);
                                }
                                else
                                {
                                    if (Stable || useGems) return 0;
                                    Rifined = false;
                                    return -1;
                                }
                            }
                        default: return 0;
                    }
        }
    }
    public class RefinePointProperty
    {

        public int toLevel =1;
        public int chance = 100;
        public int Money = 3400;
        public int scrolls = 1;
        public int gems = 0;
    }

}
