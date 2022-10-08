using System;

namespace Domain.Entities
{
    public class Booking
    {
        public int Id { get; set; }
        public DateTime CheckIn { get; set; }
        public TimeSpan Duration { get; set; }
        public int OfficeId { get; set; }
        public int UserId { get; set; }
        public Office Office { get; set; }
        public User User { get; set; }

    }

}
