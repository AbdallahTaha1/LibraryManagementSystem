using LibraryManagementSystem.Consts;
using System.ComponentModel.DataAnnotations;

namespace LibraryManagementSystem.DTOs.TransactionDtos
{
    public class CreateTransactionDto
    {
        [Required]
        public Guid UserId { get; set; }

        [Required]
        public Guid BookId { get; set; }

        [Required]
        public TransactionType Type { get; set; } // Borrow / Return
    }
}
