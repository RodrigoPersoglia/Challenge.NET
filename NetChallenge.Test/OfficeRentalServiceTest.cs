using AccesData;
using AutoMapper;
using Logic;
using Logic.Abstractions;
using Logic.Infrastructure;
using Logic.Validations;

namespace NetChallenge.Test
{
    public class OfficeRentalServiceTest
    {
        protected OfficeRentalService Service;
        protected ILocationRepository LocationRepository;
        protected IOfficeRepository OfficeRepository;
        protected IBookingRepository BookingRepository;
        protected IResourceRepository ResourceRepository;
        protected IUserRepository UserRepository;
        protected ChallengeContext Context;
        protected Validation Validation;
        protected IMapper Mapper;

        public OfficeRentalServiceTest(ILocationRepository locationRepository, IOfficeRepository officeRepository, IBookingRepository bookingRepository, IMapper mapper, IResourceRepository resourceRepository, IUserRepository userRepository)
        {
            LocationRepository = locationRepository;
            OfficeRepository = officeRepository;
            BookingRepository = bookingRepository;
            Mapper = mapper;
            ResourceRepository = resourceRepository;
            UserRepository = userRepository;
        }

        public OfficeRentalServiceTest(ILocationRepository locationRepository, IOfficeRepository officeRepository, IBookingRepository bookingRepository, IMapper mapper, IResourceRepository resourceRepository, IUserRepository userRepository, ChallengeContext context, Validation validation)
        {
            LocationRepository = locationRepository;
            OfficeRepository = officeRepository;
            BookingRepository = bookingRepository;
            ResourceRepository = resourceRepository;
            UserRepository = userRepository;
            Context = context;
            Validation = validation;
            Mapper = mapper;



            BookingRepository = new BookingRepository(Context);
            Service = new OfficeRentalService(LocationRepository, OfficeRepository, BookingRepository, Mapper, ResourceRepository, UserRepository, Validation);
        }
    }
}