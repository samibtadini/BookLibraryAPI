using BookLibraryAPI.Entities;

namespace BookLibraryAPI.Models
{
    public class AuthorDto
    {
        /// <summary>
        /// important to have this property to be able to update the author
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Name of the author
        /// </summary>
        public string Name { get; set; } = string.Empty;
        /// <summary>
        /// Book of the author
        /// </summary>
        public ICollection<BookOfAuthorDto> Books { get; set; } = new List<BookOfAuthorDto>();
    } 
}
