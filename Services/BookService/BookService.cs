using LibraryManagementSystem.Models;
using LibraryManagementSystem.Repositories.BookRepository;

namespace LibraryManagementSystem.Services.BookService
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _bookRepository;

        public BookService(IBookRepository bookRepository) =>
            _bookRepository = bookRepository;

        public IEnumerable<Book> GetAllBooks()
        {
            return _bookRepository.GetAll().ToList();
        }

        public Book? GetBookById(string id)
        {
            return _bookRepository.Find(b => b.Id.ToString() == id);
        }

        public async Task<bool> AddBook(Book book)
        {
            var AddedBook = await _bookRepository.AddAsync(book);

            if (AddedBook != null)
                return true;

            return false;
        }

        public bool DeleteBook(string id)
        {
            var book = _bookRepository.Find(b => b.Id.ToString() == id);
            if (book == null)
            {
                return false; // Book not found
            }
            _bookRepository.Delete(book);
            return true; // Book deleted successfully   
        }

        public bool EditBook(Book book)
        {
            var edited = _bookRepository.Update(book);

            if (edited != null)
                return true;

            return false;
        }
    }
}
