using AutoMapper;
using ITPLibrary.Api.Core.Dtos;
using ITPLibrary.Api.Models;

namespace ITPLibrary.Api.Core.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Book, BookDto>().ReverseMap();
            CreateMap<Book, AddBookDto>().ReverseMap();
        }
    }
}
