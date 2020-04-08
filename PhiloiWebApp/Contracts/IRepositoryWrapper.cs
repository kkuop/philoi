using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhiloiWebApp.Contracts
{
    public interface IRepositoryWrapper
    {
        IUserRepository User { get; }
        IInterestRepository Interest { get; }
        ICategoryRepository Category { get; }
        
        IUserInterestRepository UserInterest { get; }
        void Save();
    }
}
