using LibraryManagementSystem.Models;
using LibraryManagementSystem.Repositories.UnitOfWork;

namespace LibraryManagementSystem.Services.BookService
{
    public class BookService : IBookService
    {
        private readonly IUnitOfWork _unitOfWork;

        public BookService(IUnitOfWork unitOfWork) =>
            _unitOfWork = unitOfWork;

        public IEnumerable<Book> GetAllBooks()
        {
            return _unitOfWork.Books.GetAll().ToList();
        }

        public async Task<Book?> GetBookById(Guid id)
        {
            return await _unitOfWork.Books.FindAsync(b => b.Id == id);
        }

        public async Task<bool> AddBook(Book book)
        {
            _unitOfWork.Books.Add(book);
            var rows = await _unitOfWork.SaveChangesAsync();
            return rows > 0;
        }

        public async Task<bool> DeleteBook(Guid id)
        {
            var book = _unitOfWork.Books.Find(b => b.Id == id);

            if (book == null) return false; // Book not found

            _unitOfWork.Books.Delete(book);
            await _unitOfWork.SaveChangesAsync();
            return true; // Book deleted successfully   
        }

        public async Task<bool> EditBook(Book edited)
        {
            _unitOfWork.Books.Update(edited);
            var rows = await _unitOfWork.SaveChangesAsync();
            return rows > 0;
        }

        public async Task<bool> IsBookExists(string isbn)
        {
            var book = await _unitOfWork.Books.FindAsync(b => b.Isbn == isbn);
            return book is not null;
        }
    }
}
