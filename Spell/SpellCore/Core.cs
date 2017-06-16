using SpellCore.CharapterSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SpellCore.Time;
using SpellCore.Commands;
namespace SpellCore
{
    /// <summary>
    /// Единая точка входа для стороних систем
    /// Пока преимущественно расматриваем вариант jRPG как самый простой варинат кастовки заклинаний
    /// </summary>
    public class Core
    {
        public TimeLine Time { get; private set; }
        public List<BaseCharapter> Actors;
        //Нужна инициализация
        public void Initialize()
        {
            Time = new TimeLine();
            Actors = new List<BaseCharapter>();

        }
        public object Run(ICommand command)
        {
            if (command.CommandRight)
                return command.Execute();
            else
                return null;
        }
        //Статичные методы

        //Возможно нужно будет ещё одна ветка методов с удалением без активирования последствий
        //но пока что так.
        public bool RemoveSpellFromObject(string nameSpell, object target)
        {
            if (target is BaseCharapter)
            {
                BaseCharapter t = target as BaseCharapter;
                if (t.Card.hasSpellEffect(nameSpell))//тут будут ещё условия например на дальность.
                {
                    //Здесь сам каст пока не знаю как будет выглядеть
                    GreatLibrary.SystemDispell(nameSpell, target);
                }
            }
            return true;
        }
        public static BaseCharapter CreateCharapter(string charapterClass)
        {

        }
    }
}
