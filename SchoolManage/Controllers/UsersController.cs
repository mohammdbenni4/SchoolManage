using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SchoolManage.Helpers;
using SchoolManage.Models;
using SchoolManage.Services;

namespace SchoolManage.Controllers
{
  
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly UserManager<ApplicationUser> _userManager;
        public UsersController(IUserService userService, UserManager<ApplicationUser> userManager)
        {
            _userService = userService;
            _userManager = userManager; 
        }

        [Authorize(Roles = "Admin")]
        [HttpGet("getUserInfo")]
        public async Task<IActionResult> GetUserInfo([FromBody] SearchUserByEmail model)
        {
            if (!ModelState.IsValid) {return BadRequest(ModelState);}

            var result = await _userService.GetUserInfo(model) ;

            if (!string.IsNullOrEmpty(result.Massage)) 
                return BadRequest(result.Massage);

            return Ok(result);

        }

        [Authorize(Roles = "Admin")]
        [HttpPost("addUserToRole")]
        public async Task<IActionResult> AddToRole([FromBody] AddToRoleModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _userService.AddToRoleAsync(model);

            if (!string.IsNullOrEmpty(result))
                return BadRequest(result);

            return Ok(result);
        }
        [Authorize(Roles = "Admin")]
        [HttpPost("removefromRole")]
        public async Task<IActionResult> RemoveFromRole([FromBody] AddToRoleModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await _userService.RemoveFromRole(model);

            if(result == "something went wrong")
                return BadRequest(result);

            return Ok(result);
        }

        [HttpPut("editMyProfile")]
        public async Task<IActionResult> EditMyProfile([FromForm]UserEditProfile model)
        {
            if (!ModelState.IsValid )
                return BadRequest(ModelState);

            var result = await _userService.EditMyProfile(model);
            if (!string.IsNullOrEmpty(result.Massage))
                return BadRequest(result.Massage);
            ApplicationUser user = null;

            if (model.NewEmail == null) user = await _userManager.FindByEmailAsync(model.Email);
            if (model.NewEmail != null) user = await _userManager.FindByEmailAsync(model.NewEmail);

            return Ok(user);
            
            
        }
        [Authorize(Roles ="Admin")]
        [HttpGet("getUsersByRoleName")]
        public async Task<IActionResult> GetUsersByRoleName([FromBody]SearchRoleByName model)
        {
            if (!ModelState.IsValid) return BadRequest(model);

            var result = await _userService.GetUsersByRoleName(model) ;

            if(result == "somthing went wrong")
                return BadRequest(result);


            return Ok(result);

        }
        [Authorize(Roles ="Admin")]
        [HttpDelete("deleteUser")]
        public async Task<IActionResult> DelUser(SearchUserByEmail model)
        {
            if (!ModelState.IsValid) return BadRequest(model);

            var result = await _userService.DelUser(model);


            if (result == "somthing went wrong")
                return BadRequest(result);
            
            return Ok(result);
        }
    }
}
