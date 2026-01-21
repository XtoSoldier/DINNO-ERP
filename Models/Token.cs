using System.Security.Cryptography.X509Certificates;

namespace DINNO_ERP.Entities
{
    public class Token
    {
        public Guid Id { get; set; }   // PK + FK → Auth.Id
        public string AccessToken { get; set; }

        public Auth Auth { get; set; }
    }
}
