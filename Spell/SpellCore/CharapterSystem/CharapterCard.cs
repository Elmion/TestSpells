using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SpellCore.CharapterSystem.ResurceEngine;

namespace SpellCore.CharapterSystem
{
   public class CharapterCard 
    {
        string Name;
        SpellBook Book;
        public  Dictionary<string, Feature> Features;
        public Health CharapterHealth;
        private BaseCharapter baseCharapter;

        private List<IEffect> Effects { get; set; }

        public CharapterCard(BaseCharapter baseCharapter)
        {
            Book = new SpellBook();
            Features = new Dictionary<string, Feature>();
            Effects = new List<IEffect>();
            CharapterHealth = new Health(baseCharapter);
        }
        public void Init()
        {
            CharapterHealth.Reset();
        }
        //Добавляет характеристику в класс в класс
        internal void AddFeature(string Name , Feature feature)
        {
            Features.Add(Name, feature);
        }
        internal bool isLernSpell(string nameSpell)
        {
           return Book.FindSpell(nameSpell) != null ? true:false;
        }
        internal bool hasSpellEffect(string nameSpell)
        {
            throw (new NotImplementedException());
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
