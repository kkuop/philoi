using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CustomWebApi.Models;
using CustomWebApi.Contracts;
using CustomWebApi.Data;

namespace CustomWebApi.Data
{
    public class FandomRepository : RepositoryBase<Fandom>, IFandomRepository
    {
        public FandomRepository(ApplicationContext applicationContext) : base(applicationContext)
        {

        }
    }
}
