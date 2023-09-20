using ScoreYourPointApi.Domain;

namespace ScoreYourPointAPI.Domain;

public class UserEventParticipation
{

    public long Id { get; set; }

    public char Team { get; set; }

    public long UserId { get; set; }

    public long? SportPositionId { get; set; }

    public SportPosition? SportPosition { get; set; }

    public User User { get; set; }

    public long EventId { get; set; }

    public Event Event { get; set; }

}