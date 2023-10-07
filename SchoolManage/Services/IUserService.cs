using SchoolManage.Helpers;
using SchoolManage.Models;

namespace SchoolManage.Services
{
    public interface IUserService
    {
        Task<string> AddToRoleAsync(AddToRoleModel model);
        Task<string> RemoveFromRole(AddToRoleModel model);
        Task<UserInfo> GetUserInfo(SearchUserByEmail model);
        Task<UserEditProfile> EditMyProfile(UserEditProfile model);
        Task<string> GetUsersByRoleName(SearchRoleByName model);
        Task<string> DelUser(SearchUserByEmail model);
    }
}
