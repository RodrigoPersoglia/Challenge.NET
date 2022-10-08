using System;

namespace Domain.Dto.Output
{
    public class BookingDto
    {
        public string LocationName { get; set; }
        public string OfficeName { get; set; }
        public DateTime CheckIn { get; set; }
        public TimeSpan Duration { get; set; }
        public string UserName { get; set; }
    }

}
