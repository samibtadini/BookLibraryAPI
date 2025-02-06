using BookLibraryAPI.Entities;
using Microsoft.EntityFrameworkCore;
namespace BookLibraryAPI.DbContexts
{
    public class BookLibraryContext : DbContext
    {
 
        public BookLibraryContext(DbContextOptions<BookLibraryContext> options)
            : base(options)
        {
        }
        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Author>().HasData(
                new Author
                {
                    Id = 1,
                    Name = "George R. R. Martin",
                    Bio = "George Raymond Richard Martin, also known as GRRM, is an American novelist and short story writer, screenwriter, and television producer. He is the author of the series of epic fantasy novels A Song of Ice and Fire, which was adapted into the Emmy Award-winning HBO series Game of Thrones."
                },
                new Author
                {
                    Id = 2,
                    Name = "J. R. R. Tolkien",
                    Bio = "John Ronald Reuel Tolkien was an English writer, poet, philologist, and academic, best known as the author of the high fantasy works The Hobbit and The Lord of the Rings."
                },
                new Author
                {
                    Id = 3,
                    Name = "J. K. Rowling",
                    Bio = "Joanne Rowling, better known by her pen name J. K. Rowling, is a British author, philanthropist, film producer, television producer, and screenwriter. She is best known for writing the Harry Potter fantasy series, which has won multiple awards and sold more than 500 million copies, becoming the best-selling book series in history."
                }
            );
            modelBuilder.Entity<Book>().HasData(
                new Book
                {
                    Id = 1,
                    Title = "A Game of Thrones",
                    AuthorId = 1,
                    Description = "A Game of Thrones is the first novel in A Song of Ice and Fire, a series of fantasy novels by the American author George R. R. Martin. It was first published on August 6, 1996."
                },
                new Book
                {
                    Id = 2,
                    Title = "The Hobbit",
                    AuthorId = 2,
                    Description = "The Hobbit, or There and Back Again is a children's fantasy novel by English author J. R. R. Tolkien. It was published on 21 September 1937 to wide critical acclaim, being nominated for the Carnegie Medal and awarded a prize from the New York Herald Tribune for best juvenile fiction."
                },
                new Book
                {
                    Id = 3,
                    Title = "Harry Potter and the Philosopher's Stone",
                    AuthorId = 3,
                    Description = "Harry Potter and the Philosopher's Stone is a fantasy novel written by British"
                }
            );
            base.OnModelCreating(modelBuilder);
        }
    }

} 

