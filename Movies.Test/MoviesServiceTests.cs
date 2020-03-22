using Microsoft.VisualStudio.TestTools.UnitTesting;
using Movies.Data.InMemory;
using Movies.Data.Interfaces;
using Movies.Data.Services;
using System.Linq;
using AutoMapper;
using Movies.Data.Mappings;

namespace Movies.Test
{
    [TestClass]
    public class MoviesServiceTests
    {
        static IMovieService _movieService;


        [ClassInitialize]
        public static void ClassInitialize(TestContext context)
        {
            var mapperConfig = new MapperConfiguration(cfg => cfg.AddProfile<MovieProfile>());
            var mapper = mapperConfig.CreateMapper();
            _movieService = new MovieService(new MovieRepositoryInMemory(), mapper);
        }

        [TestMethod]
        public void GetAllReturnsNotEmptyList()
        {
            var movies = _movieService.GetAll();
            Assert.IsNotNull(movies);
            Assert.IsTrue(movies.Any());
        }

        [TestMethod]
        public void GetByIdReturnsMovie()
        {
            var movie = _movieService.Get(1);
            Assert.IsNotNull(movie);
        }
    }
}
