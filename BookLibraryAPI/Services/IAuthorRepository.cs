using BookLibraryAPI.Entities;

namespace BookLibraryAPI.Services
{
    public interface IAuthorRepository
    {
        Task<Author> GetAuthorAsync(int id);
    }
}
