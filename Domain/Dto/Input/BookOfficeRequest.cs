using Domain.Utils;
using System;

namespace Domain.Dto.Input
{
    public class BookOfficeRequest
    {
        public string LocationName { get; set; }
        public string OfficeName { get; set; }
        public DateTime CheckIn { get; set; }
        public Time Duration { get; set; }
        public string UserName { get; set; }
    }

}
