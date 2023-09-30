using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScoreYourPoint.Dto
{
    public class PositionRequestDto
    {
        [Description("Demonstrates the position name in the system")]
        [MinLength(3, ErrorMessage = "This field must contains a length between 3 and 60 characters")]
        [MaxLength(60, ErrorMessage = "This field must contains a length between 3 and 60 characters")]
        [DefaultValue("Empty position name")]
        public string? Name { get; set; }
    }
}
