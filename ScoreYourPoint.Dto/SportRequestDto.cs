using ScoreYourPointAPI.Domain;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace ScoreYourPoint.Dto
{
    public class SportRequestDto
    {

        public SportRequestDto() { }

        public SportRequestDto(Sport sport) { 

            Name = sport.Name;
        }
        public long Id { get; set; }

        public string? Name { get; set; }

    }
}
