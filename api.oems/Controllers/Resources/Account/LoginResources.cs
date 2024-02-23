using System.ComponentModel.DataAnnotations;

namespace api.oems.Controllers.Resources.Account
{
    public class LoginResources
    {
        [Required(ErrorMessage = "Please enter your Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please enter your Password")]
        public string Password { get; set; }
    }
}
