using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomWebApi.Contracts
{
    public interface IRepositoryWrapper
    {
        IActivityRepository Activity { get; }
        IFandomRepository Fandom { get; }
        IMovieRepository Movie { get; }
        IMusicRepository Music { get; }
        ISportRepository Sport { get; }
        void Save();
    }
}
