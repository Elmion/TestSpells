using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    public class Item
    {
        public readonly static List<TableRifineItem> TableRefine = new List<TableRifineItem>();
        static Random rnd = new Random((int)DateTime.Now.Ticks);
        public int level = 10;
        public static void Init()
        {
            TableRefine.Add(new TableRifineItem() { toLevel = 1, chance = 100, Money = 3400, scrolls = 1, gems = 1 });
            TableRefine.Add(new TableRifineItem() { toLevel = 2, chance = 100, Money = 3400, scrolls = 1, gems = 1 });
            TableRefine.Add(new TableRifineItem() { toLevel = 3, chance = 100, Money = 3400, scrolls = 1, gems = 1 });
            TableRefine.Add(new TableRifineItem() { toLevel = 4, chance = 90, Money = 3400, scrolls = 1, gems = 1 });
            TableRefine.Add(new TableRifineItem() { toLevel = 5, chance = 80, Money = 3400, scrolls = 1, gems = 1 });
            TableRefine.Add(new TableRifineItem() { toLevel = 6, chance = 70, Money = 16700, scrolls = 2, gems = 2 });
            TableRefine.Add(new TableRifineItem() { toLevel = 7, chance = 60, Money = 16700, scrolls = 2, gems = 2 });
            TableRefine.Add(new TableRifineItem() { toLevel = 8, chance = 50, Money = 16700, scrolls = 2, gems = 3 });
            TableRefine.Add(new TableRifineItem() { toLevel = 9, chance = 45, Money = 16700, scrolls = 2, gems = 3 });
            TableRefine.Add(new TableRifineItem() { toLevel = 10, chance = 45, Money = 16700, scrolls = 2, gems = 4 });
            TableRefine.Add(new TableRifineItem() { toLevel = 11, chance = 45, Money = 33400, scrolls = 3, gems = 4 });
            TableRefine.Add(new TableRifineItem() { toLevel = 12, chance = 45, Money = 33400, scrolls = 3, gems = 5 });
            TableRefine.Add(new TableRifineItem() { toLevel = 13, chance = 45, Money = 33400, scrolls = 3, gems = 5 });
            TableRefine.Add(new TableRifineItem() { toLevel = 14, chance = 40, Money = 33400, scrolls = 3, gems = 6 });
            TableRefine.Add(new TableRifineItem() { toLevel = 15, chance = 40, Money = 33400, scrolls = 3, gems = 6 });
            TableRefine.Add(new TableRifineItem() { toLevel = 16, chance = 40, Money = 33400, scrolls = 4, gems = 7 });
            TableRefine.Add(new TableRifineItem() { toLevel = 17, chance = 40, Money = 66700, scrolls = 4, gems = 7 });
            TableRefine.Add(new TableRifineItem() { toLevel = 18, chance = 40, Money = 66700, scrolls = 4, gems = 8 });
            TableRefine.Add(new TableRifineItem() { toLevel = 19, chance = 35, Money = 66700, scrolls = 4, gems = 8 });
            TableRefine.Add(new TableRifineItem() { toLevel = 20, chance = 35, Money = 66700, scrolls = 4, gems = 9 });
            TableRefine.Add(new TableRifineItem() { toLevel = 21, chance = 35, Money = 66700, scrolls = 5, gems = 9 });
            TableRefine.Add(new TableRifineItem() { toLevel = 22, chance = 35, Money = 66700, scrolls = 5, gems = 10 });
            TableRefine.Add(new TableRifineItem() { toLevel = 23, chance = 35, Money = 66700, scrolls = 5, gems = 10 });
            TableRefine.Add(new TableRifineItem() { toLevel = 24, chance = 30, Money = 66700, scrolls = 5, gems = 11 });
            TableRefine.Add(new TableRifineItem() { toLevel = 25, chance = 30, Money = 66700, scrolls = 5, gems = 11 });
            TableRefine.Add(new TableRifineItem() { toLevel = 26, chance = 30, Money = 66700, scrolls = 6, gems = 12 });
            TableRefine.Add(new TableRifineItem() { toLevel = 27, chance = 30, Money = 100000, scrolls = 6, gems = 12 });
            TableRefine.Add(new TableRifineItem() { toLevel = 28, chance = 30, Money = 100000, scrolls = 6, gems = 13 });
            TableRefine.Add(new TableRifineItem() { toLevel = 29, chance = 25, Money = 100000, scrolls = 6, gems = 13 });
            TableRefine.Add(new TableRifineItem() { toLevel = 30, chance = 25, Money = 100000, scrolls = 6, gems = 14 });
        }
        public static bool Refine(Item i,int typeUp)
        {
            switch (typeUp)
            {
                //simple
                case 1:
                    if (rnd.Next(1, 100) <= TableRefine[i.level].chance)
                    {
                        i.level++;
                        return true;
                    }
                    else
                    {
                        if (!(i.level == 0 || i.level == 1 || i.level == 2 || i.level == 7 || i.level == 10 || i.level == 20))
                        {
                            i.level--;
                        }
                        return false;
                    }

                    break;
                //simple with gems
                case 2:
                    {
                        bool buf = rnd.Next(1, 100) <= TableRefine[i.level].chance;
                        if (buf)
                        {
                            i.level++;
                        }
                        return buf;
                    }
                //bless
                case 3:
                    if (rnd.Next(1, 100) <= TableRefine[i.level].chance)
                    {
                        i.level += rnd.Next(1, 4);
                        if (i.level > 30)
                            i.level = 30;
                        return true;
                    }
                    else
                    {
                        if (!(i.level == 0 || i.level == 1 || i.level == 2 || i.level == 7 || i.level == 10 || i.level == 20))
                        {
                            i.level--;
                        }
                        return false;
                    }
                //bless with gems
                case 4:
                    {
                        bool buf = rnd.Next(1, 100) <= TableRefine[i.level].chance;
                        if (buf)
                        {
                            i.level += rnd.Next(1, 4);
                            if (i.level > 30)
                                i.level = 30;
                        }
                        return buf;
                    }
            }
            return false;
        }
    }
    public class TableRifineItem
    {

        public int toLevel =1;
        public int chance = 100;
        public int Money = 3400;
        public int scrolls = 1;
        public int gems = 0;
    }

}
