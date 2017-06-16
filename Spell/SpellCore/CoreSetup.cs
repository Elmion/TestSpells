using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpellCore
{
    /// <summary>
    /// Класс для настройки физических проверок, вроде провеки видимости, растояний и т п.
    /// Самих реализаций тут небудет, так как эта часть сильно можно различатся в зависимости от проекта. Собираем тут Action-ы 
    /// которые потом будут подсоеденяться где то со стороны. В остальном коде предусматриваем что 
    /// если этих методы не  подключены то возвращаем значения которые были бы актальны для jRPG
    /// однако остальную логику пишем исходя из того что это ActionRPG.
    /// </summary>
   class CoreSetup
    {
        public static Func<object, bool> isSee;
        public static Func<object, bool> inRange;
    }
}
