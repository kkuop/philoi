﻿using PhiloiWebApp.Contracts;
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
        private IInterestRepository _interest;
        private ICategoryRepository _category;
        private IUserInterestRepository _userInterest;
        private IUserMessageRepository _userMessage;
        public IUserMessageRepository UserMessage
        {
            get
            {
                if(_userMessage == null)
                {
                    _userMessage = new UserMessageRepository(_context);
                }
                return _userMessage;
            }
        }
        public IUserInterestRepository UserInterest
        {
            get
            {
                if(_userInterest == null)
                {
                    _userInterest = new UserInterestRepository(_context);
                }
                return _userInterest;
            }
        }
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
        public IInterestRepository Interest
        {
            get
            {
                if(_interest == null)
                {
                    _interest = new InterestRepository(_context);
                }
                return _interest;
            }
        }
        public ICategoryRepository Category
        {
            get
            {
                if(_category == null)
                {
                    _category = new CategoryRepository(_context);
                }
                return _category;
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
