using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;

namespace CharapterCards
{
    class Resist : IResurcePipeBlock
    {

        public string nameBlock { get; }
        public float CurrentValue { get; set; }
        public int SortIndex { get; }
        public bool MarkToRemove { get { return false; } }//Неудаляемый блок
        public float MaxValue
        {
            get
            {
                return 100f;//Максимальное сопротивление
            }
        }
        public Keywords ResistName { get; set; }
        private CharapterCard Owner;
        private Dictionary<ResistEnum, float> ListResist;

        public Resist(CharapterCard ItemOwner,Keywords ResistName, float startValue)
        {
            Owner = ItemOwner;
            CurrentValue = startValue;
            this.ResistName = ResistName;
        }

        public AttackModule TakeExtarnalEffect(AttackModule InputAttackModule)
        {
            if(InputAttackModule.Data.ContainsKey(ResistName)) //если это физический урон
            {
                InputAttackModule.Value = InputAttackModule.Value*(1 - CurrentValue) / MaxValue;//срезали урон
            }
            return InputAttackModule;
        }
        public void Update()
        {

        }
    }
}
