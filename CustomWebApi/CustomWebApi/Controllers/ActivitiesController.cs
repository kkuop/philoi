using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CustomWebApi.Data;
using CustomWebApi.Models;
using CustomWebApi.Contracts;

namespace CustomWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActivitiesController : ControllerBase
    {
        private IRepositoryWrapper _repo;

        public ActivitiesController(IRepositoryWrapper repo)
        {
            _repo = repo;
        }

        // GET: api/Activities
        [HttpGet]
        public IActionResult Get()
        {
            var activities = _repo.Activity.FindAll().Select(a => a);
            return Ok(activities);
        }

        // GET: api/Activities/5
        [HttpGet("{id:int}")]
        public IActionResult Get(int id)
        {
            var activity = _repo.Activity.FindByCondition(a => a.ActivityId == id).SingleOrDefault();

            if (activity == null)
            {
                return NotFound();
            }

            return Ok(activity);
        }

        [HttpGet("{input}")]
        public IActionResult Get(string input)
        {
            var activity = _repo.Activity.FindByCondition(a => a.Name.Contains(input));
            if (activity == null)
            {
                return NotFound();
            }

            return Ok(activity);
        }

        // PUT: api/Activities/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public IActionResult Put(int id, Activity activity)
        {
            if (id != activity.ActivityId)
            {
                return BadRequest();
            }

            try
            {
                var foundActivity = _repo.Activity.FindByCondition(a => a.ActivityId == id).SingleOrDefault();
                foundActivity.Name = activity.Name;
                _repo.Activity.Update(foundActivity);
                _repo.Save();
                return Ok(foundActivity);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ActivityExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
        }

        // POST: api/Activities
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public IActionResult Post([FromBody] Activity activity)
        {
            _repo.Activity.Create(activity);
            _repo.Save();

            return Ok(activity);
        }

        // DELETE: api/Activities/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var activity = _repo.Activity.FindByCondition(a => a.ActivityId == id).SingleOrDefault() ;
            if (activity == null)
            {
                return NotFound();
            }

            _repo.Activity.Delete(activity);
            _repo.Save();

            return Ok(activity);
        }

        private bool ActivityExists(int id)
        {
            var activity =  _repo.Activity.FindByCondition(e => e.ActivityId == id).SingleOrDefault();
            if(activity != null)
            {
                return true;
            }
            return false;
        }
    }
}