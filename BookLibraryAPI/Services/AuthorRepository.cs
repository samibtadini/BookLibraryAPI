using BookLibraryAPI.DbContexts;
using BookLibraryAPI.Entities;
using Microsoft.EntityFrameworkCore;

namespace BookLibraryAPI.Services
{
    public class AuthorRepository : IAuthorRepository
    {
        private readonly BookLibraryContext _context;
        public AuthorRepository(BookLibraryContext context)
        {
            _context = context;
        }
        public async Task<Author> GetAuthorAsync(int id)
        {
            return await _context.Authors.Include(b => b.Books).FirstOrDefaultAsync(a => a.Id == id);
        }

    }
}
