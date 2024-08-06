using AutoMapper;
using IdentityServerNETIdentity.Models;
using IdentityServerNETIdentity.ViewModels.User;

namespace IdentityServerNETIdentity.Profiles
{
    public class ApplicationUserProfile : Profile
    {
        public ApplicationUserProfile()
        {
            CreateMap<RegisterViewModel, ApplicationUser>();
        }

    }
}
