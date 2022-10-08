
using AccesData;
using Domain.Entities;
using Logic.Abstractions;
using System.Collections.Generic;

namespace Logic.Infrastructure
{
    public class ResourceRepository : IResourceRepository
    {
        private readonly ChallengeContext _context;

        public ResourceRepository(ChallengeContext context)
        {
            _context = context;
        }

        public void Add(AvailableResources item)
        {
            _context.AvailableResources.Add(item);
            _context.SaveChanges();
        }

        public IEnumerable<AvailableResources> AsEnumerable()
        {
            return _context.AvailableResources;
        }


    }
}