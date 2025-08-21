using System.ComponentModel.DataAnnotations;

namespace LibraryManagementSystem.Models
{
    public class Book
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

        public byte[]? DbImg { get; set; } = null!;

    }
}
