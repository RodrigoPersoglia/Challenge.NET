using AutoMapper;
using Domain.Dto.Input;
using Domain.Dto.Output;
using Domain.Entities;
using Domain.Exceptions;
using Logic.Abstractions;
using Logic.Validations;
using System.Collections.Generic;
using System.Linq;

namespace Logic
{
    public class OfficeRentalService
    {
        private readonly ILocationRepository _locationRepository;
        private readonly IOfficeRepository _officeRepository;
        private readonly IBookingRepository _bookingRepository;
        private readonly IResourceRepository _resourceRepository;
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly Validation _validation;


        public OfficeRentalService(ILocationRepository locationRepository, IOfficeRepository officeRepository, IBookingRepository bookingRepository, IMapper mapper, IResourceRepository resourceRepository, IUserRepository userRepository, Validation validation)
        {
            _locationRepository = locationRepository;
            _officeRepository = officeRepository;
            _bookingRepository = bookingRepository;
            _resourceRepository = resourceRepository;
            _userRepository = userRepository;
            _mapper = mapper;
            _validation = validation;
        }


        public void AddLocation(AddLocationRequest request)
        {
            if (string.IsNullOrEmpty(request.Name) || string.IsNullOrEmpty(request.Neighborhood))
            {
                throw new EmptyFieldException();
            }

            var location = _locationRepository.AsEnumerable().Where(c => c.Name == request.Name).FirstOrDefault();
            if (location != null)
            {
                throw new ExistsExceptions();
            }

            _locationRepository.Add(_mapper.Map<Location>(request));
        }


        public void AddOffice(AddOfficeRequest request)
        {
            if (string.IsNullOrEmpty(request.Name) || string.IsNullOrEmpty(request.LocationName))
            {
                throw new EmptyFieldException();
            }

            if (request.MaxCapacity < 1)
            {
                throw new ZeroCapacityException();
            }

            var location = _validation.GetLocation(request.LocationName);

            if (_officeRepository.AsEnumerable().Where(o => o.LocationId == location.Id && o.Name == request.Name).FirstOrDefault() != null)
            {
                throw new ExistsOfficeExceptions();
            }

            var office = _mapper.Map<Office>(request);
            office.LocationId = location.Id;

            _officeRepository.Add(office);

            foreach (var item in request.AvailableResources)
            {
                if (!string.IsNullOrEmpty(item))
                {
                    _resourceRepository.Add(new AvailableResources() { Description = item, OfficeId = office.Id });
                }
            }
        }


        public void BookOffice(BookOfficeRequest request)
        {

            var user = _userRepository.AsEnumerable().Where(c => c.UserName == request.UserName).FirstOrDefault();
            if (user == null) { throw new NotExistsUserExceptions(); }
            var office = _validation.GetOffice(request.OfficeName, request.LocationName);
            var list = _bookingRepository.AsEnumerable().Where(book => !_validation.CheckAvailability(request.CheckIn, request.Duration.ToTimeSpan(), book.CheckIn, book.Duration)).ToList();

            if (list.Count > 0) { throw new ReservedException(); }

            var booking = new Booking()
            {
                OfficeId = office.Id,
                UserId = user.Id,
                Duration = request.Duration.ToTimeSpan(),
                CheckIn = request.CheckIn
            };

            _bookingRepository.Add(booking);

        }

        public IEnumerable<BookingDto> GetBookings(string locationName, string officeName)
        {
            var location = _validation.GetLocation(locationName);
            var office = _validation.GetOffice(officeName, locationName);

            return (from b in _bookingRepository.AsEnumerable()
                    join u in _userRepository.AsEnumerable() on b.UserId equals u.Id
                    where b.OfficeId == office.Id
                    select new BookingDto()
                    {
                        LocationName = location.Name,
                        OfficeName = office.Name,
                        Duration = b.Duration,
                        CheckIn = b.CheckIn,
                        UserName = u.UserName
                    }).ToList();
        }


        public IEnumerable<LocationDto> GetLocations()
        {
            return _mapper.Map<List<LocationDto>>(_locationRepository.AsEnumerable());
        }


        public IEnumerable<OfficeDto> GetOffices(string locationName)
        {
            var location = _validation.GetLocation(locationName);
            var list = (from o in _officeRepository.AsEnumerable()
                        where o.LocationId == _validation.GetLocation(locationName).Id
                        select new OfficeDto()
                        {
                            Name = o.Name,
                            MaxCapacity = o.MaxCapacity,
                            LocationName = location.Name,
                            AvailableResources = _resourceRepository.AsEnumerable().Where(r => r.OfficeId == o.Id).Select(m => m.Description).ToArray()
                        }).ToList();

            return list;
        }

        public IEnumerable<OfficeDto> GetOfficeSuggestions(SuggestionsRequest request)
        {
            if (request.CapacityNeeded < 1)
            {
                throw new ZeroCapacityException();
            }
            return (from office in _officeRepository.AsEnumerable()
                    where office.MaxCapacity >= request.CapacityNeeded && _validation.CheckAvailableResources(request.ResourcesNeeded.ToArray(), office.Resources.Select(x => x.Description).ToArray())
                    orderby (office.Location.Neighborhood != request.PreferedNeigborHood, office.MaxCapacity, office.Resources.Count()), office.MaxCapacity, office.Resources.Count()
                    select new OfficeDto()
                    {
                        Name = office.Name,
                        LocationName = office.Location.Name,
                        MaxCapacity = office.MaxCapacity,
                        AvailableResources = office.Resources.Select(x => x.Description).ToArray()
                    }).ToList();
        }


    }
}