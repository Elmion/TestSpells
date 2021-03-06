﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;
namespace CharapterCards
{
    public interface IResurcePipeBlock
    {
        string nameBlock { get; }
        AttackModule TakeExtarnalEffect(AttackModule InputAttackModule);
        float MaxValue { get; }
        bool  MarkToRemove { get; }
        float CurrentValue { get; }
        int   SortIndex { get; }
    }
}
