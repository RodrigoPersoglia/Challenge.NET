using AccesData;
using Domain.Entities;
using Logic.Abstractions;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Logic.Infrastructure
{
    public class OfficeRepository : IOfficeRepository
    {

        private readonly ChallengeContext _context;

        public OfficeRepository(ChallengeContext context)
        {
            _context = context;
        }
        public IEnumerable<Office> AsEnumerable()
        {
            return _context.Office.Include("Resources").Include("Location");
        }

        public void Add(Office item)
        {
            _context.Office.Add(item);
            _context.SaveChanges();
        }
    }
}