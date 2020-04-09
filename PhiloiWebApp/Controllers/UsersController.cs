using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
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
        private readonly IEventService _events;

        public UsersController(IRepositoryWrapper repo, IInterestService interest, IEventService events)
        {
            _repo = repo;
            _interest = interest;
            _events = events;
        }

        public async Task<IActionResult> Index(User user)
        {

            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var foundUser = _repo.User.FindByCondition(a => a.IdentityUserId == userId).SingleOrDefault();
            if (foundUser == null)
            {
                return RedirectToAction(nameof(Create));
            }
            ViewBag.Activities = await _interest.GetActivities();

            var interests = _repo.UserInterest.FindByCondition(s => s.UserId == user.UserId);

            var events = await _events.GetEvents();

            //var interestToSendToView =  interests.Include(s => s.Interest).ThenInclude(s => s.Category);

            //user.Interests = interests.ToList();

            return View(foundUser);
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
        public IActionResult Create([Bind("UserId,FirstName,LastName,DateOfBirth,Occupation,Email,ZipCode,Longitude,Latitude")] User user)

        {
            if (ModelState.IsValid)
            {
                var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
                user.IdentityUserId = userId;
                _repo.User.Create(user);
                _repo.Save();
                return RedirectToAction(nameof(Index));
            }
            return View(user);
        }

        // GET: Users/Edit
        public IActionResult Edit()
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var user = _repo.User.FindByCondition(u => u.IdentityUserId == userId).SingleOrDefault();
            if (user == null)
            {
                return NotFound();
            }
            return View(user);
        }

        // POST: Users/Edit
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit([Bind("UserId,FirstName,LastName,DateOfBirth,Occupation,Email,ZipCode,Address,Longitude,Latitude,ImgUrl,IdentityUserId")] User user)
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var foundUser = _repo.User.FindByCondition(u => u.UserId == user.UserId).SingleOrDefault();
            if (userId != foundUser.IdentityUserId)
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
        // GET: Users/EditInterests
        public async Task<IActionResult> AddInterests()
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var foundUser = _repo.User.FindByCondition(a => a.IdentityUserId == userId).SingleOrDefault();
            ViewBag.UserInterests = _repo.UserInterest.FindAll().Where(a => a.UserId == foundUser.UserId);
            if (foundUser == null)
            {
                return NotFound();
            }
            
            ViewBag.Activities = await _interest.GetActivities();
            return View();
        }
        // POST: Users/EditInterests/String
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddInterests(UserInterest userInterest)
        {
            //UserInterest userInterest = new UserInterest();
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var foundUser = _repo.User.FindByCondition(a => a.IdentityUserId == userId).SingleOrDefault();
            var activities = await _interest.GetActivities();
            for (int i = 0; i < activities.Length; i++)
            {
                if(activities[i].name == userInterest.Name)
                {
                    if (ModelState.IsValid)
                    {
                        try
                        {
                            userInterest.UserId = foundUser.UserId;

                            //userInterest.Name = searchBox;
                            _repo.UserInterest.Create(userInterest);
                            _repo.Save();
                        }
                        catch (DbUpdateConcurrencyException)
                        {
                            if (!UserExists(foundUser.UserId))
                            {
                                return NotFound();
                            }
                            else
                            {
                                throw;
                            }
                        }
                        return RedirectToAction(nameof(AddInterests));
                    }
                }
            }
            return RedirectToAction(nameof(AddInterests));
        }

        // GET: UserInterest/ViewInterests
        [HttpGet]
        public IActionResult ViewInterests()
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var foundUser = _repo.User.FindByCondition(a => a.IdentityUserId == userId).SingleOrDefault();
            var userInterests = _repo.UserInterest.FindAll().Where(a => a.UserId == foundUser.UserId);
            if (foundUser == null)
            {
                return NotFound();
            }
            return View(userInterests);
        }

        // GET: Users/EditInterest/5
        [HttpGet]
        public IActionResult EditInterest(int id)
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var foundUser = _repo.User.FindByCondition(a => a.IdentityUserId == userId).SingleOrDefault();
            var foundUserInterest = _repo.UserInterest.FindByCondition(a => a.UserInterestId == id).SingleOrDefault();
            if (foundUserInterest == null)
            {
                return NotFound();
            }
            return View(foundUserInterest);
        }

        // POST: Users/EditInterest/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditInterest(int id, UserInterest userInterest)
        {
            var foundUserInterest = _repo.UserInterest.FindByCondition(a => a.UserInterestId == id).SingleOrDefault();
            foundUserInterest.Weight = userInterest.Weight;
            _repo.UserInterest.Update(foundUserInterest);
            _repo.Save();
            return RedirectToAction(nameof(ViewInterests));
        }

        // GET: Users/RemoveInterest/5
        [HttpGet]
        public IActionResult RemoveInterest(int id)
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var foundUser = _repo.User.FindByCondition(a => a.IdentityUserId == userId).SingleOrDefault();
            var foundUserInterest = _repo.UserInterest.FindByCondition(a => a.UserInterestId == id).SingleOrDefault();
            if (foundUserInterest == null)
            {
                return NotFound();
            }
            return View(foundUserInterest);
        }

        // POST: UserInterest/RemoveInterest/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult RemoveInterest(int id, UserInterest userInterest)
        {
            var foundUserInterest = _repo.UserInterest.FindByCondition(a => a.UserInterestId == id).SingleOrDefault();
            _repo.UserInterest.Delete(foundUserInterest);
            _repo.Save();
            return RedirectToAction(nameof(ViewInterests));
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

        public IActionResult Search(string searchString)
        {
            /*var users = _repo.User.FindByCondition(u => u.ListOfInterests.Contains(searchString));
            if (!String.IsNullOrEmpty(searchString))
            {
            users = users.Where(s => s.ListOfInterests.Contains(searchString));
            }
            return View(await users.ToListAsync());*/
            return View();
        }
    }
}
