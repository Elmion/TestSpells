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
        public static float GetMaxBaseHealth(CharapterCard card)
        {
            return card.GetFeature("Vitality").Value * 10;
        }
    }
}
