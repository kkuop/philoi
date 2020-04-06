using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PhiloiWebApp.Abstract_Classes;
using PhiloiWebApp.Contracts;
using PhiloiWebApp.Models;

namespace PhiloiWebApp.Data
{
    public class CategoryRepository : RepositoryBase<Categories>, ICategoryRepository
    {
        public CategoryRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
        {

        }
    }
}
