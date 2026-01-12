namespace DINNO_ERP.Entities
{
    public class Product
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool Status { get; set; }

        public ICollection<Module> Modules { get; set; }
        public ICollection<ClientProduct> ClientProducts { get; set; }
    }
}
