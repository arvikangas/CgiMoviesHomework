using AutoMapper;
using Movies.Data.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Movies.Data.Mappings
{
    public class MovieProfile : Profile
    {
        public MovieProfile()
        {
            CreateMap<Movie, MovieDTO>()
                .ForMember(dest => dest.Category, opt => opt.MapFrom(src => src.Category.Name));

            CreateMap<Movie, MovieDetailsDTO>()
                .ForMember(dest => dest.Category, opt => opt.MapFrom(src => src.Category.Name));
        }
    }
}
