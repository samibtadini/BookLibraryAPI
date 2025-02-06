using System.ComponentModel.DataAnnotations;

namespace BookLibraryAPI.Entities
{
    public class Book
    {
        [Key]
        public int Id { get; set; } 

        [Required]
        [MaxLength(100)]
        public string Title { get; set; }

        [Required]
        public int AuthorId { get; set; }
        public Author Author { get; set; }

        [MaxLength(500)]
        public string? Description { get; set; }
    }
}
