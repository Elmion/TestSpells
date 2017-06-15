using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpellCore.CharapterSystem
{
   public class BaseCharapter : SceneItem
    {
       public readonly CharapterCard Card;//карта персонажа 
       public BaseCharapter(Type CharapterClass) : base()
        {
            if (CharapterClass == typeof(Mage))
            {
                Card = new Mage(this);
            }
            if(Card != null) Card.Init();
        }

        internal bool inRange(BaseCharapter t)
        {
            throw new NotImplementedException();
        }
        #region Возможно стоит это переделать или унести в другое место
        /// <summary>
        /// Проверяем видит ли персонаж цель (для jRPG мы видим всегда. Для Actiona надо задать метод определяющий видимость
        /// в CoreSetup
        /// </summary>
        /// <param name="target"></param>
        /// <returns></returns>
        internal virtual bool isSee(BaseCharapter target,string nameSpell)
        {

            //Здесь при реализации дописать анализ зависимоти спелла от видиости
            if (CoreSetup.isSee.Method != null)
            {
                return CoreSetup.isSee(target);
            }
            else
            {
                //значение по умолчанию
                return true;
            }
        }
        /// <summary>
        /// Проверяем растояние до цели 
        /// </summary>
        /// <param name="target"></param>
        /// <returns></returns>
        internal virtual bool inRange(BaseCharapter target, string nameSpell)
        {

            //Здесь при реализации дописать анализ зависимоти спелла от растояния
            if (CoreSetup.inRange.Method != null)
            {
                return CoreSetup.inRange(target);
            }
            else
            {
                //значение по умолчанию
                return true;
            }
        } 
        #endregion
        
    }
}
