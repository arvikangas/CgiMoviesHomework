using System;
using System.Collections.Generic;
using System.Linq;
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



        }
    }
}
