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
        public object owner;

        public BaseResurce(object owner)
        {
            PipeBlocks = new List<IResurcePipeBlock>();
            this.owner = owner;
        }
        public IResurcePipeBlock this[Type PipeBlock]
        {
            get
            {
                return PipeBlocks.FirstOrDefault(x => x.GetType() == PipeBlock);
            }
        }
        public void AddNewBlock(IResurcePipeBlock block)
        {
            PipeBlocks.Add(block);
        }
        public bool RemoveBlock (IResurcePipeBlock block)
        {
            return PipeBlocks.Remove(block);
        }
    }
    interface IResurcePipeBlock
    {
        float Value { get; set; }
        float MaxValue { get; }
        //Входной выходной дамаг.. по сути тут формула уменьшения дамага проходящего через блок
        float TakeDamage(float inputDamage);
        //Востанавливает характеристику, если реализовано и отдаёт оверх хил
        float Restoration(float inputHeal);
    }
    class BaseHealth : IResurcePipeBlock
    {
        private object Owner;
        public bool Active { get; set; }
        public float Value { get; set; }
        public float MaxValue 
            {
                get
                    {
                        return ;
                    }
            }
        public BaseHealth(object ItemOwner)
        {
            Active = true;
            Owner = ItemOwner;
            Modificators = new List<IPipeBlockFeature>();
            Modificators.Add(new BaseHealth());
            Modificators.Add(new InventoryHealth());
            Modificators.Add(new SpellHealth());
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
