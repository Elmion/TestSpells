using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;

namespace CharapterCards
{
   public class BaseHealth : IResurcePipeBlock
    {
        public Keywords[] Tags
                {
                    get
                    {
                        return new Keywords[] { Keywords.BaseHealth };
                    }
                }
        public bool  MarkToRemove { get; }
        public bool  ActiveBlock { get; private set; }
        public float CurrentValue { get; set; }

        private CharapterCard Owner;

        public float MaxValue
        {
            get
            {
                return FormulasConnector.MaxBaseHealth(Owner);
            }
        }
        public BaseHealth(CharapterCard ItemOwner)
        {
            ActiveBlock = true;
            Owner = ItemOwner;
            CurrentValue = MaxValue;
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
        public void Update()
        {

        }
    }
}
