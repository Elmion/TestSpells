using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SpellCore.CharapterSystem;
namespace SpellCore.Commands
{
    class cmdInterruptCastingSpell : ICommand
    {
        Core core;
        BaseCharapter target;
        public bool CommandRight { get; }
        public cmdInterruptCastingSpell(Core core, BaseCharapter target)
        {

        }       
        public object Execute()
        { 
         //  GreatLibrary.InterruptCastingSpell( target);
            return null;
        }
    }
}
