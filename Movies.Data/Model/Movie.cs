using System;

namespace Movies.Data
{
    public class Movie : Entity
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int Year { get; set; }
        public string Description { get; set; }
        public int Rating { get; set; }
        public int CategoryId { get; set; }

        public Category Category { get; set; }
    }
}
