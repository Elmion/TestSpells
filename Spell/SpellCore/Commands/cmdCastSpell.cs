using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SpellCore.CharapterSystem;
namespace SpellCore.Commands
{
    class cmdCastSpell : ICommand
    {
        public bool CommandRight { get; private set; }
        Core core;
        string nameSpell;
        BaseCharapter owner;
        BaseCharapter target;
        public cmdCastSpell(Core core, string nameSpell, BaseCharapter owner, BaseCharapter target)
        {
            this.core      = core;
            this.nameSpell = nameSpell;
            this.owner     = owner;
            this.target    = target;
        }
        public object Excute()
        {
           return GreatLibrary.StartCastSpell(nameSpell,owner, target);
        }
    }
}
