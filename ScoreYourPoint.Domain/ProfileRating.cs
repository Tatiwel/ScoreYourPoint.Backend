namespace ScoreYourPointApi.Domain;

public class ProfileRating
{

    public long Id { get; set; }

    public long UserId { get; set; }

    public User User { get; set; }

    public long ProfileId { get; set; }

    public Profile Profile { get; set; }

    public float Rate { get; set; }

    public string Description { get; set; }

}
