using LibraryManagementSystem.Consts;

namespace LibraryManagementSystem.ViewModels.TransactionVM
{
    public class CreateTransactionVM
    {
        public TransactionType Type { get; set; } // 0 for borrow, 1 for return

        public Guid UserId { get; set; }
        public Guid BookId { get; set; }
    }
}
