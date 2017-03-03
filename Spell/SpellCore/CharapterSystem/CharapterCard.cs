using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpellCore.CharapterSystem
{
    class CharapterCard 
    {
        string Name;
        SpellBook Book;
        Dictionary<string, IFeature> Features;
        Dictionary<Guid, IEffect> Effects;

        public CharapterCard()
        {
            Book = new SpellBook();
            Features = new Dictionary<string, IFeature>();
            Effects = new Dictionary<Guid, IEffect>();
        }
        //Добавляет характеристику в класс в класс
        internal void AddFeature(string Name , IFeature feature)
        {
            Features.Add(Name, feature);
        }
        internal bool hasSpell(string nameSpell)
        {
            Book.FindSpell(nameSpell);
        }
    }
}
