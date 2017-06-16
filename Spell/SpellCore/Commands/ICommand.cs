using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpellCore.Commands
{
    public interface ICommand
    {
        //bool CommandRight { get; }
        object Execute();
    }
}
