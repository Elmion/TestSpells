using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;

namespace CharapterCards
{
    class PhisicResist : IResurcePipeBlock
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

        private CharapterCard Owner;
        private Dictionary<ResistEnum, float> ListResist;

        public PhisicResist(CharapterCard ItemOwner, float startValue)
        {
            Owner = ItemOwner;
            CurrentValue = startValue;
        }

        public AttackModule TakeExtarnalEffect(AttackModule InputAttackModule)
        {
            if(InputAttackModule.Data.ContainsKey(Keywords.PhisicDamage)) //если это физический урон
            {
                InputAttackModule.Value = InputAttackModule.Value*(1 - CurrentValue) / MaxValue;//срезали урон
            }
            return InputAttackModule;
        }
        public float this[ResistEnum typeResist]
        {
            get
            {
                return ListResist[typeResist];
            }
            set
            {
                ListResist[typeResist] = value;
            }
        }
        public void Update()
        {

        }
    }
}
