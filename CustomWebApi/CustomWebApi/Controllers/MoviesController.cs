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
    public class MoviesController : ControllerBase
    {
        private IRepositoryWrapper _repo;

        public MoviesController(IRepositoryWrapper repo)
        {
            _repo = repo;
        }

        // GET: api/Movies
        [HttpGet]
        public IActionResult Get()
        {
            var movies = _repo.Movie.FindAll().Select(a => a);
            return Ok(movies);
        }

        // GET: api/Movies/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var movie = _repo.Movie.FindByCondition(a => a.MovieId == id).SingleOrDefault();

            if (movie == null)
            {
                return NotFound();
            }

            return Ok(movie);
        }

        // PUT: api/Movies/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public IActionResult Put(int id, Movie movie)
        {
            if (id != movie.MovieId)
            {
                return BadRequest();
            }

            try
            {
                var foundMovie = _repo.Movie.FindByCondition(a => a.MovieId == id).SingleOrDefault();
                foundMovie.Name = movie.Name;
                _repo.Movie.Update(foundMovie);
                _repo.Save();
                return Ok(foundMovie);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MovieExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
        }

        // POST: api/Movies
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public IActionResult Post([FromBody] Movie movie)
        {
            _repo.Movie.Create(movie);
            _repo.Save();

            return Ok(movie);
        }

        // DELETE: api/Movies/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var movie = _repo.Movie.FindByCondition(a => a.MovieId == id).SingleOrDefault();
            if (movie == null)
            {
                return NotFound();
            }

            _repo.Movie.Delete(movie);
            _repo.Save();

            return Ok(movie);
        }

        private bool MovieExists(int id)
        {
            var movie = _repo.Movie.FindByCondition(e => e.MovieId == id).SingleOrDefault();
            if (movie != null)
            {
                return true;
            }
            return false;
        }
    }
}