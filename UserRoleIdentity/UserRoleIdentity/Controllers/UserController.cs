using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Rewrite;
using Microsoft.EntityFrameworkCore;
using UserRoleIdentity.Data.Entity;
using UserRoleIdentity.Model.DTO;

namespace UserRoleIdentity.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserManager<User> userManager;
        private readonly IMapper mapper;

        public UserController(UserManager<User> userManager, IMapper mapper)
        {
            this.userManager = userManager;
            this.mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> Create(UserCreateDTO createDTO, string roleName)
        {
            var userEntity = mapper.Map<User>(createDTO);
            var saveResult = await userManager.CreateAsync(userEntity, createDTO.Password);
            if (!saveResult.Succeeded)
            {
                return BadRequest();
            }
            var roleExist = await userManager.IsInRoleAsync(userEntity, roleName);
            if (!roleExist)
            {
                var roleResult = await userManager.AddToRoleAsync(userEntity, roleName);
                if (!roleResult.Succeeded)
                {
                    return BadRequest();
                }
            }
            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> getAll()
        {
            var allUsers = await userManager.Users.ToListAsync();
            var result = mapper.Map<List<UserGetDTO>>(allUsers);
            return Ok(result);
        }
    }
}
    
