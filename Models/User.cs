namespace DINNO_ERP.Entities
{
    public class User
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Image { get; set; }
        public string Role { get; set; }
        public bool Status { get; set; }

        public Auth Auth { get; set; }
    }
}
