using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpellCore.CharapterSystem
{
    interface IResurcePipeBlock
    {
        float Value { get; set; }
        float MaxValue { get; }
        //Входной выходной дамаг.. по сути тут формула уменьшения дамага проходящего через блок
        float TakeDamage(float inputDamage);
        //Востанавливает характеристику, если реализовано и отдаёт оверх хил
        float Restoration(float inputHeal);
        //Апдейт
        void Update();
    }
    class BaseHealth : IResurcePipeBlock
    {
        private BaseCharapter Owner;
        public bool Active { get; set; }
        public float Value { get; set; }
        public float MaxValue
        {
            get
            {
                return Formula.GetMaxBaseHealth(Owner.Card);
            }
        }
        public BaseHealth(BaseCharapter ItemOwner)
        {
            Active = true;
            Owner = ItemOwner;
            Value = MaxValue;
        }
        //востанавливаем до возможного максимума
        public float Restoration(float inputHeal)
        {
            float buffMaxValue = MaxValue; //буфферизируем чтоб не гонять
            float Missing = buffMaxValue - Value;
            if (Missing == 0) return inputHeal;
            else
            {
                Value += inputHeal;
                if (Value > buffMaxValue) return Value - buffMaxValue;
                else
                    return 0;
            }
        }
        public float TakeDamage(float inputDamage)
        {
            if (Value - inputDamage > 0)
            {
                Value -= inputDamage;
                return 0;
            }
            else
            {
                float valueOut = inputDamage - Value;
                Value = 0;
                return valueOut;
            }
        }
        public void Update()
        {

        }
    }
}
