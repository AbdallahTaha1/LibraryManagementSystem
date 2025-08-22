using LibraryManagementSystem.Consts;
using LibraryManagementSystem.DTOs.TransactionDtos;
using LibraryManagementSystem.Models;
using LibraryManagementSystem.Repositories.UnitOfWork;

namespace LibraryManagementSystem.Services.TransactionService
{
    public class TransactionService : ITransactionService
    {
        private readonly IUnitOfWork _unitOfWork;

        public TransactionService(IUnitOfWork unitOfWork) =>
            _unitOfWork = unitOfWork;

        public async Task<IEnumerable<Transaction>> GetAllTransactionsAsync()
        {
            return await _unitOfWork.Transactions.GetAllAsync(new[] { "Book", "User" });
        }

        public async Task<Transaction?> GetTransactionById(Guid id)
        {
            return await _unitOfWork.Transactions.FindAsync(t => t.Id == id);
        }

        public async Task<bool> BorrowBook(CreateTransactionDto dto)
        {
            var book = await _unitOfWork.Books.FindAsync(b => b.Id == dto.BookId);
            if (book == null) return false;

            if (book.AvailableCopies == 0) return false;

            var transaction = new Transaction
            {
                Date = DateTime.Now,
                UserId = dto.UserId,
                BookId = dto.BookId,
                Type = TransactionType.Borrow
            };

            _unitOfWork.Transactions.Add(transaction);

            book.AvailableCopies -= 1;
            _unitOfWork.Books.Update(book);

            var rows = await _unitOfWork.SaveChangesAsync();
            return rows > 0;
        }

        public async Task<bool> ReturnBook(CreateTransactionDto dto)
        {
            var book = await _unitOfWork.Books.FindAsync(b => b.Id == dto.BookId);
            if (book == null) return false;

            if (book.AvailableCopies == book.NumberOfCopies) return false;

            var transaction = new Transaction
            {
                Date = DateTime.Now,
                UserId = dto.UserId,
                BookId = dto.BookId,
                Type = TransactionType.Return
            };

            _unitOfWork.Transactions.Add(transaction);

            book.AvailableCopies += 1;
            _unitOfWork.Books.Update(book);

            var rows = await _unitOfWork.SaveChangesAsync();
            return rows > 0;
        }
    }
}
