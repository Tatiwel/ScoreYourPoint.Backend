using ScoreYourPointApi.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScoreYourPoint.Dto
{
    public class ProfileRatingRequestDto
    {
        public User User { get; set; }
        public Profile Profile { get; set; }
        public float Rating { get; set; }
        public string? Description { get; set; }
    }
}
