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
    public abstract class MoviesServiceTestsBase
    {
        public abstract IMovieService MovieService { get; }
        public abstract IMovieRepository MovieRepository { get; }
        public abstract ICategoryRepository CategoryRepository { get; }

        [TestMethod]
        public void GetAllReturnsNotEmptyList()
        {
            var cat = CategoryRepository.Create(new Category { Name = "xxx" });
            MovieRepository.Create(new Movie { Category = cat, Title = "asd", Rating = 1, Year = 1, Description = "asd" });

            var movies = MovieService.GetAll();
            Assert.IsNotNull(movies);
            Assert.IsTrue(movies.Any());
        }

        [TestMethod]
        public void GetByIdReturnsMovie()
        {
            var cat = CategoryRepository.Create(new Category { Name = "xxx" });
            var movie = MovieRepository.Create(new Movie { Category = cat, Title = "asd", Rating = 1, Year = 1, Description = "asd" });
            var entity = MovieService.Get(movie.Id);
            Assert.IsNotNull(entity);
            Assert.IsTrue(movie.Id == entity.Id);
        }
    }
}
