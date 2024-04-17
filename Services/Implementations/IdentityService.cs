using Azure.Core;
using diplom_back.Data.Entities;
using diplom_back.Models.Identity;
using diplom_back.Services.Interfaces;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace diplom_back.Services.Implementations
{
    public class IdentityService : IIdentityService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IConfiguration _configuration;

        public IdentityService(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, IConfiguration configuration) 
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _configuration = configuration;
        }

        public async Task<IdentityResult> SignUp(SignUpDTO signUpDTO) 
        {
            var user = new ApplicationUser
            {
                FirstName = signUpDTO.FirstName,
                NormalizedFirstName = signUpDTO.FirstName.ToUpper(),
                LastName = signUpDTO.LastName,
                NormalizedLastName = signUpDTO.LastName.ToUpper(),
                MiddleName = signUpDTO.MiddleName,
                NormalizedMiddleName = signUpDTO.MiddleName.ToUpper(),
                Email = signUpDTO.Email,
                UserName = signUpDTO.Email
            };

            var result = await _userManager.CreateAsync(user, signUpDTO.Password);
            if (result.Succeeded) await _userManager.AddToRoleAsync(user, "FreeUser");

            return result;
        }

        public async Task<SignInResponse> SignIn(SignInDTO signInDTO)
        {
            var response = new SignInResponse();
            var identityUser = await _userManager.FindByEmailAsync(signInDTO.Email);

            if (identityUser is null || (await _userManager.CheckPasswordAsync(identityUser, signInDTO.Password)) == false)
            {
                return response;
            }

            response.Type = "Bearer";
            response.Token = this.GenerateTokenString(identityUser).Result;

            return response;
        }

        private async Task<string> GenerateTokenString(ApplicationUser user)
        {
            var roles = await _userManager.GetRolesAsync(user);

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.Email),
                new Claim(JwtRegisteredClaimNames.Aud, _configuration["Jwt:Audience"]),
                new Claim(JwtRegisteredClaimNames.Iss, _configuration["Jwt:Issuer"])
            };

            foreach (var role in roles) claims.Add(new Claim(ClaimTypes.Role, role));

            var staticKey = _configuration.GetSection("Jwt:Key").Value;
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(staticKey));
            var signingCred = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);

            var securityToken = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddHours(1),
                signingCredentials: signingCred
                );

            string tokenString = new JwtSecurityTokenHandler().WriteToken(securityToken);
            return tokenString;
        }
    }
}
