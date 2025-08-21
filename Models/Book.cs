using System.ComponentModel.DataAnnotations;

namespace LibraryManagementSystem.Models
{
    public class Book
    {
        [Key]
        public Guid Id { get; set; }
        [Required, MaxLength(200)]
        public string Title { get; set; } = string.Empty;
        [Required]
        public int NumberOfCopies { get; set; }
        public int AvailableCopies { get; set; }

        public IFormFile Img { get; set; } = null!;

    }
}
