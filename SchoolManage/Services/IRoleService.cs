using Microsoft.AspNetCore.Identity;
using SchoolManage.Models;

namespace SchoolManage.Services
{
    public interface IRoleService
    {
        Task<string> AddNewRole(AddNewRole model);
        Task<string> DeleteRole(AddNewRole model);
        Task<string> EditRole(EditRole model);
        Task<List<IdentityRole>> GetAllRoles();
    }
}
