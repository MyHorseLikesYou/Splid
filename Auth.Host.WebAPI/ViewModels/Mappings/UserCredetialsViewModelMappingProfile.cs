using Auth.Application.Models;
using AutoMapper;

namespace Auth.Host.WebAPI.ViewModels.Mappings
{
    public class UserCredetialsViewModelMappingProfile : Profile
    {
        public UserCredetialsViewModelMappingProfile()
        {
            this.CreateMap<UserCredentialsViewModel, UserCredentials>();                
        }
    }
}
