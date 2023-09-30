using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScoreYourPoint.Dto
{
    public class UserEventParticipationRequestDto
    {
        public char Team { get; set; }
        public long UserId { get; set; }
        public long SportPositionId { get; set; }
        public long EventId { get; set; }
    }
}
