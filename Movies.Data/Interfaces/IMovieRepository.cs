using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Movies.Data.Interfaces
{
    public interface IMovieRepository : IRepository<Movie>
    {
        public List<Movie> GetAllMovies();

        public Movie GetMovie(int id);
    }
}
