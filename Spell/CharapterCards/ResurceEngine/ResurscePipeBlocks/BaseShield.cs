using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;
namespace CharapterCards
{
    public class BaseShield : IResurcePipeBlock
    {
        public Keywords[] Tags
        { 
            get 
                {
                 return new Keywords[] { Keywords.Shield };
                }

        }
        public float MaxValue { get; set; }
        public bool MarkToRemove
            {
                get
                {
                    if (CurrentValue <= 0) return true;
                    return false;
                }
            }

        private CharapterCard Owner;
        public bool ActiveBlock { get; set; }//Активный ли блок зависит от заклинаний наложеных на персонажа.
        public float CurrentValue { get; set; }


        public BaseShield(CharapterCard ShiedOwner,float MaxValue)
        {
            this.CurrentValue = this.MaxValue = MaxValue;
            Owner = ShiedOwner;
        }
        public AttackModule TakeExtarnalEffect(AttackModule InputAttackModule)
        {
            //Для начала отделим пробивший щит дамаг который пойдёт дальше
            float PenetrationDamage = 0f;
            if(InputAttackModule.Penetrations.ContainsKey(GetType()) && InputAttackModule.ProccesingType != ModuleEffectTypes.Restore)//Если есть такое пробивание и заклинание не востанавливающее
                {
                   //ФОРМУЛА ПРОБИВАНИЯ
                    PenetrationDamage = InputAttackModule.DamageValue * (float)InputAttackModule.Penetrations[GetType()] / 100f;
                    InputAttackModule.DamageValue -= PenetrationDamage;//Пока вычтем этот дамаг из расчёта он в любом случае идёт дальше
                }            
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
            InputAttackModule.DamageValue += PenetrationDamage;//Вернем пробавающий урон наместо
            return InputAttackModule;
        }
        public void Update()
        {

        }
    }
}
