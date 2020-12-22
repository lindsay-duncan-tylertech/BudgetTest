using AutoMapper;
using BudgetTestServer.Data.Models;

namespace BudgetTestServer.Features.Identity.Models
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<User, LoginRequestModel>().ReverseMap();
            CreateMap<User, LoginResponseModel>().ReverseMap();
            CreateMap<User, RegisterUserRequestModel>().ReverseMap();
        }
    }
}
