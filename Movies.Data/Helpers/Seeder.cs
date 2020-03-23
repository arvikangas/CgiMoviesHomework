using Movies.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Movies.Data.Helpers
{
    public static class Seeder
    {
        public static void Seed(IMovieRepository movieRepository, ICategoryRepository categoryRepository)
        {
            var comedyCategory = categoryRepository.Create(new Category { Name = "Comedy" });
            var actionCategory = categoryRepository.Create(new Category { Name = "Action" });
            var dramaCategory = categoryRepository.Create(new Category { Name = "Drama" });

            movieRepository.Create(
    new Movie
    {
        Category = comedyCategory,
        Title = "Groundhog Day",
        Description =
    @"
Lorem ipsum dolor sit amet, consectetur adipiscing elit.
Aliquam sed posuere lacus, bibendum egestas tortor.
Donec at nisi sodales, interdum neque eget, porta enim. Lorem ipsum dolor sit amet, consectetur adipiscing elit.
Phasellus faucibus purus eros, vestibulum hendrerit libero faucibus quis.
Donec arcu velit, consequat ut vulputate at, pulvinar eget sapien.
Vivamus vestibulum feugiat eros in luctus. Proin varius, metus eu tempor consequat, massa lectus porta velit, id bibendum orci ipsum in sem. 
Duis tortor enim, pharetra et ligula id, viverra malesuada nisl. Pellentesque ultricies tellus eu leo elementum, vel commodo est pretium.
",
        Year = 1993,
        Rating = 93
    });
            movieRepository.Create(
                new Movie
                {
                    Category = comedyCategory,
                    Title = "Home Alone",
                    Description =
                @"
Lorem ipsum dolor sit amet, consectetur adipiscing elit.
Aliquam sed posuere lacus, bibendum egestas tortor.
Donec at nisi sodales, interdum neque eget, porta enim. Lorem ipsum dolor sit amet, consectetur adipiscing elit.
Phasellus faucibus purus eros, vestibulum hendrerit libero faucibus quis.
            ",
                    Year = 1990,
                    Rating = 67
                });
            movieRepository.Create(
                new Movie
                {
                    Category = actionCategory,
                    Title = "Die Hard",
                    Description =
                @"
Lorem ipsum dolor sit amet, consectetur adipiscing elit.
Aliquam sed posuere lacus, bibendum egestas tortor.
Donec at nisi sodales, interdum neque eget, porta enim. Lorem ipsum dolor sit amet, consectetur adipiscing elit.
Phasellus faucibus purus eros, vestibulum hendrerit libero faucibus quis.
            ",
                    Year = 1988,
                    Rating = 76
                });
            movieRepository.Create(
                new Movie
                {
                    Category = actionCategory,
                    Title = "Terminator",
                    Description =
                @"
            Lorem ipsum dolor sit amet, consectetur adipiscing elit.
            Aliquam sed posuere lacus, bibendum egestas tortor.
                        ",
                    Year = 1988,
                    Rating = 76
                });
            movieRepository.Create(
                new Movie
                {
                    Category = dramaCategory,
                    Title = "Random drama movie",
                    Description =
                @"
                        Lorem ipsum dolor sit amet, consectetur adipiscing elit.
                        Aliquam sed posuere lacus, bibendum egestas tortor.
                                    ",
                    Year = 1988,
                    Rating = 76
                });
        }
    }
}
