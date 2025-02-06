using System.ComponentModel.DataAnnotations;

namespace BookLibraryAPI.Models
{
    public class BookForCreationDto
    {
        [Required(ErrorMessage = "You should provide a title value.")]
        [MaxLength(100)]
        public string Title { get; set; } = string.Empty;

        [MaxLength(500)]
        public string? Description { get; set; }
    }
}
