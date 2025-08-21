using LibraryManagementSystem.Data;
using LibraryManagementSystem.Models;
using LibraryManagementSystem.Repositories.BaseRepository;

namespace LibraryManagementSystem.Repositories.BookRepository
{
    public class BookRepository : BaseRepository<Book>, IBookRepository
    {
        public BookRepository(AppDbContext context) : base(context)
        {
        }
    }
}
