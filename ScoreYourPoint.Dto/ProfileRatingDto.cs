using ScoreYourPointApi.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ScoreYourPointAPI.Domain;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace ScoreYourPoint.Dto
{
    public class ProfileRatingDto
    {
        public ProfileRatingDto()
        {
        }
        public ProfileRatingDto(ProfileRating profileRating)
        {
            Id = profileRating.Id;
            UserId = profileRating.UserId;
            User user = profileRating.User;
            ProfileId = profileRating.ProfileId;
            Profile profile = profileRating.Profile;
            Rating = profileRating.Rating;
            Description = profileRating.Description;
        }
        public long Id { get; set; }
        public long UserId { get; set; }
        public User User { get; set; }
        public long ProfileId { get; set; }
        public Profile Profile { get; set; }
        public float Rating { get; set; }
        public string? Description { get; set; }
    }   
}