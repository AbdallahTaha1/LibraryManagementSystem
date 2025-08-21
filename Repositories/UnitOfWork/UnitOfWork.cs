using LibraryManagementSystem.Data;
using LibraryManagementSystem.Repositories.BookRepository;
using LibraryManagementSystem.Repositories.TrasactionRepository;
using LibraryManagementSystem.Repositories.UserRepository;

namespace LibraryManagementSystem.Repositories.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;

        public UnitOfWork(
            AppDbContext context,
            IUserRepository userRepository,
            IBookRepository bookRepository,
            ITransactionRepository transactionRepository)
        {
            _context = context;
            Users = userRepository;
            Books = bookRepository;
            Transactions = transactionRepository;
        }

        public IUserRepository Users { get; }
        public IBookRepository Books { get; }
        public ITransactionRepository Transactions { get; }

        public void Dispose() => _context.Dispose();

        public Task<int> SaveChangesAsync() => _context.SaveChangesAsync();
    }
}
