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
       public string  NameDamageResurce { get; set; }
        
       public Dictionary<ResurceBlocks, object> Penetrations;///Словарик для игнорирования какой то частю урона указаной секции ResurcePipe

       public float DamageValue;

       public float StaminaCost;

       public string[] KeyWords { get; set; }
        
       public Dictionary<ResistEnum, float> ResistPenetration; //Срезка резистов  нужный резист 

       public List<StatusApplyItem> TryStatusApply;//Что пытаемся наложить -> его 
       public Dictionary<SaveStat, Func<AttackModule,AttackModule>> SaveApply; //Если сейф прошёл изменяем входящий модуль дамага;

       public List<ResurceBlocks> IngnoreBlocks;
    }

    public class StatusApplyItem
    {
        StatusEnum TryApply;
        Dictionary<SaveStat,float> MakeSaveBy; //сейв и дамаг по этому сейву
        Func<Keywords, AttackModule, AttackModule> SaveOK;
        Func<Keywords, AttackModule, AttackModule> SaveFail;
    }
    public class StatusApply : List<StatusApplyItem>
    {

    }

    public enum DamagedResurce
    {
        Common,
        Will,
        ,
        ,
        AfterBufferShild
    }

}
