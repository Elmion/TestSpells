using System.Collections.Generic;

namespace SpellCore.CharapterSystem
{
    internal interface IEffect
    {
        //Источник эффекта
        object owner { get; set; }
        //Цель эффекта
        object target { get; set; }
        //Настраивает эффект
        void SetupEffectPower();
        //Проверяет может ли наложится эффект
        bool Check();
        //Выполнить эффект
        void Execute();
    }
}