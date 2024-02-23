using System.ComponentModel.DataAnnotations;

namespace api.oems.Controllers.Resources.Account
{
    public class RegisterResources
    {
        [Required(ErrorMessage = "Please enter First Name.")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Please enter Last Name")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Please enter your Email")]
        [DataType(DataType.EmailAddress)]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please enter your Phone Number")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Please enter Password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Please Re-Enter Password")]
        [DataType(DataType.Password)]
        [Compare("Password",ErrorMessage = "Password and Re-entered Password does not match.")]
        public string ReTypedPassword { get; set; }
    }
}
