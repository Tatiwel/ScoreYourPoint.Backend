using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using ScoreYourPointApi.Domain;

namespace ScoreYourPoint.Dto
{
    public class UserRequestDto
    {

        [Required(ErrorMessage = $"{nameof(Email)} field is required")]
        [DisplayName("User e-mail")]
        [Description("Demonstrates an E-mail field for user authentication and security purposes")]
        [DataType(DataType.EmailAddress)]
        [EmailAddress(ErrorMessage = "Invalid Email Adress")]
        public string Email { get; set; }

        [Required(ErrorMessage = $"{nameof(Password)} field is required")]
        [DisplayName("User password")]
        [Description("Demonstrates a password field for user authentication and security purposes")]
        [DataType(DataType.Password)]
        [MinLength(1, ErrorMessage = "This field must contains a length between 6 and 18 characters")]
        [MaxLength(18, ErrorMessage = "This field must contains a length between 6 and 18 characters")]
        public string Password { get; set; }

        [DisplayName("User active status")]
        [Description("Demonstrates a flag field to check if an user is active or not")]
        [DefaultValue(false)]
        public bool IsActive { get; set; }

    }
}
