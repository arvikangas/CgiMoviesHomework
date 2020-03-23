using Microsoft.VisualStudio.TestTools.UnitTesting;
using Movies.Data.InMemory;
using Movies.Data.Interfaces;
using Movies.Data.Services;
using System.Linq;
using AutoMapper;
using Movies.Data.Mappings;
using Movies.Data;

namespace Movies.Test
{
    [TestClass]
    public class MoviesServiceTests
    {
        static IMovieService _movieService;
        static IMovieRepository _movieRepository;
        static ICategoryRepository _categoryRepository;

        [ClassInitialize]
        public static void ClassInitialize(TestContext context)
        {
            
            var mapperConfig = new MapperConfiguration(cfg => cfg.AddProfile<MovieProfile>());
            var mapper = mapperConfig.CreateMapper();

            _movieRepository = new MovieRepositoryInMemory();
            _categoryRepository = new CategoryRepositoryInMemory();

            _movieService = new MovieService(_movieRepository, mapper);
        }

        [TestMethod]
        public void GetAllReturnsNotEmptyList()
        {
            var cat = _categoryRepository.Create(new Category { Name = "xxx" });
            _movieRepository.Create(new Movie { Category = cat, Title = "asd", Rating = 1, Year = 1, Description = "asd" });

            var movies = _movieService.GetAll();
            Assert.IsNotNull(movies);
            Assert.IsTrue(movies.Any());
        }

        [TestMethod]
        public void GetByIdReturnsMovie()
        {
            var cat = _categoryRepository.Create(new Category { Name = "xxx" });
            var movie = _movieRepository.Create(new Movie { Category = cat, Title = "asd", Rating = 1, Year = 1, Description = "asd" });
            var entity = _movieService.Get(movie.Id);
            Assert.IsNotNull(entity);
            Assert.IsTrue(movie.Id == entity.Id);
        }
    }
}
