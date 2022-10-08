using System.Collections.Generic;

namespace Domain.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public virtual ICollection<Booking> Bookings { get; set; }

    }

}
