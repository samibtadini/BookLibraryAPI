using AutoMapper;
using BookLibraryAPI.Entities;
using BookLibraryAPI.Models;
using Microsoft.EntityFrameworkCore.Design;
namespace BookLibraryAPI.Profiles
{
    public class BookProfile : Profile
    {
        public BookProfile()
        {
            CreateMap<Entities.Book, Models.BookOfAuthorDto>();
            CreateMap<Entities.Book, Models.BookWithoutAuthorDto>();
            CreateMap<Entities.Book, Models.BookDto>()
                .ForMember(dest => dest.Author, opts => opts.MapFrom(src => src.Author));
          
            CreateMap<Models.BookForCreationDto, Entities.Book>();
            CreateMap<Models.BookForUpdateDto, Entities.Book>();
            CreateMap<Entities.Book, Models.BookForUpdateDto>();
            
        }
    }
}
