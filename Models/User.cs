namespace CertificateManagement.Models
{
    public class User : BaseEntity
    {
        public string Address { get; set; }
        public string EmailAddress { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
        public IList<UserRole> UserRoles { get; set; } = new List<UserRole>();
        public Admin Admin { get; set; }
        public Organization Organization { get; set; }
    }
}
