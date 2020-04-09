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
    public class FandomsController : ControllerBase
    {
        private IRepositoryWrapper _repo;

        public FandomsController(IRepositoryWrapper repo)
        {
            _repo = repo;
        }

        // GET: api/Fandoms
        [HttpGet]
        public IActionResult Get()
        {
            var fandoms = _repo.Fandom.FindAll().Select(a => a);
            return Ok(fandoms);
        }

        // GET: api/Fandoms/5
        [HttpGet("{id:int}")]
        public IActionResult Get(int id)
        {
            var fandom = _repo.Fandom.FindByCondition(a => a.FandomId == id).SingleOrDefault(); ;

            if (fandom == null)
            {
                return NotFound();
            }

            return Ok(fandom);
        }

        [HttpGet("{input}")]
        public IActionResult Get(string input)
        {
            var fandom = _repo.Fandom.FindByCondition(a => a.Name.Contains(input));
            if(fandom == null)
            {
                return NotFound();
            }
            return Ok(fandom);
        }

        // PUT: api/Fandoms/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public IActionResult Put(int id, Fandom fandom)
        {
            if (id != fandom.FandomId)
            {
                return BadRequest();
            }

            try
            {
                var foundFandom = _repo.Fandom.FindByCondition(a => a.FandomId == id).SingleOrDefault();
                foundFandom.Name = fandom.Name;
                _repo.Fandom.Update(foundFandom);
                _repo.Save();
                return Ok(foundFandom);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FandomExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
        }

        // POST: api/Fandoms
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public IActionResult Post([FromBody] Fandom fandom)
        {
            _repo.Fandom.Create(fandom);
            _repo.Save();

            return Ok(fandom);
        }

        // DELETE: api/Fandom/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var fandom = _repo.Fandom.FindByCondition(a => a.FandomId == id).SingleOrDefault();
            if (fandom == null)
            {
                return NotFound();
            }

            _repo.Fandom.Delete(fandom);
            _repo.Save();

            return Ok(fandom);
        }

        private bool FandomExists(int id)
        {
            var fandom = _repo.Fandom.FindByCondition(a => a.FandomId == id).SingleOrDefault();
            if(fandom != null)
            {
                return true;
            }
            return false;
        }
    }
}