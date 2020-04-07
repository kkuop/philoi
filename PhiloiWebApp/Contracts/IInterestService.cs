using PhiloiWebApp.JSON_Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhiloiWebApp.Contracts
{
    public interface IInterestService
    {
        Task<Interest> GetActivities();
    }
}
