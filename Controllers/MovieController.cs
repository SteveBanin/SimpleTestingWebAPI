using Microsoft.AspNetCore.Mvc;
using TestingWebAPI.Models;
using TestingWebAPI.Service;


namespace TestingWebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MovieController : ControllerBase
    {
        MovieService _movieService;

        public MovieController(MovieService service) 
        {
            _movieService = service;
        }


        [HttpGet]
        public IEnumerable<Movie> GetAll()
        {
            return _movieService.GetAll();
        }


        [HttpGet("{id}")]
        public ActionResult<Movie> GetById(int id)
        {
            var movie = _movieService.GetById(id);

            if (movie is not null)
            {
                return movie;
            }
            else
            {
                return NotFound();
            }
        }


        [HttpPost]
        public IActionResult Create(Movie newMovie)
        {
            var movie = _movieService.Create(newMovie);
            return CreatedAtAction(nameof(GetById), new { id = movie!.Id }, movie);
        }


        [HttpPut("{id}/addingmovies")]
        public IActionResult AddingMovies(int id, int producerId)
        {
            var movieToUpdate = _movieService.GetById(id);

            if (movieToUpdate is not null)
            {
                _movieService.AddingMovies(id, producerId);
                return NoContent();
            }
            else
            {
                return NotFound();
            }
        }


        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var movie = _movieService.GetById(id);

            if (movie is not null)
            {
                _movieService.DeleteById(id);
                return Ok();
            }
            else
            {
                return NotFound();
            }
        }
    }
}
