using CustomWebApi.Contracts;
using CustomWebApi.Data;
using CustomWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomWebApi.Data
{
    public class MusicRepository : RepositoryBase<Music>, IMusicRepository
    {
        public MusicRepository(ApplicationContext applicationContext) : base(applicationContext)
        {

        }
    }
}
