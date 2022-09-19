using Tidsbanken_Backend.Models.Domain;
using Tidsbanken_Backend.Models.DTOs.Self;
using AutoMapper;

namespace Tidsbanken_Backend.Profiles
{
    public class SelfRequestsProfile : Profile
    {
        public SelfRequestsProfile()
        {
            CreateMap<SelfCreateVacationRequestDTO, VacationRequest>();
            CreateMap<VacationRequest, SelfCreateVacationRequestDTO>();

            CreateMap<SelfUpdateVacationRequestDTO, VacationRequest>();
            CreateMap<VacationRequest, SelfUpdateVacationRequestDTO>();

            CreateMap<VacationRequest, SelfReadVacationRequestDTO>()
                .ForMember(o => o.Status, opt => opt.MapFrom(v => v.VacationStatus.Status))
                .ReverseMap();
        }
    }
}
