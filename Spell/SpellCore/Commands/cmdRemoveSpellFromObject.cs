using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SpellCore.CharapterSystem;

namespace SpellCore.Commands
{

    //Возможно нужно будет ещё одна ветка методов с удалением без активирования последствий
    //но пока что так.
    class cmdRemoveSpellFromObject :ICommand
    {
        Core core;
        string spellname;
        BaseCharapter target;
        public cmdRemoveSpellFromObject(Core core,string spellname,BaseCharapter target)
        {
            this.core = core;
            this.spellname = spellname;
            this.target = target;
        }

        public object Execute()
        {
            //if (target.Card.hasSpellEffect(spellname))//тут будут ещё условия например на дальность.
            //   {
            //            //Здесь сам каст пока не знаю как будет выглядеть
            //            GreatLibrary.SystemDispell(spellname, target);
            //    }
            return true;
        }
    }
}
