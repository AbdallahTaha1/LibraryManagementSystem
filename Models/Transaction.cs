using LibraryManagementSystem.Consts;
using System.ComponentModel.DataAnnotations;

namespace LibraryManagementSystem.Models
{
    public class Transaction
    {
        [Key]
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public TransactionType Type { get; set; } // 0 for borrow, 1 for return

        public Guid UserId { get; set; }
        public Guid BookId { get; set; }
        public Book Book { get; set; } = default!;
        public User User { get; set; } = default!;
    }
}
