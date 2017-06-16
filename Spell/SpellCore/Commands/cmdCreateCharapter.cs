using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SpellCore.CharapterSystem;
namespace SpellCore.Commands
{
    class cmdCreateCharapter: ICommand
    {
        Core core;
        BaseCharapter newCharapter;
        public cmdCreateCharapter(Core core, string charapterClass)
        {
            BaseCharapter chOUT = null;
            switch (charapterClass)
            {
                case "Mage":
                    {
                        chOUT = new BaseCharapter(typeof(Mage));
                        break;
                    }
            }
        }
        public object Execute()
        {
            core.Actors.Add(newCharapter);
            return true;
        }
    }
}
