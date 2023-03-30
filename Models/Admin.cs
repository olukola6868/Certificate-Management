namespace CertificateManagement.Models
{
    public class Admin : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
    }
}
