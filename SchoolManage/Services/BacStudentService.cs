using Microsoft.EntityFrameworkCore;
using SchoolManage.Helpers;
using SchoolManage.Models;

namespace SchoolManage.Services
{
    public class BacStudentService : IBacStudentService
    {
        private readonly ApplicationDbContext _context;
        public BacStudentService(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<string> GetCoursesForSujectByName(SearchSubjectByName model)
        {
            var subject = await _context.BacSubjects.FirstOrDefaultAsync(i => i.Name == model.Name);

            if (subject == null)
            {
                return "no subject with this name";
            }
            var courses = await _context.BacSubjectCourses.Where(i=>i.BacSubjectId==subject.Id).ToListAsync();
            var str = string.Empty;

            foreach (var course in courses)
            { 
                str += course.Name+" , ";
            }
            return str;

        }
    }
}
