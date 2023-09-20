using ScoreYourPointApi.Domain.Enums;

namespace ScoreYourPointApi.Domain;

public class Event
{

    public long Id { get; set; }

    public long UserId { get; set; }

    public User User { get; set; }

    public string Title { get; set; }

    public string? Description { get; set; }

    public sbyte ParticipantsAmount { get; set; }

    public bool IsPublic { get; set; }

    public string? Photo { get; set; }

    public DateTime StartDateTime { get; set; }

    public DateTime EndDateTime { get; set; }

    public string Status { get; set; }

    public EventTypeEnum Type { get; set; }

    public string Street { get; set; }

    public string ZipCode { get; set; }

    public string Neighbor { get; set; }

    public string Complement { get; set; }
}