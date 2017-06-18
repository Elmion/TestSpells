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
           return command.Execute();
        }
    }
}
