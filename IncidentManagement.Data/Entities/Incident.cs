namespace IncidentManagement.Data.Entities
{
    public class Incident : IEntity
    {
        public string Name { get; set; }
        public string Description { get; set; } = string.Empty;

        public ICollection<Account> Accounts { get; set; }
    }
}