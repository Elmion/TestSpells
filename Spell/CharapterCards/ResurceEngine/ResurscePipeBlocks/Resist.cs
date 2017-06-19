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

        public Keywords[] Tags
        {
            get
            {
                return new Keywords[] { Keywords.Resist };
            }
        }
        public bool MarkToRemove  { get { return false; }}//Неудаляемый блок
        public float CurrentValue { get; set; }
        public float MaxValue
        {
            get
            {
                return 100f;//Максимальное сопротивление
            }
        }

        private CharapterCard Owner;
        private Dictionary<ResistEnum, float> ListResist;

        public Resist(CharapterCard ItemOwner)
        {
            Owner = ItemOwner;
            ListResist = new Dictionary<ResistEnum, float>();
            foreach (ResistEnum item in Enum.GetValues(typeof(ResistEnum))) ListResist.Add(item, 0); //Добавили все сопротивления с нулевыми значениями
        }
        public AttackModule TakeExtarnalEffect(AttackModule InputAttackModule)
        {
            switch (InputAttackModule.ProccesingType)
            {
                case ModuleEffectTypes.Damage:
                    if (CurrentValue - InputAttackModule.DamageValue > 0)
                    {
                        CurrentValue -= InputAttackModule.DamageValue;
                        InputAttackModule.DamageValue = 0;
                    }
                    else
                    {
                        float valueOut = InputAttackModule.DamageValue - CurrentValue;
                        CurrentValue = 0;
                        InputAttackModule.DamageValue = valueOut;
                    }
                    break;
                case ModuleEffectTypes.Restore:
                    float buffMaxValue = MaxValue; //буфферизируем чтоб не гонять
                    float Missing = buffMaxValue - CurrentValue;
                    if (Missing != 0)
                    {
                        CurrentValue += InputAttackModule.DamageValue;
                        if (CurrentValue > buffMaxValue)
                            InputAttackModule.DamageValue = CurrentValue - buffMaxValue;
                        else
                            InputAttackModule.DamageValue = 0;
                    }
                    break;
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
