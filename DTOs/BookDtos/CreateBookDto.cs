using LibraryManagementSystem.Attributes;
using LibraryManagementSystem.Consts;
using System.ComponentModel.DataAnnotations;

namespace LibraryManagementSystem.DTOs.BookDtos
{
    public class CreateBookDto
    {
        [Required, MaxLength(20), Display(Name = "ISBN")]
        public string Isbn { get; set; } = string.Empty;
        [Required, MaxLength(200)]
        public string Title { get; set; } = string.Empty;
        [Required, Display(Name = "Number Of Copies")]
        public int NumberOfCopies { get; set; }
        [Required, Display(Name = "Number of available copies")]
        public int AvailableCopies { get; set; }
        [Display(Name = "Image File")]
        [AllowedExtentions(FileSettings.AllowedExtentions),
            MaxFileSize(FileSettings.MaxFileSizeInBytes)]
        public IFormFile? Img { get; set; } = null!;
    }
}
