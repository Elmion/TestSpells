using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CharapterCards;
namespace FormulasStorage
{
    public class Formula
    {
        //Максимальные базовые жизни
        public static float GetMaxBaseHealth(CharapterCard cc)
        {
            return cc.GetFeature("Vitality").Value * 100;
        }
        //Формула пробивания щита/брони
        public static float GetPenetrationDamage(AttackModule InputAttackModule, Type type)
        {
            return InputAttackModule.DamageValue * (float)InputAttackModule.Penetrations[GetType()] / 100f;
        }
    }
}
