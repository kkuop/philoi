using PhiloiWebApp.Abstract_Classes;
using PhiloiWebApp.Contracts;
using PhiloiWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhiloiWebApp.Data
{
    public class InterestRepository : RepositoryBase<Interests>, IInterestRepository
    {
        public InterestRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
        {

        }
    }
}
