using System.ComponentModel.DataAnnotations;

namespace LibraryManagementSystem.DTOs.UserDtos
{
    public class CreateUserDto
    {
        public string Name { get; set; } = string.Empty;
        [Required, Phone, MaxLength(20)]
        public string PhoneNumber { get; set; } = string.Empty;
    }
}
