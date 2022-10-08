
using AccesData;
using Domain.Entities;
using Logic.Abstractions;
using System.Collections.Generic;

namespace Logic.Infrastructure
{
    public class UserRepository : IUserRepository
    {
        private readonly ChallengeContext _context;

        public UserRepository(ChallengeContext context)
        {
            _context = context;
        }

        public void Add(User item)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<User> AsEnumerable()
        {
            return _context.User;
        }


    }
}