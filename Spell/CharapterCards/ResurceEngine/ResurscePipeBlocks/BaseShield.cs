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
        public string nameBlock { get { return "BaseShield"; } }
        public float MaxValue { get { return CurrentValue; }}
        public bool  MarkToRemove
            {
                get
                {
                    if (CurrentValue <= 0) return true;
                    return false;
                }
            }
        public bool ActiveBlock { get; set; }//Активный ли блок зависит от заклинаний наложеных на персонажа.
        public float CurrentValue { get; set; }
        public int SortIndex { get; set; }

        private CharapterCard Owner;

        public BaseShield(CharapterCard ShiedOwner,int index, float ShieldValue)
        {
            this.CurrentValue += ShieldValue;
            Owner = ShiedOwner;
            SortIndex = index;
        }
        public AttackModule TakeExtarnalEffect(AttackModule InputAttackModule)
        {
           //Для начала отделим пробивший щит дамаг который пойдёт дальше
           float PenetrationDamage = 0f;
           if (InputAttackModule.Data.ContainsKey(Keywords.ShieldPenetration) && InputAttackModule.Type == AttackModuleType.Damage)
            {
                    //ФОРМУЛА ПРОБИВАНИЯ
                    PenetrationDamage = FormulasConnector.GetPenetrationDamage(InputAttackModule, GetType());
                    InputAttackModule.Value -= PenetrationDamage;//Пока вычтем этот дамаг из расчёта он в любом случае идёт дальше
            }
           switch (InputAttackModule.Type)
            {
                
                case AttackModuleType.Damage:
                    if (CurrentValue - InputAttackModule.Value > 0)
                    {
                        CurrentValue -= InputAttackModule.Value;
                        InputAttackModule.Value = 0;
                    }
                    else
                    {
                        float valueOut = InputAttackModule.Value - CurrentValue;
                        CurrentValue = 0;
                        InputAttackModule.Value = valueOut;
                    }
                    break;
                case AttackModuleType.Restore:

                    float buffMaxValue = MaxValue; //буфферизируем чтоб не гонять
                    float Missing = buffMaxValue - CurrentValue;
                    if (Missing != 0)
                    {
                        CurrentValue += InputAttackModule.Value;
                        if (CurrentValue > buffMaxValue)
                            InputAttackModule.Value = CurrentValue - buffMaxValue;
                        else
                            InputAttackModule.Value = 0;
                    }
                    break;
            }
            InputAttackModule.Value += PenetrationDamage;//Вернем пробавающий урон наместо
            return InputAttackModule;
        }
        public void Update()
        {

        }
    }
}
