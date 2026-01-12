namespace DINNO_ERP.Entities
{
    public class Client
    {
        public Guid Id { get; set; }
        public string CompanyName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string ManagerName { get; set; }
        public bool Status { get; set; }

        public ICollection<ClientProduct> ClientProducts { get; set; }
        public ICollection<ClientProductConnection> Connections { get; set; }
    }
}
