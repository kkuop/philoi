using PhiloiWebApp.Abstract_Classes;
using PhiloiWebApp.Contracts;
using PhiloiWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhiloiWebApp.Data
{
    public class UserRepository : RepositoryBase<User>, IUserRepository
    {
        public UserRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
        {
            
        }
    }
}
