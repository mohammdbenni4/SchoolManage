using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using SchoolManage.Helpers;
using SchoolManage.Models;

namespace SchoolManage.Services
{
    public class RoleService : IRoleService
    {
        
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        public RoleService(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            
        }

        public async Task<string> AddNewRole(AddNewRole model)
        {
            var roleExist = await _roleManager.RoleExistsAsync(model.RoleName);

            if (roleExist)
                return "Role Is already exist";


            var result = await _roleManager.CreateAsync(new IdentityRole(model.RoleName.Trim()));

            return result.Succeeded ? string.Empty : "somthing went wrong";
        }
        public async Task<string> EditRole(EditRole model)
        {
            var roleExist = await _roleManager.FindByNameAsync(model.OldName);

            if (roleExist == null)
                return "Role Is not exist !!!";

            roleExist.Name = model.NewName;
            var result = await _roleManager.UpdateAsync(roleExist);

            return result.Succeeded ? "Role has been Edited successfuly" : "somthing went wrong";
        }

        public async Task<string> DeleteRole(AddNewRole model)
        {
            var roleExist = await _roleManager.FindByNameAsync(model.RoleName);

            if (roleExist == null)
                return "Role Is not exist !!!";


            var result = await _roleManager.DeleteAsync(roleExist);

            return result.Succeeded ? "Role has been deleted successfuly" : "somthing went wrong";
        }

        public async Task<List<IdentityRole>> GetAllRoles()
        {
            var roles = await _roleManager.Roles.ToListAsync();
           
            return roles;
        }

       
    }
}
