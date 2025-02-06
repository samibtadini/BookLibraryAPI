using BookLibraryAPI.DbContexts;
using BookLibraryAPI.Entities;
using Microsoft.EntityFrameworkCore;

namespace BookLibraryAPI.Services
{
    public class BookRepository : IBookRepository
    {
        private readonly BookLibraryContext _context;
        public BookRepository(BookLibraryContext context)
        {
            _context = context;
        }

        public async Task<int> CreateBookAysnc(int AuthorId, Book book)
        {
            var author = await _context.Authors.Include(a => a.Books).FirstOrDefaultAsync(a => a.Id == AuthorId);
            if (author != null)
            {
                author.Books.Add(book);
                return await _context.SaveChangesAsync();
            }
            throw new Exception("Author not found");
        }

        public Task<Book> DeleteBookAsync(int id)
        {
            var book = _context.Books.FirstOrDefault(b => b.Id == id);
            if (book != null)
            {
                _context.Books.Remove(book);
                _context.SaveChanges();
                return Task.FromResult(book);
            }
            throw new Exception("Book not found");
        }

        public async Task<Book> GetBookAsync(int id)
        {
            return await _context.Books.Include(a => a.Author).FirstOrDefaultAsync(b => b.Id == id);
        }

        public async Task<IEnumerable<Book>> GetBooksAsync()
        {
            return await _context.Books.OrderBy(t => t.Title).ToListAsync();
        }
        public async Task<int> UpdateBookAsync(Book book)
        {
            _context.Books.Update(book);
            return await _context.SaveChangesAsync();
        }
    }
}
