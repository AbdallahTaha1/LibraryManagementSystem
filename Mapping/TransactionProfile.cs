using AutoMapper;
using LibraryManagementSystem.DTOs.TransactionDtos;
using LibraryManagementSystem.Models;

namespace LibraryManagementSystem.Mapping
{
    public class TransactionProfile : Profile
    {
        public TransactionProfile()
        {
            // Entity → DTO
            CreateMap<Transaction, TransactionDto>()
                .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.User.Name))
                .ForMember(dest => dest.BookTitle, opt => opt.MapFrom(src => src.Book.Title));

        }
    }
}
