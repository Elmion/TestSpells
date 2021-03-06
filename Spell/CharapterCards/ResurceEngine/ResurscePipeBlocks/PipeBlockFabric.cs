﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharapterCards
{
    class PipeBlockFabric
    {
        public static IResurcePipeBlock Create(string s,CharapterCard card, params object[] arg)
        {
            switch (s)
            {
                case "BaseHealth":
                    {
                            return new BaseHealth(card,0);
                    }
                case "BaseShield":
                    {
                        if(arg.Length == 1)
                            return new BaseShield(card,3, (float)arg[0]);
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
