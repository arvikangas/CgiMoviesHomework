using System;
using System.Collections.Generic;
using System.Text;

namespace Movies.Data.Dto
{
    public class MovieDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int Year { get; set; }
        public string Category { get; set; }
        public int Rating { get; set; }
    }
}
