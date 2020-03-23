using Microsoft.VisualStudio.TestTools.UnitTesting;
using Movies.Data.InMemory;
using Movies.Data.SqLite;
using Movies.Data.Interfaces;
using Movies.Data.Services;
using System.Linq;
using AutoMapper;
using Movies.Data.Mappings;
using Movies.Data;

namespace Movies.Test
{
    [TestClass]
    public class MoviesServiceTestsSqLite : MoviesServiceTestsBase
    {
        static SqLiteDbContext _db;

        static IMovieService _movieService;
        public override IMovieService MovieService => _movieService;

        static IMovieRepository _movieRepository;
        public override IMovieRepository MovieRepository => _movieRepository;

        static ICategoryRepository _categoryRepository;
        public override ICategoryRepository CategoryRepository => _categoryRepository;

        [ClassInitialize]
        public static void ClassInitialize(TestContext context)
        {
            
            var mapperConfig = new MapperConfiguration(cfg => cfg.AddProfile<MovieProfile>());
            var mapper = mapperConfig.CreateMapper();

            _db = new SqLiteDbContext();

            _movieRepository = new MovieRepositorySqLite(_db);
            _categoryRepository = new CategoryRepositorySqLite(_db);
            _movieService = new MovieService(_movieRepository, mapper);
        }

        [ClassCleanup]
        public static void ClassCleanup()
        {
            _db.Dispose();
        }
    }
}
