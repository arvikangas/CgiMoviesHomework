using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Movies.Data.Dto;
using Movies.Data.Interfaces;

namespace Movies.UI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        IMovieService _movieService;

        public MovieController(IMovieService movieService)
        {
            _movieService = movieService;
        }

        [HttpGet("movies")]
        public ActionResult<List<MovieDTO>> Movies()
        {
            var movies = _movieService.GetAll();
            return movies.ToList();
        }

        [HttpGet("movie")]
        public ActionResult<MovieDetailsDTO> Movie(int id)
        {
            var movie = _movieService.Get(id);
            return movie;
        }
    }
}