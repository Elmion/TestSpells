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
    class FormulasPort
    {
       public void Initialize(BaseCharapter  bc)
        {
            FormulasConnector.MaxBaseHealth = Formula.GetMaxBaseHealth;
        }
    }
}
