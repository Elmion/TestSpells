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
        public  Dictionary<string, BaseResurce> Resurces;

        public CharapterCard()
        {
            Features  = new Dictionary<string, Feature>();
            Resurces =  new Dictionary<string, BaseResurce>();      
        }
        public void Init()
        {
            //CharapterHealth.Reset();
        }
        public void IncomingAttackModule(AttackModule module)
        {
            Resurces[module.AttackedBaseResurceName].TakeAttackModule(module);
        }
        //Добавляет характеристику в класс в класс
        internal void AddFeature(string Name)
        {
            Features.Add(Name, new Feature(0));
        }
        public void AddResurce(string Name)
        {
            if(!Resurces.Keys.Contains(Name))
                     Resurces.Add(Name, new BaseResurce(this));
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
