using diplom_back.Models.Identity;
using Microsoft.AspNetCore.Identity;

namespace diplom_back.Services.Interfaces
{
    public interface IIdentityService
    {
        public Task<IdentityResult> SignUp(SignUpDTO signUpDTO);
        public Task<SignInResponse> SignIn(SignInDTO signInDTO);
    }
}
