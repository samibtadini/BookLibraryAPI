﻿using BookLibraryAPI.Entities;

namespace BookLibraryAPI.Models
{
    public class BookDto
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string? Description { get; set; }
        public AuthorDto Author { get; set; }
    }
}
