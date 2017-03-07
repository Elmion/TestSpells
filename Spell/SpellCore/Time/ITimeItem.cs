using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpellCore.Time
{
    interface ITimeItem
    {
       int TimeStamp { get; set; }
       Action<object> Reaction { get; set;}
       HistoryItem SaveCurrentState(); 
    }
}
