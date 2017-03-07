using System.Collections.Generic;

namespace SpellCore.CharapterSystem
{
    internal interface IEffect
    {

        //Ложит на стол эффект
        void PutOnBoard();
        //Собираем список эффектов
        void GetChangedFeatures();
        //Изменяем Значение фичи
        void ChangeSpellFeature(string feature);
        //Выполнить эффект
        void Execute();
    }

}