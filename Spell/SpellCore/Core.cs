using SpellCore.CharapterSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpellCore
{
    class Core
    {
        public static bool CastSpell(string nameSpell,object owner,object target)
        {
            if (owner is BaseCharapter && target is BaseCharapter)
            {
                BaseCharapter o = owner as BaseCharapter;
                BaseCharapter t = target as BaseCharapter;
                if(o.Card.hasSpell(nameSpell) && o.isSee(t,nameSpell) && o.inRange(t,nameSpell))//тут будут ещё условия например на дальность.
                {
                    //Здесь сам каст пока не знаю как будет выглядеть
                }
            }
           return true;
        }
    }
}
