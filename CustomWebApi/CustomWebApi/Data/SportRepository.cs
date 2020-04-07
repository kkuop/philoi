using CustomWebApi.Contracts;
using CustomWebApi.Data;
using CustomWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomWebApi.Data
{
    public class SportRepository : RepositoryBase<Sport>, ISportRepository
    {
        public SportRepository(ApplicationContext applicationContext) : base(applicationContext)
        {

        }
    }
}
