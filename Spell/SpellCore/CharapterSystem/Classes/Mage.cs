using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpellCore.CharapterSystem
{
    class Mage:CharapterCard
    {
        public Mage(BaseCharapter doll) : base(doll)
        {
            Features.Add("Intellect", new Feature(10));
            Features.Add("Vitality", new Feature(10));
        }
    }
}
