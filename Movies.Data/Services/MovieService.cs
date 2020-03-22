using AutoMapper;
using Movies.Data.Dto;
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
        IMapper _mapper;

        public MovieService(IMovieRepository movieRepository, IMapper mapper)
        {
            _movieRepository = movieRepository;
            _mapper = mapper;
        }

        public MovieDetailsDTO Get(int id)
        {
            var movie = _movieRepository.GetAll().FirstOrDefault(m => m.Id == id);
            var result = _mapper.Map<MovieDetailsDTO>(movie);
            return result;
        }

        public IList<MovieDTO> GetAll()
        {
            var movies = _movieRepository.GetAll();
            var result = _mapper.Map<List<MovieDTO>>(movies);
            return result;
        }
    }
}
