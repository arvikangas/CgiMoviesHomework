using Movies.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Movies.Data.Services
{
    public class MovieService : IMovieService
    {
        IMovieRepository _movieRepository;
        public MovieService(IMovieRepository movieRepository)
        {
            _movieRepository = movieRepository;
        }

        public Movie Get(int id)
        {
            return _movieRepository.GetAll().FirstOrDefault(m => m.Id == id);
        }

        public IList<Movie> GetAll()
        {
            return _movieRepository.GetAll().ToList();
        }
    }
}
