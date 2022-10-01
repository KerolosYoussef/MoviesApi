using AutoMapper;
using MovieRate.API.Dtos;
using MovieRate.Core.Models;

namespace MovieRate.API.Helpers;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<GenreDto, Genre>().ReverseMap();
    }
}