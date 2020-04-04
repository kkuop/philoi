using PhiloiWebApp.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhiloiWebApp.Data
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private ApplicationDbContext _context;
        private IUserRepository _user;
        public IUserRepository User
        {
            get
            {
                if(_user == null)
                {
                    _user = new UserRepository(_context);
                }
                return _user;
            }
        }
        public RepositoryWrapper(ApplicationDbContext context)
        {
            _context = context;
        }
        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
