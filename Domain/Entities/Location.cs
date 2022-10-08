using System.Collections.Generic;

namespace Domain.Entities
{
    public class Location
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Neighborhood { get; set; }
        public virtual ICollection<Office> Offices { get; set; }

    }

}
