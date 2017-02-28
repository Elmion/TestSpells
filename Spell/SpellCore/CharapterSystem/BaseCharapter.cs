using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpellCore.CharapterSystem
{
    class BaseCharapter
    {
        string Name;
        Dictionary<string, IFeature> Features;
        Dictionary<Guid, IEffect> IEffects;

    }
}
