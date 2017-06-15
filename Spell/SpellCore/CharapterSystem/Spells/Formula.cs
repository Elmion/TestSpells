using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SpellCore.CharapterSystem;

namespace SpellCore
{
    public static class Formula
    {
        public static float GetMaxBaseHealth(BaseCharapter bc)
        {
            return bc.Card.GetFeature("Vitality").Value * 100;
        }
        public static float GetSizeShild(BaseCharapter bc)
        {
            return bc.Card.GetFeature("Intellect").Value * 5;
        }
    }
}
