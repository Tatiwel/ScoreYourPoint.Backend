using ScoreYourPointAPI.Domain;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace ScoreYourPoint.Dto
{
    public class SportDto
    {

        public SportDto() { }

        public SportDto(Sport sport) { 
            Id = sport.Id;
            Name = sport.Name;
        }

        public SportDto(int id, string name) {
            Id = id;
            Name = name;
        }

        [Key]
        [Description("Demonstrates the sport unique identification (ID) in the system")]
        [Range(1, long.MaxValue, ErrorMessage = "Invalid sport")]
        public long Id { get; set; }

        [Description("Demonstrates the sport name in the system")]
        [MinLength(3, ErrorMessage = "This field must contains a length between 3 and 60 characters")]
        [MaxLength(60, ErrorMessage = "This field must contains a length between 3 and 60 characters")]
        [DefaultValue("Empty sport name")]
        public string? Name { get; set; }

    }
}
