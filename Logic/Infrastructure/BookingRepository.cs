
using AccesData;
using Domain.Entities;
using Logic.Abstractions;
using System.Collections.Generic;

namespace Logic.Infrastructure
{
    public class BookingRepository : IBookingRepository
    {

        private readonly ChallengeContext _context;

        public BookingRepository(ChallengeContext context)
        {
            _context = context;
        }
        public IEnumerable<Booking> AsEnumerable()
        {
            return _context.Booking;
        }

        public void Add(Booking item)
        {
            _context.Booking.Add(item);
            _context.SaveChanges();
        }
    }
}