using LibraryManagementSystem.DTOs.TransactionDtos;
using LibraryManagementSystem.Models;

namespace LibraryManagementSystem.Services.TransactionService
{
    public interface ITransactionService
    {
        Task<IEnumerable<Transaction>> GetAllTransactionsAsync();
        Task<Transaction?> GetTransactionById(Guid id);
        Task<bool> ReturnBook(CreateTransactionDto transactionDto);
        Task<bool> BorrowBook(CreateTransactionDto transactionDto);

    }
}
