using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SchoolManage.Helpers;
using SchoolManage.Services;

namespace SchoolManage.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class BacStudentsController : ControllerBase
    {
        private readonly IBacStudentService _bacStudentService;
        public BacStudentsController(IBacStudentService bacStudentService)
        {
            _bacStudentService = bacStudentService;
        }
        [Authorize(Roles = "Admin,BacStudent,BacTeacher")]
        [HttpGet("getSubjectCourses")]
        public async Task<IActionResult> GetCoursesForSujectByName(SearchSubjectByName model)
        {
            if (!ModelState.IsValid) { return BadRequest(ModelState); }

            var result = await _bacStudentService.GetCoursesForSujectByName(model);

            if (result == "no subject with this name")
                return BadRequest(result);

            return Ok(result);
        
        }
    }
}
