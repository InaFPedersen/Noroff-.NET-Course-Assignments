using Tidsbanken_Backend.Models.Domain;
using Tidsbanken_Backend.Models.DTOs.Admin;
using AutoMapper;

namespace Tidsbanken_Backend.Profiles
{
    public class AdminRequestsProfile : Profile
    {
        public AdminRequestsProfile()
        {
            CreateMap<AdminReadVacationRequestDTO, VacationRequest>();
            CreateMap<VacationRequest, AdminReadVacationRequestDTO>();

        }
    }
}
