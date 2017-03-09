using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpellCore.CharapterSystem.Features
{
    class BaseResurce
    {
        List<IResurcePipeBlock> PipeBlocks;
    }
    interface IResurcePipeBlock
    {
        bool  Active { get; set; }
        float Value { get; set; }
        float MaxValue { get; }
        //Входной выходной дамаг.. по сути тут формула уменьшения дамага проходящего через блок
        float TakeDamage(float inputDamage);
        //Востанавливает характеристику, если реализовано и отдаёт оверх хил
        float Restoration(float inputHeal);
    }
    interface IPipeBlockFeature
    {
        string Name { get; set; }
        float Amount { get; set; }
        void Recalculation();//обращается ко всем источникам для уточнения характеристики
        void AddOrigin(object origin,int powerOrigin);
        void RemoveOrigin(object origin);
    }
    class Health : IResurcePipeBlock
    {
        Dictionary<string,IPipeBlockFeature> Modificators;
        public bool Active { get; set; }
        public float Value { get; set; }
        public float MaxValue 
            {
                get
                    {
                        return Modificators["BaseHealth"].Amount + Modificators["InventoryHealth"].Amount + Modificators["SpellHealth"].Amount;
                    }
            }
        public Health(object ItemOwner)
        {
            Active = true;
            Modificators = new Dictionary<string, IPipeBlockFeature>();
            Modificators.Add("BaseHealth" ,     new BaseHealth(ItemOwner));
            Modificators.Add("InventoryHealth", new InventoryHealth(ItemOwner));
            Modificators.Add("SpellHealth",     new SpellHealth(ItemOwner));
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
    }

}
