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
    public class SportsController : ControllerBase
    {
        private IRepositoryWrapper _repo;

        public SportsController(IRepositoryWrapper repo)
        {
            _repo = repo;
        }

        // GET: api/Sports
        [HttpGet]
        public IActionResult Get()
        {
            var sports = _repo.Sport.FindAll().Select(a => a);
            return Ok(sports);
        }

        // GET: api/Sports/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var sport = _repo.Sport.FindByCondition(a => a.SportId == id).SingleOrDefault();

            if (sport == null)
            {
                return NotFound();
            }

            return Ok(sport);
        }

        // PUT: api/Sports/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id:int}")]
        public IActionResult Put(int id,[FromBody] Sport sport)
        {
            if (id != sport.SportId)
            {
                return BadRequest();
            }

            try
            {
                var foundSport = _repo.Sport.FindByCondition(a => a.SportId == id).SingleOrDefault();
                foundSport.Name = sport.Name;
                _repo.Sport.Update(foundSport);
                _repo.Save();
                return Ok(foundSport);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SportExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
        }

        // POST: api/Sports
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public IActionResult Post([FromBody] Sport sport)
        {
            _repo.Sport.Create(sport);
            _repo.Save();

            return Ok(sport);
        }

        // DELETE: api/Sports/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var sport = _repo.Sport.FindByCondition(a => a.SportId == id).SingleOrDefault();
            if (sport == null)
            {
                return NotFound();
            }

            _repo.Sport.Delete(sport);
            _repo.Save();

            return Ok(sport);
        }

        private bool SportExists(int id)
        {
            var sport = _repo.Sport.FindByCondition(e => e.SportId == id).SingleOrDefault();
            if (sport != null)
            {
                return true;
            }
            return false;
        }
    }
}