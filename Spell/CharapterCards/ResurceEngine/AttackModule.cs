using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;
namespace CharapterCards
{
    //Элементарная атака на ресурс
    public class AttackModule
    {
       //Имя атакуемого ресурса
       public string AttackedBaseResurceName { get; set; }
       //востановление или урон
       public AttackModuleType Type { get; private set; }
       //Количество лечения/урона и т п
       public float Value;
       //Стоимость расхода ресурса.
       public float Cost = 0;
       //Хозяин модуля, для обратной связи
       public CharapterCard owner;
       //Дополнительные опции которые могут содержать доп значения (Вроде игнорирования блоков)
       //Данные о прохождении блоков.каждый блок будет искать здесь нужные ему данные по ключевым словам
       public Dictionary<Keywords,object> Data { get; set; }
       //Дополнительные функции, которые могут использовать специфические блоки
       public Dictionary<Keywords,Func<object[],object>> ActionsChecks { get; set; } 

       public virtual void OnResurceDestroy(CharapterCard card)
        {

        }

        public virtual void OnResurceEnter(CharapterCard card)
        {

        }

        public virtual void OnResurceExit(CharapterCard card)
        {

        }

        public virtual void OnBlockEnter(CharapterCard card, IResurcePipeBlock block)
        {

        }

        public virtual void OnBlockExit(CharapterCard card, IResurcePipeBlock block)
        {

        }

        public virtual void OnBlockDestroy(CharapterCard card, IResurcePipeBlock block)
        {

        }
    }
    public enum AttackModuleType
    {
        None,
        Damage,
        Restore
    }
}
