using LibraryManagementSystem.Models;
using LibraryManagementSystem.Repositories.UnitOfWork;

namespace LibraryManagementSystem.Services.UserService
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;

        public UserService(IUnitOfWork unitOfWork) =>
            _unitOfWork = unitOfWork;

        public IEnumerable<User> GetAllUsers()
        {
            return _unitOfWork.Users.GetAll().ToList();
        }

        public async Task<User?> GetUserById(Guid id)
        {
            return await _unitOfWork.Users.FindAsync(u => u.Id == id);
        }

        public async Task<bool> AddUser(User user)
        {
            _unitOfWork.Users.Add(user);
            var rows = await _unitOfWork.SaveChangesAsync();
            return rows > 0;
        }

        public async Task<bool> DeleteUser(Guid id)
        {
            var user = _unitOfWork.Users.Find(u => u.Id == id);

            if (user == null) return false;

            _unitOfWork.Users.Delete(user);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }

        public async Task<bool> EditUser(User edited)
        {
            _unitOfWork.Users.Update(edited);
            var rows = await _unitOfWork.SaveChangesAsync();
            return rows > 0;
        }

        public async Task<bool> IsUserExists(string phoneNumber)
        {
            var user = await _unitOfWork.Users.FindAsync(u => u.PhoneNumber == phoneNumber);
            return user is not null;
        }

    }
}
