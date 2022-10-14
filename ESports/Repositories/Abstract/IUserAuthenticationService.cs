using identityRoleBased.Models.DTO;
//using Microsoft.AspNetCore.Identity.UI.V4.Pages.Account.Internal;

namespace identityRoleBased.Repositories.Abstract
{
    public interface IUserAuthenticationService
    {
        Task<Status> LoginAsync(LoginModel model);
        Task<Status> RegistrationAsync(RegistrationModel model);
        Task LogoutAsync();

    }
}
