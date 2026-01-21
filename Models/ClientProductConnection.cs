namespace DINNO_ERP.Entities
{
    public class ClientProductConnection
    {
        public Guid Id { get; set; }
        public Guid ClientId { get; set; }
        public Guid ProductId { get; set; }
        public string ConnectionString { get; set; }

        public Client Client { get; set; }
        public Product Product { get; set; }
    }
}
