namespace CertificateManagement.Models
{
    public class Organization : BaseEntity
    {
        public string OrganizationName { get; set; }
        public bool IsApproved { get; set; }
        public string CAC { get; set; }
        public string Logo { get; set; }
        public string OrganizationDescription { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string LocalGovernment { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public IList<Certificate> Certificates { get; set; }
    }
}
