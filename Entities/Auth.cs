namespace DINNO_ERP.Entities
{
    public class Auth
    {
        public Guid Id { get; set; }   // PK + FK → User.Id
        public string Email { get; set; }
        public string Password { get; set; }
        public bool IsGoogle { get; set; }

        public User User { get; set; }
        public Token Token { get; set; }
    }
}
