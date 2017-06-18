using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharapterCards
{
    class PipeBlockFabric
    {
        public static IResurcePipeBlock Create(string s,params object[] arg)
        {
            switch (s)
            {
                case "BaseHealth":
                    {
                        if(arg.Length == 1)
                            return new BaseHealth((CharapterCard)arg[0]);
                        return null;
                    }
                case "BasicShield":
                    {
                        if(arg.Length == 2)
                            return new BaseShield((CharapterCard)arg[0], (float)arg[1]);
                        return null;
                    }
                default:
                    {
                        return null;
                    }
            }
        }
    }
}
