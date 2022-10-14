using System.ComponentModel.DataAnnotations;

namespace identityRoleBased.Models.DTO
{
    public class RegistrationModel
    {

        [Required]
        public string Name { get; set; }


        [Required]
        public string UserName { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string ConfirmPassword { get; set; }

        public string? Role { get; set; }




    }
}
