using AuthTutorial.Auth.Common;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Threading.Tasks;
using WebApi1.Models;
using WebApi1.Models.ViewModels;

namespace WebApi1.Services
{
    public class UserService
    {
        private readonly UsersContext _context;
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly AuthOptions _options;
        public UserService(UserManager<User> userManager, RoleManager<IdentityRole> roleManager,IOptions<AuthOptions>options,UsersContext context)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _options = options.Value;
            _context = context;
        }
        public async Task<string> RegisterAsync(RegisterViewModel model)
        {
            var user = new User()
            {
                UserName=model.Email,
                Email=model.Email,
                Year=model.Year
            };
       var result = await _userManager.CreateAsync(user, model.Password);
            if (result.Succeeded)
            {
                return $"User registrated with name {model.Email}";
            }
            return "Fail!";

        }

        public async Task<Object> GetTokenAsync(RequestTokenModel model)
        {
            var user = await _userManager.FindByEmailAsync(model.Email);
            if (user == null)
            {
                return new {message="User with this name doesn't exist!" };
            }
            if (await _userManager.CheckPasswordAsync(user, model.Password))
            {
                RefreshToken finalRefreshToken;
                if (user.RefreshTokens.Any(u => u.IsActive))
                {
                    var activeRefreshToken = user.RefreshTokens.FirstOrDefault(t => t.IsActive);
                    finalRefreshToken = activeRefreshToken;
                }
                else
                {
                    var refreshToken = CreateRefreshToken();
                    finalRefreshToken = refreshToken;
                    user.RefreshTokens.Add(refreshToken);
                    _context.Update(user);
                    _context.SaveChanges();
                }
                return new {
                    token = CreateJwtToken(user).Result,
                    refreshToken=finalRefreshToken
                };
            }
            return new { message = "Not valid password!" };
        }
        private async Task<string>CreateJwtToken(User user)
        {
            var userClaims = await _userManager.GetClaimsAsync(user);
            var roles = await _userManager.GetRolesAsync(user);
            var rolesClaims = new List<Claim>();
            foreach (var role in roles)
            {
                rolesClaims.Add(new Claim("roles", role));
            }
            var claims = new List<Claim>()
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim("uid", user.Id)
            }.Union(userClaims).Union(rolesClaims);
            var securityKey = _options.GetSymmetricSecurityKey();
            var credential = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(
                issuer: _options.Issuer,
                audience: _options.Audience,
                claims: claims,
                expires: DateTime.Now.AddSeconds(_options.TokenLifeTime),
                signingCredentials: credential
                );
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
        private RefreshToken CreateRefreshToken()
        {
            var randomNamber = new byte[32];

            using(var generator=new RNGCryptoServiceProvider())
            {
                generator.GetBytes(randomNamber);
                return new RefreshToken
                {
                    Token = Convert.ToBase64String(randomNamber),
                    Expires=DateTime.Now.AddDays(10),
                    Created=DateTime.Now
                };
            }
        }
    

    }
}
