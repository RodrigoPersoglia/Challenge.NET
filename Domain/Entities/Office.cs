using System.Collections.Generic;

namespace Domain.Entities
{
    public class Office
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int MaxCapacity { get; set; }
        public int LocationId { get; set; }
        public virtual Location Location { get; set; }
        public virtual ICollection<AvailableResources> Resources { get; set; }
        public virtual ICollection<Booking> Bookings { get; set; }

    }

}
