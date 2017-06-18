using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharapterCards
{
   public class CharapterCard 
    {
        string Name;
        public  Dictionary<string, Feature> Features;
        public  BaseResurce Health;
        public  BaseResurce Mana;

        public CharapterCard()
        {
            Features = new Dictionary<string, Feature>();
            Health = new BaseResurce(this);
            Mana = new BaseResurce(this);
        }
        public void Init()
        {
            //CharapterHealth.Reset();
        }
        //Добавляет характеристику в класс в класс
        internal void AddFeature(string Name , Feature feature)
        {
            Features.Add(Name, feature);
        }
        internal bool hasSpellEffect(string nameSpell)
        {
            throw (new NotImplementedException());
        }
        public Feature GetFeature(string name)
        {
            return Features[name];
        }
    }
}
