using identityRoleBased.Models.Domain;
using identityRoleBased.Models.DTO;
using identityRoleBased.Repositories.Abstract;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using IdentityRole = Microsoft.AspNetCore.Identity.IdentityRole;

namespace identityRoleBased.Repositories.Implementation
{
    public class UserAuthenticationService : IUserAuthenticationService
    {
        private readonly SignInManager<ApplicationUser> signInManager;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly RoleManager<IdentityRole> roleManager;

        public UserAuthenticationService(SignInManager<ApplicationUser> signInManager, UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
                this.roleManager = roleManager;
                this.userManager = userManager;
                this.signInManager = signInManager;
        }
        public async Task<Status> LoginAsync(LoginModel model)
        {
            var status = new Status();
            var user= await userManager.FindByNameAsync(model.UserName);
            if (user == null)
            {
                status.StatusCode = 0;
                status.Message = "User does not exist";
                return status;
            }
            if(!await userManager.CheckPasswordAsync(user, model.Password))
            {
                status.StatusCode = 0;
                status.Message = "Invalid Password";
                return status;
            }

            var signinResult = await signInManager.PasswordSignInAsync(user, model.Password, false, true);
            if(signinResult.Succeeded)
            {
                var userRoles = await userManager.GetRolesAsync(user);
                var authClaims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, user.Email)
                };
                foreach(var userRole in userRoles)
                {
                    authClaims.Add(new Claim(ClaimTypes.Role, userRole));
                }
                status.StatusCode = 1;
                status.Message = "Loggedin Successfully";
                status.UserId = user.Id;
                return status;
            }
            else if(signinResult.IsLockedOut){
                status.StatusCode = 0;
                status.Message = "Invalid login";
                return status;
            }
            else
            {
                status.StatusCode = 0;
                status.Message = "Error in login";
                return status;
            }
        }

        public async Task LogoutAsync()
        {
            await signInManager.SignOutAsync();
        }

        public async Task<Status> RegistrationAsync(RegistrationModel model)
        {
            var status = new Status();
            var userExist = await userManager.FindByNameAsync(model.UserName);
            if(userExist != null)
            {
                status.StatusCode = 0;
                status.Message = "User Already exist";
                return status;
            }

            ApplicationUser user = new ApplicationUser()
            {
                SecurityStamp = Guid.NewGuid().ToString(),
                Email = model.Email,
                Name = model.Name,
                UserName = model.UserName,
                EmailConfirmed = true,

            };

            var result =await userManager.CreateAsync(user, model.Password);

            if (!result.Succeeded)
            {
                status.StatusCode = 0;
                status.Message = "Creation failed";
                return status;
            }

            // role management 

            if(!await roleManager.RoleExistsAsync(model.Role))
            {
                await roleManager.CreateAsync(new IdentityRole(model.Role));
            }

            if (await roleManager.RoleExistsAsync(model.Role))
            {
                await userManager.AddToRoleAsync(user,model.Role);
            }

            status.StatusCode = 1;
            status.Message = "User has registered successfully";
            return status;
        }
    }
}
