namespace CertificateManagement.Models
{
    public class Role : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public IList<UserRole> UserRoles { get; set; }
    }
}
