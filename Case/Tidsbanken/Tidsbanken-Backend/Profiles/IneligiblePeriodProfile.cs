using AutoMapper;
using Tidsbanken_Backend.Models.Domain;
using Tidsbanken_Backend.Models.DTOs.IneligiblePeriodDTO;
namespace Tidsbanken_Backend.Profiles
{
    public class IneligiblePeriodProfile : Profile
    {
        public IneligiblePeriodProfile()
        {
            CreateMap<CreateIneligiblePeriodDTO, IneligiblePeriod>();
            CreateMap<IneligiblePeriod, CreateIneligiblePeriodDTO>();

            CreateMap<UpdateIneligiblePeriodDTO, IneligiblePeriod>();
            CreateMap<IneligiblePeriod, UpdateIneligiblePeriodDTO>(); 

            CreateMap<ReadIneligiblePeriodDTO, IneligiblePeriod>();
            CreateMap<IneligiblePeriod, ReadIneligiblePeriodDTO>();
        }
    }
}
