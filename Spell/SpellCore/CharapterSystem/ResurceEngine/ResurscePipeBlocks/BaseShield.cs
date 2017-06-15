using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpellCore.CharapterSystem.ResurceEngine.ResurscePipeBlocks
{
    public class BaseShield : IResurcePipeBlock
    {

        private BaseCharapter Owner;
        public bool ActiveBlock { get; set; }//Активный ли блок зависит от заклинаний наложеных на персонажа.
        public float Value { get; set; }
        public float MaxValue
        {
            get
            {
                return Formula.GetSizeShild(Owner);//Здесь должна быть велечина от спелла. но пока что так для общего тестирования
            }
        }
        public BaseShield(BaseCharapter ItemOwner)
        {
            ActiveBlock = false;//по умолчанию щит выключен
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
                            InputAttackModule.DamageValue = Value - buffMaxValue;
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
