using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using UserRoleIdentity.Data.Entity;
using UserRoleIdentity.Model.DTO;

namespace UserRoleIdentity.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<User> userManager;
        private readonly SignInManager<User> signInManager;

        public AccountController(UserManager<User> userManager, SignInManager<User> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }
        [HttpPost("SignIn")]
        public async Task<IActionResult> Login(LoginDTO login)
        {
            var user = await userManager.FindByEmailAsync(login.Email);
            var signInResult = await signInManager.CheckPasswordSignInAsync(user, login.Password, false);

            if (signInResult.Succeeded)
            {
                await signInManager.SignInAsync(user, isPersistent: false);
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpGet("SignOut")]
        public async Task Logout()
        {
            await signInManager.SignOutAsync();
        }
    }
}
