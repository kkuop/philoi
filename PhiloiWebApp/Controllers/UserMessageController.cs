using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PhiloiWebApp.Contracts;
using PhiloiWebApp.Models;

namespace PhiloiWebApp.Controllers
{
    public class UserMessageController : Controller
    {
        private readonly IRepositoryWrapper _repo;
        public UserMessageController(IRepositoryWrapper repo)
        {
            _repo = repo;
        }
        // GET: UserMessage
        public ActionResult GetMessages()
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var foundUser = _repo.User.FindByCondition(a => a.IdentityUserId == userId).SingleOrDefault();
            var userMessages = _repo.UserMessage.FindByCondition(a => a.RecipientUserId == foundUser.UserId).Select(a=>a);
            ViewBag.UserList = _repo.User.FindAll().Join(_repo.UserMessage.FindAll(), a => a.UserId, b=>b.UserId, (a, b) => new { User = a, UserMessage = b }).Where(a => a.UserMessage.RecipientUserId == foundUser.UserId).Select(a => a.User).Distinct().ToList();
            return View(userMessages);
        }

        // GET: SendMessage
        public IActionResult SendMessage(int? id)
        {
            var loggedInUserId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            ViewBag.Sender = _repo.User.FindByCondition(a => a.IdentityUserId == loggedInUserId).SingleOrDefault();
            ViewBag.Recipient = _repo.User.FindByCondition(a => a.UserId == id).SingleOrDefault();
            return View();
        }

        // GET: UserMessage/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }


        // POST: UserMessage/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(UserMessage userMessage)
        {
            try
            {
                // TODO: Add insert logic here
                userMessage.DateTime = DateTime.UtcNow;
                _repo.UserMessage.Create(userMessage);
                _repo.Save();
                return RedirectToAction("Index","Users");
            }
            catch
            {
                return View();
            }
        }

        // GET: UserMessage/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: UserMessage/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: UserMessage/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: UserMessage/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}