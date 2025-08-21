using AutoMapper;
using LibraryManagementSystem.DTOs.UserDtos;
using LibraryManagementSystem.Models;

namespace LibraryManagementSystem.Mapping
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            // Entity → DTO
            CreateMap<User, UserDto>();

            // DTO → Entity
            CreateMap<CreateUserDto, User>();
            CreateMap<UpdateUserDto, User>();

            // Entity → Update DTO
            CreateMap<User, UpdateUserDto>();
        }
    }
}
