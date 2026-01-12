namespace DINNO_ERP.Entities
{
    public class ClientModule
    {
        public Guid Id { get; set; }
        public Guid ClientProductId { get; set; }
        public Guid ModuleId { get; set; }
        public bool Status { get; set; }

        public ClientProduct ClientProduct { get; set; }
        public Module Module { get; set; }
    }
}
