﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhiloiWebApp.Contracts
{
    public interface IRepositoryWrapper
    {
        IUserRepository User { get; }
        void Save();
    }
}