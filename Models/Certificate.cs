namespace CertificateManagement.Models
{
    public class Certificate : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Comment { get; set; }
        public DateTime Date { get; set; }
        public string CertificatePreference { get; set; }
        public string Signature { get; set; }
        public string? QRCodeText { get; set; }
        public string CertificateCode { get; set; }
        public int OrganizationId { get; set; }
        public Organization Organization { get; set; }
    }
}
