using AutoMapper;
using ITPLibrary.Api.Core.Dtos;
using ITPLibrary.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITPLibrary.Api.Core.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Book, BookDto>().ReverseMap();
        }
    }
}
