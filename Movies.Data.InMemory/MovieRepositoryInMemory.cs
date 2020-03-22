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
        public IQueryable<Movie> GetAll()
        {
            return InMemoryDb.Movies.AsQueryable();
        }
    }
}
