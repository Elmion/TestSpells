using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpellCore
{
    class SceneItem : IEqualityComparer<SceneItem>
    {
       public string Name { get; set; }
       public Guid UN { get; set; }
       public float X { get; set; }
       public float Y { get; set; }
       public bool onScene { get; set; }

       public  SceneItem()
        {
            Name = "NoName";
            X = 0;
            Y = 0;
            UN = Guid.NewGuid();
            onScene = false;
        }
        public bool Equals(SceneItem x, SceneItem y)
        {
            if (x.UN == y.UN)
            {
                return true;
            }
            return false;
        }

        public int GetHashCode(SceneItem obj)
        {
            return (int)((X + Y) * 10000);//просто константа вообещ что угодно может быть
        }
        internal bool PlaceAt(float x, float y)
        {
            //тут ещё нужны проверки на возможность поставить 
            X = x;
            Y = y;
            return true;
        }
    }
}
