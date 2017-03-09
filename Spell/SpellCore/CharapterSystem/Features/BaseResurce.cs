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
        public void AddNewBlock(IResurcePipeBlock block)
        {
            PipeBlocks.Add(block);
        }
        public bool RemoveBlock (IResurcePipeBlock block)
        {
            return PipeBlocks.Remove(block);
        }
        public void RegModificatorChanger(string mod)
        {
            IResurcePipeBlock blockWithModificator;
            foreach (var block in PipeBlocks)
            {
                if(block.hasModificator(mod))
                {
                    blockWithModificator = block;
                    break;
                }
            }
            if(blockWithModificator != null) blockWithModificator[mod].AddOrigin()//////////?????????????????????????????
        }
        public void UnRegModificatorChanger()
        {

        }
    }
    interface IResurcePipeBlock
    {
        IPipeBlockFeature this[string name] {get;set;}
        float Value { get; set; }
        float MaxValue { get; }
        bool hasModificator(string mod);
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
        private Dictionary<string, IPipeBlockFeature> Modificators;
        public IPipeBlockFeature this[string name]
        {
            get
            {
                return Modificators[name];
            }
            set
            {

            }
        }
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
            Modificators.Add("BaseHealth" ,     new BaseHealth());
            Modificators.Add("InventoryHealth", new InventoryHealth());
            Modificators.Add("SpellHealth",     new SpellHealth());
            Value = MaxValue;
        }
        public bool  hasModificator(string mod)
        {
            return Modificators.Keys.Contains<string>(mod);
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
