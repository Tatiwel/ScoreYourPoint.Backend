using ScoreYourPointApi.Domain;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ScoreYourPoint.Dto
{
    public class ProfileDto
    {


        // Constructor methods

        /*
         * Required class constructor to initialize new objects
         */
        public ProfileDto() { }

        public ProfileDto(Profile profile)
        { 
            Id = profile.Id;
            Name = profile.Name ?? throw new ArgumentNullException(nameof(profile.Name));
            Gender = profile.Gender;
            Age = profile.Age;
            LeftOrRight = profile.LeftOrRight;
            Height = profile.Height;
            Weight = profile.Weight;
        }


        [Key]
        [DisplayName("User profile ID")]
        [Description("Demonstrates the profile unique identification (ID) in the system")]
        [Range(1, long.MaxValue, ErrorMessage = "Invalid profile")]
        public long Id { get; set; }

        public long UserId { get; set; }

        public User User { get; set; }

        [DisplayName("User profile name")]
        [Required(ErrorMessage = $"{nameof(Name)} field is required")]
        [Description("Demonstrates the user profile name in the system")]
        [MinLength(3, ErrorMessage = "This field must contains a length between 3 and 60 characters")]
        [MaxLength(60, ErrorMessage = "This field must contains a length between 3 and 60 characters")]
        [DefaultValue("Default guest")]
        public string Name { get; set; }

        [DisplayName("User profile gender")]
        [Required(ErrorMessage = $"{nameof(Gender)} field is required")]
        [Description("Demonstrates the profile user gender in the system")]
        [RegularExpression("M|F", ErrorMessage = "This field must contains only chars and values for Gender as:\n'M' for Male\n'F' for Female")] // Allows only 'M' for Male or 'F' for Female.
        [DefaultValue("M")]
        public char Gender { get; set; }

        [DisplayName("User profile age")]
        [Required(ErrorMessage = $"{nameof(Age)} field is required")]
        [Description("Demonstrates the user profile age in the system")]
        public int Age { get; set; }

        [DisplayName("User profile leg side preferency")]
        [Required(ErrorMessage = $"{nameof(LeftOrRight)} field is required")]
        [Description("Demonstrates the user profile leg side preferency in the system")]
        [RegularExpression("R|L", ErrorMessage = "This field must contains only chars and values for Gender as:\n'R' for Right\n'L' for Left")]
        [DefaultValue("R")]
        public char LeftOrRight { get; set; }

        [DisplayName("User profile height")]
        [Description("Demonstrates the user profile height in the system")]
        public float? Height { get; set; }

        [DisplayName("User profile weight")]
        [Description("Demonstrates the user profile weight in the system")]
        public float? Weight { get; set; }
    }
}
