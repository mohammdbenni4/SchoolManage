using SchoolManage.Helpers;

namespace SchoolManage.Services
{
    public interface IBacStudentService
    {
        Task<string> GetCoursesForSujectByName(SearchSubjectByName model);
    }
}
