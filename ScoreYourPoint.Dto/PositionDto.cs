using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace ScoreYourPoint.Dto
{
    public class PositionDto
    {

        [Key]
        [Description("Demonstrates the position unique identification (ID) in the system")]
        [Range(1, long.MaxValue, ErrorMessage = "Invalid position")]
        public long Id { get; set; }

        [Description("Demonstrates the position name in the system")]
        [MinLength(3, ErrorMessage = "This field must contains a length between 3 and 60 characters")]
        [MaxLength(60, ErrorMessage = "This field must contains a length between 3 and 60 characters")]
        [DefaultValue("Empty position name")]
        public string? Name { get; set; }

    }
}
