using LibraryManagementSystem.Models;
namespace LibraryManagementSystem.Services.BookService
{
    public interface IBookService
    {
        Book? GetBookById(string id);
        IEnumerable<Book> GetAllBooks();
        Task<bool> AddBook(Book book);
        bool EditBook(Book book);
        bool DeleteBook(string id);

    }
}
