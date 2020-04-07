using CustomWebApi.Contracts;
using CustomWebApi.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomWebApi
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private ApplicationContext _context;
        private IActivityRepository _activity;
        private IFandomRepository _fandom;
        private IMovieRepository _movie;
        private IMusicRepository _music;
        private ISportRepository _sport;
        public IActivityRepository Activity
        {
            get
            {
                if(_activity == null)
                {
                    _activity = new ActivityRepository(_context);
                }
                return _activity;
            }
        }
        public IFandomRepository Fandom
        {
            get
            {
                if(_fandom == null)
                {
                    _fandom = new FandomRepository(_context);
                }
                return _fandom;
            }
        }
        public IMovieRepository Movie
        {
            get
            {
                if(_movie == null)
                {
                    _movie = new MovieRepository(_context);
                }
                return _movie;
            }
        }
        public IMusicRepository Music
        {
            get
            {
                if(_music == null)
                {
                    _music = new MusicRepository(_context);
                }
                return _music;
            }
        }
        public ISportRepository Sport
        {
            get
            {
                if(_sport == null)
                {
                    _sport = new SportRepository(_context);
                }
                return _sport;
            }
        }
        public RepositoryWrapper(ApplicationContext applicationContext)
        {
            _context = applicationContext;
        }
        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
