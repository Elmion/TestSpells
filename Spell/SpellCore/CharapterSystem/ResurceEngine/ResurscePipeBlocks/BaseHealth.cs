using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpellCore.CharapterSystem.ResurceEngine.ResurscePipeBlocks
{
   public class BaseHealth : IResurcePipeBlock
    {
        private BaseCharapter Owner;
        public bool ActiveBlock { get; private set; }
        public float Value { get; set; }
        public float MaxValue
        {
            get
            {
                return Formula.GetMaxBaseHealth(Owner);
            }
        }
        public BaseHealth(BaseCharapter ItemOwner)
        {
            ActiveBlock = true;
            Owner = ItemOwner;
        }
        public AttackModule TakeExtarnalEffect(AttackModule InputAttackModule)
        {
            switch (InputAttackModule.ProccesingType)
            {
                case AttackTypes.Standart:
                    if (Value - InputAttackModule.DamageValue > 0)
                    {
                        Value -= InputAttackModule.DamageValue;
                        InputAttackModule.DamageValue = 0;
                    }
                    else
                    {
                        float valueOut = InputAttackModule.DamageValue - Value;
                        Value = 0;
                        InputAttackModule.DamageValue = valueOut;
                    }
                    break;
                case AttackTypes.Restore:

                    float buffMaxValue = MaxValue; //буфферизируем чтоб не гонять
                    float Missing = buffMaxValue - Value;
                    if (Missing != 0)
                    {
                        Value += InputAttackModule.DamageValue;
                        if (Value > buffMaxValue)
                            InputAttackModule.DamageValue =  Value - buffMaxValue;
                        else
                            InputAttackModule.DamageValue = 0;
                    }
                    break;
            }
            return InputAttackModule;
        }
        public void Update()
        {

        }
        public void Reset()
        {
            Value = MaxValue;
        }

    }
}
