using ScoreYourPointAPI.Domain;

namespace ScoreYourPoint.Dto
{
    public class SportPositionDto
    {
        public SportPositionDto() { }

        public SportPositionDto(SportPosition sportPosition)
        { 
            Id = sportPosition.Id;
            SportId = sportPosition.Id;
            PositionId = sportPosition.PositionId;
            Position = sportPosition.Position;
        }

        public long Id { get; set; }

        public long SportId { get; set; }

        public long PositionId { get; set; }

        public Position Position { get; set; }
    }
}
