using IdentityServerNETIdentity.Data;
using IdentityServerNETIdentity.Helpers;
using IdentityServerNETIdentity.Models;
using IdentityServerNETIdentity.Utils;
using IdentityServerNETIdentity.ViewModels;
using IdentityServerNETIdentity.ViewModels.User;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace IdentityServerNETIdentity.Services
{
    public class UserService : IUserService
    {
        private ApplicationDbContext db {  get; set; }
        private readonly AppSettings appSettings;
        private GenerateToken generateToken;


        public UserService(ApplicationDbContext _db, IOptions<AppSettings> _appSettings)
        {
            db = _db;
            appSettings = _appSettings.Value;
            generateToken = new GenerateToken();
        }

        public async Task<PetitionResponse> Authenticate(ApplicationDbContext _db, LoginViewModel loginModel)
        {
            ApplicationUser? applicationUser = await db.Users.Where(user => user.UserName == loginModel.Username).FirstOrDefaultAsync();
            if (applicationUser == null)
            {
                return AnswerResponse.Answer(false, "No existe usuario con este correo", null);
            }

            var token = await generateToken.Token(appSettings.IdentityUrlExternal, appSettings.ClientId, appSettings.Secret, appSettings.Scope);

            ConvertToken tokenC = (ConvertToken)token.Result;

            return token;
        }
    }
}
