using AutoMapper;
using LibraryManagementSystem.DTOs.BookDtos;
using LibraryManagementSystem.Models;

namespace LibraryManagementSystem.Mapping
{
    public class BookProfile : Profile
    {
        public BookProfile()
        {
            // Book -> BookDto
            CreateMap<Book, BookDto>()
                .ForMember(dest => dest.ImgSrc,
                    opt => opt.MapFrom(src => ConvertDbImgToImageSrc(src.DbImg)));

            // CreateBookDto -> Book
            CreateMap<CreateBookDto, Book>()
                .ForMember(dest => dest.DbImg,
                    opt => opt.MapFrom(src => ConvertIFormFileToBytes(src.Img)));

            // UpdateBookDto -> Book (only update DbImg if new Img provided)
            CreateMap<UpdateBookDto, Book>()
                .ForMember(dest => dest.DbImg, opt =>
                {
                    opt.Condition(src => src.Img != null);
                    opt.MapFrom(src => ConvertIFormFileToBytes(src.Img));
                });

            // Book -> UpdateBookDto
            CreateMap<Book, UpdateBookDto>()
                .ForMember(dest => dest.ImgSrc,
                    opt => opt.MapFrom(src => ConvertDbImgToImageSrc(src.DbImg)))
                .ForMember(dest => dest.Img, opt => opt.Ignore());

        }

        private static byte[]? ConvertIFormFileToBytes(IFormFile? file)
        {
            if (file == null) return null;

            using var memoryStream = new MemoryStream();
            file.CopyTo(memoryStream);
            return memoryStream.ToArray();
        }

        private static string? ConvertDbImgToImageSrc(byte[]? DbImg)
        {
            if (DbImg == null) return null;

            string base64String = Convert.ToBase64String(DbImg, 0, DbImg.Length);
            return $"data:image/png;base64,{base64String}";
        }
    }

}
