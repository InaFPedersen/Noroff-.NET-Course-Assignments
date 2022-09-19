using Tidsbanken_Backend.Models.Domain;
using Tidsbanken_Backend.Models.DTOs.Admin;
using AutoMapper;
using Tidsbanken_Backend.Models.DTOs;

namespace Tidsbanken_Backend.Profiles
{
    public class RequestStatusProfile : Profile
    {
        public RequestStatusProfile()
        {
            CreateMap<ReadVacationStatusDTO, VacationStatus>();
            CreateMap<VacationStatus, ReadVacationStatusDTO>();

            CreateMap<AdminUpdateVacationStatusDTO, VacationStatus>();
            CreateMap<VacationStatus, AdminUpdateVacationStatusDTO>();

        }
    }
}
