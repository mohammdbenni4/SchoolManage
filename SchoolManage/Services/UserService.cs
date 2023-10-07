using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using SchoolManage.Helpers;
using SchoolManage.Models;

namespace SchoolManage.Services
{
    public class UserService : IUserService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IWebHostEnvironment _hostEnvironment;
        private readonly ApplicationDbContext _context;
        public UserService(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager
            , IWebHostEnvironment hostEnvironment , ApplicationDbContext context)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _hostEnvironment = hostEnvironment;
            _context = context; 
        }
        public async Task<string> AddToRoleAsync(AddToRoleModel model)
        {
            var user = await _userManager.FindByEmailAsync(model.UserEmail);
            var roleExist = await _roleManager.RoleExistsAsync(model.RoleName);



            if (user == null || !roleExist)
            {
                return "Invalid User Email or role name";
            }

            if (await _userManager.IsInRoleAsync(user, model.RoleName))
            {
                return "User Is alredy In This Role";
            }


            var result = await _userManager.AddToRoleAsync(user, model.RoleName);
            return result.Succeeded ? string.Empty : "somthing went wrong";
        }

        public async Task<string> RemoveFromRole(AddToRoleModel model)
        {
            var user = await _userManager.FindByEmailAsync(model.UserEmail);

            if (user == null || !await _userManager.IsInRoleAsync(user, model.RoleName))
                return "user not found or he is already not in this role !!";

            
            var result = await _userManager.RemoveFromRoleAsync(user, model.RoleName);

            return result.Succeeded ? "user has removed from this role successfuly " : "something went wrong";

        }

        public async Task<UserInfo> GetUserInfo(SearchUserByEmail model)
        {
            var user = await _userManager.FindByEmailAsync(model.Email);

            if(user == null)
                return new UserInfo {Massage = "No User found With this Email !" };

            var myUser = new UserInfo
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                Roles = _userManager.GetRolesAsync(user).Result
                
            };

            return myUser;
        }

        public async Task<UserEditProfile> EditMyProfile(UserEditProfile model)
        {
            var user = await _userManager.FindByEmailAsync(model.Email);

            if (user == null || !await _userManager.CheckPasswordAsync(user,model.Password))
            {
                return new UserEditProfile {Massage = "Email Or Password Is Incorrect " };
            }
            if(model.NewFirstName!=null)user.FirstName= model.NewFirstName;
            if(model.NewLastName != null)user.LastName= model.NewLastName;
            if(model.NewEmail!=null)user.Email= model.NewEmail;

            if(model.NewProfilePicFile!=null)
            {
                var wwwrootPath = _hostEnvironment.WebRootPath;
                var fileName=string.Empty;
                var p = string.Empty;
                if (user.ProfilePicPath != "no photo") 
                {
                    fileName = user.ProfilePicPath;
                    p = Path.Combine(wwwrootPath, "Images",fileName);
                    if(System.IO.File.Exists(p))
                    {
                        System.IO.File.Delete(p);
                    }
                }
                var extn = Path.GetExtension(model.NewProfilePicFile.FileName);

                if (extn != ".png" && extn != ".jpg")
                {
                    return new UserEditProfile { Massage = "only jpg and png photos allowed " };
                }
                

                fileName = Guid.NewGuid() + "_" + model.NewProfilePicFile.FileName;
                p = Path.Combine(wwwrootPath,"Images",fileName);
                using (var fileSteam = new FileStream(p,FileMode.Create))
                {
                    model.NewProfilePicFile.CopyTo(fileSteam);
                }

                user.ProfilePicPath = fileName;

            }
            var result = await _userManager.UpdateAsync(user);

            if (!result.Succeeded)
                return new UserEditProfile { Massage = "somthing went wrong"};

            return model;
        }

        public async Task<string> GetUsersByRoleName(SearchRoleByName model)
        {
            var role = await _roleManager.FindByNameAsync(model.RoleName);
            if (role == null)
                return "somthing went wrong";

            var users = await _userManager.GetUsersInRoleAsync(model.RoleName);

            if (users == null)
                return "somthing went wrong";

            string user = string.Empty;
            foreach(var u in users)
                user += u.Email+" , ";

            return user;
        }

        public async Task<string> DelUser(SearchUserByEmail model)
        {
            var user = await _userManager.FindByEmailAsync(model.Email);

            if (user == null)
            {
                return "Email  Is Incorrect "; 
            }
           

            var result = await _userManager.DeleteAsync(user);
            if (!result.Succeeded)
            {
                return "somthing went wrong";
            }

            return "user deleted succsessfuly !";
        }
    }
}
 