using Movies.Data.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Movies.Data.Interfaces
{
    public interface IMovieService
    {
        IList<MovieDTO> GetAll();
        MovieDetailsDTO Get(int id);
    }
}
