using System;
using System.Collections.Generic;
using System.Text;

namespace Movies.Data.Interfaces
{
    public interface IMovieService
    {
        IList<Movie> GetAll();
        Movie Get(int id);
    }
}
