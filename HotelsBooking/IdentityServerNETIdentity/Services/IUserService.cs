using IdentityServerNETIdentity.Data;
using IdentityServerNETIdentity.Models;
using IdentityServerNETIdentity.ViewModels;
using IdentityServerNETIdentity.ViewModels.User;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace IdentityServerNETIdentity.Services
{
    public interface IUserService
    {
        Task<PetitionResponse> Authenticate(ApplicationDbContext context, LoginViewModel loginModel);
        //Task<PetitionResponse> Register(ApplicationDbContext context, RegisterViewModel registerModel);
        //Task<PetitionResponse> UserExists(ApplicationDbContext context, string correo);
        //Task<IEnumerable<PetitionResponse>>  GetAll();
        //PetitionResponse GetById(int id);
    }
}
