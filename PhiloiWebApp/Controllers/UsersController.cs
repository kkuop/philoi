﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PhiloiWebApp.Contracts;
using PhiloiWebApp.Data;
using PhiloiWebApp.Models;

namespace PhiloiWebApp.Controllers
{
    [Authorize(Roles = "User")]
    public class UsersController : Controller
    {
        private readonly IRepositoryWrapper _repo;

        public UsersController(IRepositoryWrapper repo)
        {
            _repo = repo;
        }

        // GET: Users
        public IActionResult Index(User user)
        {
            var interests = _repo.Interest.FindAll();
            
            var interestToSendToView = interests.Include(s => s.Category);

            return View(interestToSendToView);

        }

        // GET: Users/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = _repo.User.FindByCondition(m => m.UserId == id).SingleOrDefault();
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        // GET: Users/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Users/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("UserId,FirstName,LastName,Email,ZipCode,Longitude,Latitude")] User user)

        {
            if (ModelState.IsValid)
            {
                _repo.User.Create(user);
                _repo.Save();
                return RedirectToAction(nameof(Index));
            }
            return View(user);
        }

        // GET: Users/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = _repo.User.FindByCondition(u => u.UserId == id).SingleOrDefault();
            if (user == null)
            {
                return NotFound();
            }
            return View(user);
        }

        // POST: Users/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("UserId,FirstName,LastName,Email,ZipCode,Longitude,Latitude")] User user)
        {
            if (id != user.UserId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _repo.User.Update(user);
                    _repo.Save();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserExists(user.UserId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(user);
        }

        // GET: Users/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = _repo.User.FindByCondition(m => m.UserId == id);
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        // POST: Users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var user = _repo.User.FindByCondition(u => u.UserId == id).SingleOrDefault();
            _repo.User.Delete(user);
            _repo.Save();
            return RedirectToAction(nameof(Index));
        }

        private bool UserExists(int id)
        {
            var foundUser = _repo.User.FindByCondition(e => e.UserId == id);
            if(foundUser != null)
            {
                return true;
            }
            return false;
        }
    }
}
