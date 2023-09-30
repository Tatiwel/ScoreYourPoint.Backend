using ScoreYourPointAPI.Domain;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace ScoreYourPoint.Dto
{
    public class SportDto
    {

        public SportDto() { }

        public SportDto(Sport sport) { 
            Id = sport.Id;
            Name = sport.Name;
        }

        public SportDto(int id, string name) {
            Id = id;
            Name = name;
        }

        public long Id { get; set; }

        public string? Name { get; set; }

    }
}
