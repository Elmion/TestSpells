using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SpellCore.Time;

namespace SpellCore.CharapterSystem
{
    //Единый центр для заклинаний
    class GreatLibrary
    {
        internal static bool StartCastSpell(string nameSpell, BaseCharapter owner, BaseCharapter target)
        {

            if (owner.Card.isLernSpell(nameSpell) && owner.isSee(target, nameSpell) && owner.inRange(target, nameSpell))//тут будут ещё условия например на дальность.
            {
                BaseSpell castingSpell = FindSpell(nameSpell);
                castingSpell.StageSpell = SpellStage.CastingStart;
                //ставим событие начала каста
                Time.TimeLine.Instance.ImmediatelyExecute( new TimeItem() { Arg = castingSpell,
                    Reaction = CastingStart
                } );
                //ставим событие после 
                Time.TimeLine.Instance.AddTimeItem(new TimeItem()
                {
                    TimeStamp = castingSpell.CastingTime,
                    Arg = castingSpell,
                    Reaction = CastingComplete
                });
                return true;//поставили в очереди

            }
            else
            {
                return false;
            }
        }

        internal static void CastingComplete(object arg)
        {
            
        }
        internal static void CastingStart(object arg)
        {
            Board.Instance.AddEffectOnBoard(arg as BaseSpell);
        }
        private static BaseSpell FindSpell(string nameSpell)
        {
            throw new NotImplementedException();
        }

        internal static void InterruptCastingSpell(string nameSpell, object owner)
        {
         
        }
        /// <summary>
        /// Удаляет любое заклинание. Помечаем как системный диспел чтоб разделить диспел заклинаний пользователя
        /// </summary>
        /// <param name="nameSpell"></param>
        /// <param name="target"></param>
        internal static void SystemDispell(string nameSpell, object target)
        {

        }
    }
}
