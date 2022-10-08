using AccesData;
using Domain.Entities;
using Logic.Abstractions;
using System.Collections.Generic;

namespace Logic.Infrastructure
{
    public class LocationRepository : ILocationRepository
    {

        private readonly ChallengeContext _context;

        public LocationRepository(ChallengeContext context)
        {
            _context = context;
        }
        public IEnumerable<Location> AsEnumerable()
        {
            return _context.Location;
        }

        public void Add(Location item)
        {
            _context.Location.Add(item);
            _context.SaveChanges();
        }
    }
}