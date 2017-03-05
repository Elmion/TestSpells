using SpellCore.CharapterSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpellCore
{
    /// <summary>
    /// Единая точка входа для стороних систем
    /// Пока преимущественно расматриваем вариант jRPG как самый простой варинат кастовки заклинаний
    /// </summary>
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
                    GreatLibrary.StartCastSpell(nameSpell, owner, target);
                }
            }
           return true;
        }
        public static bool InterruptCastingSpell(string nameSpell, object owner)
        {
            if (owner is BaseCharapter)
            {
                BaseCharapter o = owner as BaseCharapter;
                if (o.Card.hasSpell(nameSpell))
                {
                    //Здесь сам каст пока не знаю как будет выглядеть
                    GreatLibrary.InterruptCastingSpell(nameSpell, owner);
                }
            }
            return true;
        }
        //Возможно нужно будет ещё одна ветка методов с удалением без активирования последствий
        //но пока что так.
        public static bool RemoveSpellFromObject(string nameSpell, object target)
        {
            if (target is BaseCharapter)
            {
                BaseCharapter t = target as BaseCharapter;
                if (t.Card.hasSpellEffect(nameSpell))//тут будут ещё условия например на дальность.
                {
                    //Здесь сам каст пока не знаю как будет выглядеть
                    GreatLibrary.Dispell(nameSpell, target);
                }
            }
            return true;
        }
    }
}
