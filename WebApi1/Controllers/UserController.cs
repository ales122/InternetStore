using AuthTutorial.Auth.Common;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using WebApi1.Constants;
using WebApi1.Models;
using WebApi1.Models.ViewModels;
using WebApi1.Services;

namespace WebApi1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserService _userService;
        
        public UserController(UserService userService)
        {
            _userService = userService;
        }

        [HttpPost("register")]
        public async Task<ActionResult> RegisterAsync(RegisterViewModel model)
        {
            var result =await _userService.RegisterAsync(model);
            return Ok(result);
        }
        

        [HttpPost("token")]
        public async Task<JsonResult> GetTokenAsync(RequestTokenModel model)
        {
            var result =await _userService.GetTokenAsync(model);
            //SetRefreshTokenInCookie(result.RefreshToken.Token);
            return new JsonResult(result);
        }
       
        [Authorize]
        [Route("private")]
        [HttpGet]
        public async Task<ActionResult<ProfileViewModel>> getPrivate()
        {
            if (User.Identity.IsAuthenticated)
            {
                ProfileViewModel profile = new ProfileViewModel();
                profile.Name = User.Identity.Name;
                profile.Roles =await _userService.GetAllUserRoles(profile.Name);
                //var roles = User.Identity.Roles;
                return Ok(profile);
            }
            return NotFound();
          
        }


        [Route("public")]
        [HttpGet]
        public ActionResult getPublic()
        {
            return Content($"User:{User.Identity.IsAuthenticated} {User.Identity.Name}");
        }


        [HttpGet("all")]
        public async Task<IEnumerable<User>> GetAll()
        {
            return await _userService.GetAll();
        }

        private void SetRefreshTokenInCookie(string refreshToken)
        {
            var cookieOptions = new CookieOptions
            {
                HttpOnly = true,
                Expires = DateTime.UtcNow.AddDays(10),
            };
            Response.Cookies.Append("refreshToken", refreshToken, cookieOptions);
        }

    }
}
