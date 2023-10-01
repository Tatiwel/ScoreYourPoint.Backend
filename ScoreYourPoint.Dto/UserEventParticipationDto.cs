using ScoreYourPointAPI.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScoreYourPoint.Dto
{
    public class UserEventParticipationDto
    {
        public UserEventParticipationDto()
        {
        }

        public UserEventParticipationDto(UserEventParticipation user)
        {
            Id = user.Id;
            Team = user.Team;
            UserId = user.UserId;
            SportPositionId = user.SportPositionId;
            EventId = user.EventId;
        }

        public long Id { get; set; }
        public char Team { get; set; }
        public long UserId { get; set; }
        public long? SportPositionId { get; set; }
        public long EventId { get; set; }
    }
}
