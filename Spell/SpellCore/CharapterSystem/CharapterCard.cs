using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpellCore.CharapterSystem
{
   public class CharapterCard 
    {
        string Name;
        SpellBook Book;
        Dictionary<string, Feature> Features;

        private List<IEffect> Effects { get; set; }

        public CharapterCard()
        {
            Book = new SpellBook();
            Features = new Dictionary<string, Feature>();
            Effects = new List<IEffect>();
        }
        

        //Добавляет характеристику в класс в класс
        internal void AddFeature(string Name , Feature feature)
        {
            Features.Add(Name, feature);
        }
        internal bool isLernSpell(string nameSpell)
        {
            Book.FindSpell(nameSpell);
        }
        internal bool hasSpellEffect(string nameSpell)
        {
          
        }
        public List<IEffect> GetSpellsWithTags(EffectTag[] Tags)
        {
            List<IEffect> OutList = new List<IEffect>();
            for (int i = 0; i < Effects.Count; i++)
            {
                bool flag = false;
                for (int j = 0; j < Tags.Length; j++)
                {
                    if (Effects[i].tags.Contains(Tags[i])) flag = true;
                    if (!flag) break;
                }
                if (flag) OutList.Add(Effects[i]);
            }
            return  OutList;
        }
        public Feature GetFeature(string name)
        {
            return Features[name];
        }
    }
}
