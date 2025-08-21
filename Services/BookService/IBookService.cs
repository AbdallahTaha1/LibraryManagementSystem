using LibraryManagementSystem.Models;
namespace LibraryManagementSystem.Services.BookService
{
    public interface IBookService
    {
        Task<Book?> GetBookById(Guid id);
        IEnumerable<Book> GetAllBooks();
        // check if there is a book with the same ISBN
        Task<bool> IsBookExists(string isbn);
        Task<bool> AddBook(Book book);
        Task<bool> EditBook(Book book);
        Task<bool> DeleteBook(Guid id);

    }
}
