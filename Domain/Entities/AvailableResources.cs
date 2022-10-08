namespace Domain.Entities
{
    public class AvailableResources
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public int OfficeId { get; set; }
        public virtual Office Offices { get; set; }

    }
}
