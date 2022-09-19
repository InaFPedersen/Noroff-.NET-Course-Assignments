using Tidsbanken_Backend.Models.Domain;
using Tidsbanken_Backend.Models.DTOs.Admin;
using AutoMapper;

namespace Tidsbanken_Backend.Profiles
{
    public class AdminRequestStatusProfile : Profile
    {
        public AdminRequestStatusProfile()
        {
            CreateMap<AdminUpdateVacationStatusDTO, VacationStatus>();
            CreateMap<VacationStatus, AdminUpdateVacationStatusDTO>();
        }
    }
}
