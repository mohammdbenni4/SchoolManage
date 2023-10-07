using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SchoolManage.Models;
using SchoolManage.Services;

namespace SchoolManage.Controllers
{
    [Authorize(Roles ="Admin")]
    [Route("api/[controller]")]
    [ApiController]
    public class RolesController : ControllerBase
    {
        private readonly IRoleService _roleService;

        public RolesController(IRoleService roleService)
        {
            _roleService = roleService;
        }

        [HttpGet("getAllRoles")]
        public async Task<IActionResult> GetAllRoles()
        {
            var roles = await _roleService.GetAllRoles();

            var myRoles = string.Empty;
            foreach (var role in roles)
            {
                myRoles += role.Name + " , ";
            }
            
            return Ok(myRoles);
        }


        [HttpPost("addNewRole")]
        public async Task<IActionResult> AddNewRole([FromBody] AddNewRole model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _roleService.AddNewRole(model);

            if (!string.IsNullOrEmpty(result))
                return BadRequest(result);

            return Ok(result);
        }

        [HttpDelete("deleteRole")]
        public async Task<IActionResult> DeleteRole([FromBody] AddNewRole model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _roleService.DeleteRole(model);

            if (result == "somthing went wrong")
                return BadRequest(result);

            return Ok(result);
        }

        [HttpPut("editRole")]
        public async Task<IActionResult> EditRole([FromBody] EditRole model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _roleService.EditRole(model);

            if (result == "somthing went wrong")
                return BadRequest(result);


            return Ok(result);
        }



        
    }
}
