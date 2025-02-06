using AutoMapper;
using BookLibraryAPI.Entities;
using BookLibraryAPI.Models;

namespace BookLibraryAPI.Profiles
{
    public class AuthorProfile : Profile
    {
        public AuthorProfile()
        {
            CreateMap<Entities.Author,Models.AuthorDto>();
            CreateMap<Entities.Author, Models.BookOfAuthorDto>();
        }
    }
}
