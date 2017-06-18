using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharapterCards
{
    public class AttackModule
    {
       public ModuleEffectTypes ProccesingType { get; set; }
       public float ShildPenetration;
       public float ArmorPenetration;
       public float DamageValue;
       public float ManaCost;
       public string[] KeyWords { get; set; }
    }
    public enum ModuleEffectTypes
    {
        Damage,
        Restore,
        WithoutDamage,
        AfterBufferShild
    }
}
