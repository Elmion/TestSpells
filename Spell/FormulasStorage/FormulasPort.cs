using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CharapterCards;
using SpellCore;
using SpellCore.CharapterSystem;
namespace FormulasStorage
{
   public class FormulasPort
    {
        public static void Initialize(BaseCharapter  bc)
        {
            FormulasConnector.MaxBaseHealth = Formula.GetMaxBaseHealth;
            FormulasConnector.GetPenetrationDamage = Formula.GetPenetrationDamage;
        }

    }
}
