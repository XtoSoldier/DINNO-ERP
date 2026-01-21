namespace DINNO_ERP.Entities
{
    public class Module
    {
        public Guid Id { get; set; }
        public Guid ProductId { get; set; }
        public string Type { get; set; }
        public string Description { get; set; }
        public bool Status { get; set; }

        public Product Product { get; set; }
        public ICollection<ClientModule> ClientModules { get; set; }
    }
}
