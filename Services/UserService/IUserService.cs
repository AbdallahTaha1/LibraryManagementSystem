using LibraryManagementSystem.Models;

namespace LibraryManagementSystem.Services.UserService
{
    public interface IUserService
    {
        IEnumerable<User> GetAllUsers();
        Task<User?> GetUserById(Guid id);
        Task<bool> AddUser(User user);
        Task<bool> EditUser(User edited);
        Task<bool> DeleteUser(Guid id);
        Task<bool> IsUserExists(string phoneNumber);
    }
}
