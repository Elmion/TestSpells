using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;
namespace CharapterCards
{
    public class AttackModule
    {
       public ModuleEffectTypes ProccesingType { get; set; }

       public Dictionary<Type,object> Penetrations;///Словарик для игнорирования какой то частю урона указаной секции ResurcePipe

       public float DamageValue;

       public float ManaCost;

       public string[] KeyWords { get; set; }

        public Dictionary<string> DamageSaveStat; 

        public Dictionary<ResistEnum,float> CreateResistPenetration
        {

        }

        public Dictionary<StatusEnum,float> CreateStatusPenetration
        {

        }
        
    }

    public enum ModuleEffectTypes
    {
        Damage,
        Restore,
        WithoutDamage,
        AfterBufferShild
    }
}
