using System.ComponentModel.DataAnnotations;

namespace LibraryManagementSystem.ViewModels.UserVM
{
    public class CreateUserVM
    {
        public string Name { get; set; } = string.Empty;
        [Required, Phone, MaxLength(20)]
        public string PhoneNumber { get; set; } = string.Empty;
    }
}
