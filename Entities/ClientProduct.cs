namespace DINNO_ERP.Entities
{
    public class ClientProduct
    {
        public Guid Id { get; set; }
        public Guid ClientId { get; set; }
        public Guid ProductId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool Status { get; set; }

        public Client Client { get; set; }
        public Product Product { get; set; }
        public ICollection<ClientModule> ClientModules { get; set; }
    }
}
