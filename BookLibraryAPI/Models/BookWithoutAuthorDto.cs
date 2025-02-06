namespace BookLibraryAPI.Models
{
    public class BookWithoutAuthorDto
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string? Description { get; set; }
    }
}
