using System.ComponentModel.DataAnnotations;

namespace LibraryManagementSystem.ViewModels.UserVM
{
    public class UserVM
    {
        public string Name { get; set; } = string.Empty;
        [Required, Phone, MaxLength(20)]
        public string PhoneNumber { get; set; } = string.Empty;
    }
}
