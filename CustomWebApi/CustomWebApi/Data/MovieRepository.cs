using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CustomWebApi.Contracts;
using CustomWebApi.Models;
using CustomWebApi.Data;

namespace CustomWebApi.Data
{
    public class MovieRepository : RepositoryBase<Movie>, IMovieRepository
    {
        public MovieRepository(ApplicationContext applicationContext) : base(applicationContext)
        {

        }
    }
}
