using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CharapterCards;
using Common;
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
            return InputAttackModule.Value * (float)InputAttackModule.Data[Keywords.ShieldPenetration] / 100f;
        }
    }
}
