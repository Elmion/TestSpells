using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpellCore.CharapterSystem.ResurceEngine
{
    public class AttackModule
    {
       public AttackTypes ProccesingType { get; set; }
       public float ShildPenetration;
       public float ArmorPenetration;
       public float DamageValue;
       public float ManaCost;
       public string[] KeyWords { get; set; }
    }
    public enum AttackTypes
    {
        Standart,
        Restore,
        WithoutDamage,
        AfterBufferShild
    }
}
