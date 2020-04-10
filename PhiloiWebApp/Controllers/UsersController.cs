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

       
        private readonly LocationService _locationService;
        

        private readonly IInterestService _interest;

        public UsersController(IRepositoryWrapper repo, IInterestService interest, LocationService locationService)

        {
            _repo = repo;
            _interest = interest;
            _locationService = locationService;
        }

        public async Task<IActionResult> Index(User user)
        {
            
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var foundUser = _repo.User.FindByCondition(a => a.IdentityUserId == userId).SingleOrDefault();
            if(foundUser == null)
            {
                return RedirectToAction(nameof(Create));
            }
            ViewBag.Activities = await _interest.GetActivities();

            var interests = _repo.UserInterest.FindByCondition(s => s.UserId == user.UserId);

            //var interestToSendToView =  interests.Include(s => s.Interest).ThenInclude(s => s.Category);

            //user.Interests = interests.ToList();
            MatchingInterests(user);
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
        [HttpGet, ActionName("TBD")]
        //Algorythimn level 1
        public async Task<bool> userWithinRange(User user1, User user2)
        { double counter=0;
            int limit = 50;
            
            var range = await _locationService.GetDistance(user1, user2);
            foreach(var leg in range.routes[0].legs)
            {
                counter = counter + leg.distance.value;
            }
            if (counter < limit)
            {
                return true;
            }

            return false;
        }

        public void MatchingInterests(User user1)
        { int threshold1 = 0;
            int threshold2 = 5;
            int threshold3 = 10;
          var lvl1 = new List<User>();
            var lvl2 = new List<User>();
            var lvl3 = new List<User>();

            var userIntrests = _repo.UserInterest.FindByCondition(s => s.UserId == user1.UserId).ToList();
            int points;
            var userlist = _repo.User.FindByCondition(s => s.UserId != user1.UserId).ToList();
            foreach(var user in userlist) 
            {var notuserList= _repo.UserInterest.FindByCondition(s => s.UserId == user.UserId).ToList();
                var intersection = userIntrests.Intersect(notuserList);
                if (intersection.Count() > 0) 
                { foreach(var item in intersection) 
                    {
                         points = 0;
                        points = points + item.Weight + 1;
                        if (points>threshold1&&points<threshold2) { lvl1.Add(user); }
                         else if(points > threshold2 && points < threshold3) { lvl2.Add(user); }
                       else if(points > threshold3) { lvl3.Add(user); }

                    }
                               
              
                }
            }
            ViewBag.KindaFreinds = lvl1;
            ViewBag.GoodFreinds = lvl2;
            ViewBag.BestFreinds = lvl3;
            
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
