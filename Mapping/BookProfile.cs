using AutoMapper;
using LibraryManagementSystem.Models;
using LibraryManagementSystem.ViewModels.BookVM;

namespace LibraryManagementSystem.Mapping
{
    public class BookProfile : Profile
    {
        public BookProfile()
        {
            CreateMap<Book, BookVM>();
            CreateMap<BookVM, Book>();
            CreateMap<Book, CreateBookVM>();
            CreateMap<CreateBookVM, Book>();
            CreateMap<Book, UpdateBookVM>();
            CreateMap<UpdateBookVM, Book>();
        }
    }

}
