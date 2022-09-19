using Tidsbanken_Backend.Models.Domain;
using Tidsbanken_Backend.Models.DTOs.Self;
using Tidsbanken_Backend.Models.DTOs;
using AutoMapper;

namespace Tidsbanken_Backend.Profiles
{
    public class SelfUserProfile : Profile
    {
        public SelfUserProfile()
        {
            CreateMap<SelfReadUserDTO, User>();
            CreateMap<User, SelfReadUserDTO>();

            CreateMap<SelfUpdateUserDTO, User>();
            CreateMap<User, SelfUpdateUserDTO>();

            CreateMap<SelfReadOtherUserDTO, User>();
            CreateMap<User, SelfReadOtherUserDTO>();
        }
    }
}
