﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyHeroes
{
    public interface IUnitOfWork
    {
        void Save();
    }
}
