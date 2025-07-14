namespace IncidentManagement.Data.Entities
{
    public class Contact : IEntity
    {
        public Guid Id { get; set; }

        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public Guid AccountId { get; set; }

        public Account Account { get; set; }
    }
}
