using Movies.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Movies.Data.SqLite
{
    public class MovieRepositorySqLite : IMovieRepository
    {
        SqLiteDbContext _db;

        public MovieRepositorySqLite(SqLiteDbContext db)
        {
            _db = db;
        }

        public Movie Create(Movie entity)
        {
             _db.Movies.Add(entity);
            _db.SaveChanges();
            return entity;
        }

        public Movie Get(int id)
        {
            return _db.Movies.FirstOrDefault(c => c.Id == id);
        }

        public IQueryable<Movie> GetAll()
        {
            return _db.Movies.AsQueryable();
        }

        public List<Movie> GetAllMovies()
        {
            return GetAll().ToList();
        }

        public Movie GetMovie(int id)
        {
            return Get(id);
        }

        public Movie Remove(int id)
        {
            var m = Get(id);
            _db.Movies.Remove(m);
            _db.SaveChanges();
            return m;
        }

        public Movie Update(Movie entity)
        {
            _db.Movies.Update(entity);
            _db.SaveChanges();
            return entity;
        }
    }
}
