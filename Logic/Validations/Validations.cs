using Domain.Entities;
using Domain.Exceptions;
using Logic.Abstractions;
using System;
using System.Linq;

namespace Logic.Validations
{
    public class Validation
    {
        private readonly ILocationRepository _locationRepository;
        private readonly IOfficeRepository _officeRepository;


        public Validation(ILocationRepository locationRepository, IOfficeRepository officeRepository)
        {
            _locationRepository = locationRepository;
            _officeRepository = officeRepository;
        }

        public Location GetLocation(string locationName)
        {
            var location = _locationRepository.AsEnumerable().Where(c => c.Name == locationName).FirstOrDefault();
            if (location is null) { throw new NotExistsLocationExceptions(); }
            return location;
        }

        public Office GetOffice(string officeName, string locationName)
        {
            var office = _officeRepository.AsEnumerable().Where(c => c.Name == officeName &&
             c.LocationId == _locationRepository.AsEnumerable().Where(c => c.Name == GetLocation(locationName).Name).FirstOrDefault().Id
             ).FirstOrDefault();
            if (office is null) { throw new NotExistsOfficeExceptions(); }
            return office;
        }


        public bool CheckAvailableResources(string[] resources, string[] availableResources)
        {
            foreach (var item in resources)
            {
                if (!availableResources.Contains(item)) { return false; }
            }

            return true;
        }

        public bool CheckAvailability(DateTime checkIn, TimeSpan duration, DateTime book, TimeSpan bookDuration)
        {
            if (checkIn.Add(duration) <= book) { return true; }

            if (checkIn >= book.Add(bookDuration)) { return true; }

            return false;
        }
    }
}
