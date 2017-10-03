using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TestWebAPI.Data.DTO;
using TestWebAPI.Services;

namespace TestWebAPI.Controllers
{
    [Route("api/[controller]")]
    [AllowAnonymous]
    public class UsersController : Controller
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly SignInManager<IdentityUser> signInManager;
        private readonly ITokenService tokenService;

        
        public UsersController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager,ITokenService tokenService)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.tokenService = tokenService;
        }


        // POST /token
        [HttpPost("/token")]
        public async Task<IActionResult> Login([FromBody]UserDTO userDTO)
        {
            IdentityUser user = await this.userManager.FindByNameAsync(userDTO.UserName);

            var result = await this.signInManager.PasswordSignInAsync(user, userDTO.Password, false, false);
            if (result.Succeeded)
            {
                return Ok(new {
                    Token = this.tokenService.CreateToken(user.UserName,user.Email, await this.userManager.GetRolesAsync(user)),
                    UserName = user.UserName,
                    Email = user.Email
                });
            }


            return BadRequest(new {
                Code = 2,
                Description = "Описание ошибки"
            });
        }

        // POST api/users/registration
        [HttpPost]
        public async Task<IActionResult> Registration([FromBody]UserDTO userDTO)
        {
            IdentityUser user = new IdentityUser() {Email = userDTO.Email, UserName = userDTO.UserName};

            IdentityResult result = await this.userManager.CreateAsync(user, userDTO.Password);

            if (result.Succeeded)
            {
                //Добавление ролей для пользователя ....
                //...
                
                
                return Ok(new {
                    Token = this.tokenService.CreateToken(user.UserName,user.Email,new List<string> { "SomeRolesForUser" }),
                    UserName = user.UserName,
                    Email = user.Email
                });
            }
            
            return BadRequest(new {
                Code = 1,
                Description = "Описание ошибки",
            });
        }
    }
}
