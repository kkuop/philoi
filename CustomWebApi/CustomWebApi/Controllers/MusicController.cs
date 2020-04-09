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
    public class MusicController : ControllerBase
    {
        private IRepositoryWrapper _repo;

        public MusicController(IRepositoryWrapper repo)
        {
            _repo = repo;
        }

        // GET: api/Music
        [HttpGet]
        public IActionResult Get()
        {
            var music = _repo.Music.FindAll().Select(a => a);
            return Ok(music);
        }

        // GET: api/Music/5
        [HttpGet("{id:int}")]
        public IActionResult Get(int id)
        {
            var music = _repo.Music.FindByCondition(a => a.MusicId == id).SingleOrDefault();

            if (music == null)
            {
                return NotFound();
            }

            return Ok(music);
        }

        [HttpGet("{input}")]
        public IActionResult Get(string input)
        {
            var music = _repo.Music.FindByCondition(a => a.Name.Contains(input));
            if(music == null)
            {
                return NotFound();
            }
            return Ok(music);
        }

        // PUT: api/Music/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public IActionResult Put(int id, Music music)
        {
            if (id != music.MusicId)
            {
                return BadRequest();
            }

            try
            {
                var foundMusic = _repo.Music.FindByCondition(a => a.MusicId == id).SingleOrDefault();
                foundMusic.Name = music.Name;
                _repo.Music.Update(foundMusic);
                _repo.Save();
                return Ok(foundMusic);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MusicExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
        }

        // POST: api/Music
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public IActionResult Post([FromBody] Music music)
        {
            _repo.Music.Create(music);
            _repo.Save();

            return Ok(music);
        }

        // DELETE: api/Music/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var music = _repo.Music.FindByCondition(a => a.MusicId == id).SingleOrDefault();
            if (music == null)
            {
                return NotFound();
            }

            _repo.Music.Delete(music);
            _repo.Save();

            return Ok(music);
        }

        private bool MusicExists(int id)
        {
            var music = _repo.Music.FindByCondition(e => e.MusicId == id).SingleOrDefault();
            if (music != null)
            {
                return true;
            }
            return false;
        }
    }
}