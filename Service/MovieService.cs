using Microsoft.EntityFrameworkCore;
using TestingWebAPI.Data;
using TestingWebAPI.Models;

namespace TestingWebAPI.Service
{
    public class MovieService
    {

        private readonly MovieContext _context;


        public MovieService(MovieContext context)
        {
            _context = context;
        }


        public IEnumerable<Movie> GetAll()
        {
            return _context.Movies
            .AsNoTracking()
            .ToList();
        }


        public Movie? GetById(int id)
        {
            return _context.Movies
            .Include(p => p.Producers)
            .AsNoTracking()
            .SingleOrDefault(p => p.Id == id);
        }


        public Movie? Create(Movie newMovie)
        {
            _context.Movies.Add(newMovie);
            _context.SaveChanges();

            return newMovie;
        }


        public void AddingMovies(int MovieId, int ProducerId)
        {
            var movieToUpdate = _context.Movies.Find(MovieId);
            var ProducerToAdd = _context.Producers.Find(ProducerId);

            if (movieToUpdate is null || ProducerToAdd is null)
            {
                throw new InvalidOperationException("Movies and the producers does not exist");
            }

            if (movieToUpdate.Producers is null)
            {
                movieToUpdate.Producers = new List<Producer>();
            }

            movieToUpdate.Producers.Add(ProducerToAdd);

            _context.SaveChanges();
        }


        public void DeleteById(int id)
        {
            var movieToDelete = _context.Movies.Find(id);
            if (movieToDelete is not null)
            {
                _context.Movies.Remove(movieToDelete);
                _context.SaveChanges();
            }
        }


    }
}
