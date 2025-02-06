using BookLibraryAPI.Entities;

namespace BookLibraryAPI.Services
{
    public interface IBookRepository
    { 
        Task<IEnumerable<Book>> GetBooksAsync();
        Task<Book> GetBookAsync(int id);
        Task<Book> DeleteBookAsync(int id);
        Task<int> CreateBookAysnc(int AuthorId, Book book);
        Task<int> UpdateBookAsync(Book book);
    }
}
