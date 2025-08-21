using System.ComponentModel.DataAnnotations;

namespace LibraryManagementSystem.DTOs.UserDtos
{
    public class UpdateUserDto
    {
        [Required]
        public Guid Id { get; set; }

        [Required, MaxLength(100)]
        public string Name { get; set; } = string.Empty;

        [Required, Phone, MaxLength(20)]
        public string PhoneNumber { get; set; } = string.Empty;
    }
}
