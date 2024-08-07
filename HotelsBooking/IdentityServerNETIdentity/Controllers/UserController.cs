using IdentityServerNETIdentity.Data;
using IdentityServerNETIdentity.Models;
using IdentityServerNETIdentity.Services;
using IdentityServerNETIdentity.ViewModels;
using IdentityServerNETIdentity.ViewModels.User;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Serilog;

namespace IdentityServerNETIdentity.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private ApplicationDbContext _context;
        private IUserService _userService;

        public UserController(ApplicationDbContext context, IUserService userService) 
        {
            _context = context;
            _userService = userService;
        }

        [HttpPost("authenticate")]
        public async Task<IActionResult> Autenticate(LoginViewModel loginModel)
        {
            try
            {
                PetitionResponse response = await _userService.Authenticate(_context, loginModel);
                if (!response.Success)
                    return BadRequest(new { message = response.Message });

                return Ok(response.Result);
            }
            catch (Exception ex)
            {
                Log.Error($"{ex}");
                return BadRequest(ex.Message);
            }
        }
    }
}
