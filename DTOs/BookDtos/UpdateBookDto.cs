using System.ComponentModel.DataAnnotations;

namespace LibraryManagementSystem.DTOs.BookDtos
{
    public class UpdateBookDto
    {
        [Key]
        public Guid Id { get; set; }
        [Required, MaxLength(20)]
        public string Isbn { get; set; } = string.Empty;
        [Required, MaxLength(200)]
        public string Title { get; set; } = string.Empty;
        [Required]
        public int NumberOfCopies { get; set; }
        public int AvailableCopies { get; set; }

        public IFormFile Img { get; set; } = null!;
    }
}
