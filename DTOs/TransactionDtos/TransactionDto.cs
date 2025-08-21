using LibraryManagementSystem.Consts;

namespace LibraryManagementSystem.DTOs.TransactionDtos
{
    public class TransactionDto
    {
        public DateTime Date { get; set; }
        public TransactionType Type { get; set; } // 0 for borrow, 1 for return

        public Guid UserId { get; set; }
        public Guid BookId { get; set; }
    }
}
