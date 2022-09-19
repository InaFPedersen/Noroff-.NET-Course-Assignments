using Tidsbanken_Backend.Models.Domain;
using Tidsbanken_Backend.Models.DTOs.Self;
using Tidsbanken_Backend.Models.DTOs.Admin;
using AutoMapper;

namespace Tidsbanken_Backend.Profiles
{
    public class AdminUserProfile : Profile
    {
        public AdminUserProfile()
        {
            CreateMap<AdminCreateUserDTO, User>();
            CreateMap<User, AdminCreateUserDTO>();

            CreateMap<AdminReadUserDTO, User>();
            CreateMap<User, AdminReadUserDTO>();

            CreateMap<AdminUpdateUserDTO, User>();
            CreateMap<User, SelfReadOtherUserDTO>();
        }
    }
}
