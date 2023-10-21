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
        public long UserId { get; set; }
        public long ProfileId { get; set; }
        public float Rating { get; set; }
        public string? Description { get; set; }
    }
}
