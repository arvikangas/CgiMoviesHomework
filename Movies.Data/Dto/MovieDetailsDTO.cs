using System;
using System.Collections.Generic;
using System.Text;

namespace Movies.Data.Dto
{
    public class MovieDetailsDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int Year { get; set; }
        public string Description { get; set; }
        public int Rating { get; set; }
        public string Category { get; set; }
    }
}
