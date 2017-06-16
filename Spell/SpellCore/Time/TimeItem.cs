using SpellCore.CharapterSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpellCore.Time
{
    public class TimeItem : ITimeItem
    {
        public object Arg { get; set; }
        public Action<object> Reaction { get; set; }
        public int TimeStamp { get; set; }

        public HistoryItem SaveCurrentState()
        {
            throw new NotImplementedException();
        }
    }
}
