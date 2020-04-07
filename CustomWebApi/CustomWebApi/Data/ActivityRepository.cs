using System;
using System.Collections.Generic;
using CustomWebApi.Models;
using System.Linq;
using System.Threading.Tasks;
using CustomWebApi.Contracts;
using CustomWebApi.Data;

namespace CustomWebApi.Data
{
    public class ActivityRepository : RepositoryBase<Activity>, IActivityRepository
    {
        public ActivityRepository(ApplicationContext applicationContext) : base(applicationContext)
        {

        }
    }
}
