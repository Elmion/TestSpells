using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpellCore
{
    class SpellBook
    {  
        public CharapterSystem.BaseCharapter Owner;
        List<BaseSpell> spellBook;
        public SpellBook()
        {
            spellBook = new List<BaseSpell>();
        }
        public void AddSpell(BaseSpell spell)
        {
        }
        public void RemoveSpell(BaseSpell spell)
        {

        }
        public BaseSpell GetSpell(BaseSpell spell)
        {
            throw new Exception("Не реализовано");
        }
    }
}
