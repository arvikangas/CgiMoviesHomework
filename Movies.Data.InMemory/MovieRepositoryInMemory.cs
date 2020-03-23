using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Movies.Data.Interfaces;

namespace Movies.Data.InMemory
{
    public class MovieRepositoryInMemory : IMovieRepository
    {
        public Movie Create(Movie entity)
        {
            var max = InMemoryDb.Movies.Any() ? InMemoryDb.Movies.Max(x => x.Id) : 0;
            entity.Id = max + 1;
            entity.CategoryId = entity.Category.Id;
            InMemoryDb.Movies.Add(entity);
            return entity;
        }

        public Movie Get(int id)
        {
            return InMemoryDb.Movies.FirstOrDefault(x => x.Id == id);
        }

        public IQueryable<Movie> GetAll()
        {
            return InMemoryDb.Movies.AsQueryable();
        }

        public List<Movie> GetAllMovies()
        {
            return GetAll().ToList();
        }

        public Movie GetMovie(int id)
        {
            return GetAll().FirstOrDefault(m => m.Id == id);
        }

        public Movie Remove(int id)
        {
            var movie = Get(id);
            if(movie != null)
            {
                InMemoryDb.Movies.Remove(movie);
            }
            return movie;
        }

        public Movie Update(Movie entity)
        {
            var movie = Get(entity.Id);

            movie.Rating = entity.Rating;
            movie.Title = entity.Title;
            movie.Year = entity.Year;
            movie.Category = entity.Category;
            movie.CategoryId = entity.CategoryId;
            movie.Description = entity.Description;

            movie.CategoryId = entity.Category.Id;

            return movie;
        }
    }
}
