using AutoMapper;
using BudgetTestServer.Data.Models;

namespace BudgetTestServer.Features.LegalEntities.Models
{
    public class LegalEntityProfile : Profile
    {
        public LegalEntityProfile()
        {
            CreateMap<LegalEntity, CreateLegalEntityRequestModel>().ReverseMap();
            CreateMap<LegalEntity, LegalEntityServiceModel>().ReverseMap();
            CreateMap<LegalEntity, UpdateLegalEntityRequestModel>().ReverseMap();
        }
    }
}
