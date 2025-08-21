using LibraryManagementSystem.Repositories.BookRepository;
using LibraryManagementSystem.Repositories.TrasactionRepository;
using LibraryManagementSystem.Repositories.UserRepository;

namespace LibraryManagementSystem.Repositories.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        IUserRepository Users { get; }
        IBookRepository Books { get; }
        ITransactionRepository Transactions { get; }
        Task<int> SaveChangesAsync();
    }
}
