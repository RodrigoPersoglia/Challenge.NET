using Domain.Dto.Input;
using Domain.Utils;
using System;

namespace NetChallenge.Test.Utils
{
    public static class BookOfficeRequestMother
    {
        public static BookOfficeRequest Default => new BookOfficeRequest
        {
            LocationName = AddOfficeRequestMother.Default.LocationName,
            OfficeName = AddOfficeRequestMother.Default.Name,
            CheckIn = new DateTime(2022, 10, 10, 10, 0, 0, DateTimeKind.Utc),
            Duration = new Time(0, 1, 0, 0),
            UserName = "test_user"
        };

        public static BookOfficeRequest WithDate(this BookOfficeRequest request, DateTime dateTime)
        {
            request.CheckIn = dateTime;
            return request;
        }

        public static BookOfficeRequest WithDuration(this BookOfficeRequest request, TimeSpan duration)
        {
            request.Duration = new Time(duration.Days, duration.Hours, duration.Minutes, duration.Seconds);
            return request;
        }

        public static BookOfficeRequest WithOfficeName(this BookOfficeRequest request, string officeName)
        {
            request.OfficeName = officeName;
            return request;
        }

        public static BookOfficeRequest WithLocationName(this BookOfficeRequest request, string locationName)
        {
            request.LocationName = locationName;
            return request;
        }

        public static BookOfficeRequest WithUserName(this BookOfficeRequest request, string userName)
        {
            request.UserName = userName;
            return request;
        }
    }
}