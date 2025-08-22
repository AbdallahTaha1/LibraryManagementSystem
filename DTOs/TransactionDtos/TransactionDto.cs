using LibraryManagementSystem.Consts;

namespace LibraryManagementSystem.DTOs.TransactionDtos
{
    public class TransactionDto
    {
        public Guid Id { get; set; }
        public DateTime Date { get; set; }
        public TransactionType Type { get; set; } // Borrow / Return

        public Guid UserId { get; set; }
        public string UserName { get; set; } = string.Empty;

        public Guid BookId { get; set; }
        public string BookTitle { get; set; } = string.Empty;
    }
}
