using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Diagnostics.Tracing;
using ScoreYourPointApi.Domain;
using ScoreYourPointApi.Domain.Enums;

namespace ScoreYourPoint.Dto
{
    public class EventDto
    {
        public EventDto() { }

        public EventDto(Event event_)
        {
            Id = event_.Id;
            UserId = event_.UserId;
            Title = event_.Title;
            Description = event_.Description;
            ParticipantsAmount = event_.ParticipantsAmount;
            IsPublic = event_.IsPublic;
            Photo = event_.Photo;
            StartDateTime = event_.StartDateTime;
            EndDateTime = event_.EndDateTime;
            Status = event_.Status;
            Type = event_.Type;
            Street = event_.Street;
            ZipCode = event_.ZipCode;
            Neighbor = event_.Neighbor;
            Complement = event_.Complement;
        }

        public long Id { get; set; }
        public long UserId { get; set; }
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
}
