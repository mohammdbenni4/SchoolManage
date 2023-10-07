using SchoolManage.Models;

namespace SchoolManage.Services
{
    public interface IAuthService
    {
        Task<AuthModel> RegisterAsync(RegisterModel model);
        Task<AuthModel> GetTokenAsync(GetTokenModel model);
       // Task<string> AddToRoleAsync(AddToRoleModel model);
        // Task<string> RemoveFromRoleAsync()
        
    }
}
