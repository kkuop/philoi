using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PhiloiWebApp.Contracts;
using PhiloiWebApp.Data;
using PhiloiWebApp.JSON_Classes;
using PhiloiWebApp.Models;
using PhiloiWebApp.Service_Classes;

namespace PhiloiWebApp.Controllers
{
    [Authorize(Roles = "User")]
    public class UsersController : Controller
    {
        private readonly IRepositoryWrapper _repo;
        private readonly IInterestService _interest;

        public UsersController(IRepositoryWrapper repo, IInterestService interest)
        {
            _repo = repo;
            _interest = interest;
        }

        public async Task<IActionResult> Index(User user)
        {
            ViewBag.Activities = await _interest.GetActivities();

            var interests = _repo.UserInterest.FindByCondition(s => s.UserId == user.UserId);

            var interestToSendToView =  interests.Include(s => s.Interest).ThenInclude(s => s.Category);

            user.Interests = interestToSendToView.ToList();

            return View(user);
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
        public IActionResult Edit(int id, [Bind("UserId,FirstName,LastName,Email,ZipCode")] User user)
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
        // GET: Users/EditInterests/5
        public IActionResult EditInterests(int? id)
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
        // POST: Users/EditInterests/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditInterests(int id, [Bind("Interests")] User user)
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

        [HttpPost]
        public JsonResult GetInterests(string prefix)
        {
            var interests = _interest.GetActivities();
            return Json(interests);
        }

        [HttpPost]
        public async Task<JsonResult> GetInterestsAsync(string prefix)
        {
            var interests = await _interest.GetActivities();
            return Json(interests);
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
