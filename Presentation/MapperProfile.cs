using AutoMapper;
using Domain.Dto.Input;
using Domain.Dto.Output;
using Domain.Entities;


namespace Presentation
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<Location, LocationDto>();
            CreateMap<LocationDto, Location>();
            CreateMap<AddLocationRequest, Location>();

            CreateMap<Office, OfficeDto>();
            CreateMap<OfficeDto, Office>();
            CreateMap<AddOfficeRequest, Office>();
            CreateMap<Office, AddOfficeRequest>();

            CreateMap<AddOfficeRequest, Office>();
            CreateMap<AddOfficeRequest, Office>();

            CreateMap<BookingDto, Booking>();
            CreateMap<Booking, BookingDto>();
            CreateMap<BookOfficeRequest, Booking>();
            CreateMap<Booking, BookOfficeRequest>();

        }
    }
}
