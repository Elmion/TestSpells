using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharapterCards
{
    public class FormulasConnector
    {
        public static Func<CharapterCard, float> MaxBaseHealth;
        public static Func<AttackModule,Type, float> GetPenetrationDamage;

    }
}

