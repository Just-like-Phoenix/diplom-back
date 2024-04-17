using Azure.Core;
using diplom_back.Models.Identity;
using diplom_back.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;

namespace diplom_back.Controllers
{
    [Route("api/identity")]
    [ApiController]
    public class IdentityController : ControllerBase
    {
        private readonly IIdentityService _identityService;

        public IdentityController(IIdentityService identityService)
        {
            _identityService = identityService;
        }


        [HttpPost]
        [Route("signup")]
        public async Task<IActionResult> SignUp(SignUpDTO signUpModel)
        {
            if (!ModelState.IsValid) return BadRequest();

            var result = await _identityService.SignUp(signUpModel);

            if (!result.Succeeded) return BadRequest(result.Errors);
            
            return Ok();
        }

        [HttpPost]
        [Route("signin")]
        public async Task<IActionResult> SignIn(SignInDTO signInModel)
        {
            if (!ModelState.IsValid) return BadRequest();

            var loginResult = await _identityService.SignIn(signInModel);
            if (loginResult.Token.IsNullOrEmpty()) return Unauthorized();

            return Ok(loginResult);
        }
    }
}
