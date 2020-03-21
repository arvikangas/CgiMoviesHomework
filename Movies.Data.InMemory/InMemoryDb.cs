using System;
using System.Collections.Generic;
using System.Text;

namespace Movies.Data.InMemory
{
    public static class InMemoryDb
    {
        public static List<Movie> Movies { get; set; } = new List<Movie>();
        public static List<Category> Categories { get; set; } = new List<Category>();

        static InMemoryDb()
        {
            Init();
        }

        public static void Init()
        {
            Categories.Add(new Category { Id = 1, Name = "Comedy" });
            Categories.Add(new Category { Id = 2, Name = "Action" });
            Categories.Add(new Category { Id = 3, Name = "Drama" });

            Movies.Add(
                new Movie
                {
                    Id = 1,
                    CategoryId = 1,
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
            Movies.Add(
                new Movie
                {
                    Id = 2,
                    CategoryId = 1,
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
        }
    }
}
