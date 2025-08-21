using LibraryManagementSystem.Data;
using LibraryManagementSystem.Repositories.BaseRepository;
using System.Transactions;

namespace LibraryManagementSystem.Repositories.TrasactionRepository
{
    public class TransactionRepository : BaseRepository<Transaction>, ITransactionRepository
    {
        public TransactionRepository(AppDbContext context) : base(context)
        {
        }
    }
}
