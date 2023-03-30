namespace CertificateManagement.Dtos
{
    public class CertificateDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Comment { get; set; }
        public DateTime Date { get; set; }
        public string CertificatePreference { get; set; }
        public string Signature { get; set; }
        public string QRCodeText { get; set; }
        public string CertificateCode { get; set; }
    }
    public class CreateCertificateRequestModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Comment { get; set; }
        public DateTime Date { get; set; }
        public string CertificatePreference { get; set; }
        public IFormFile Signature { get; set; }
        public string QRCodeText { get; set; }
        public string CertificateCode { get; set; }
    }
    public class UpdateCertificateRequestModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Comment { get; set; }
        public DateTime Date { get; set; }
        public string CertificatePreference { get; set; }
        public IFormFile Signature { get; set; }
    }
    public class CertificateResponseModel : BaseResponse<CertificateDto>
    {
        public CertificateDto Data { get; set; }
    }

    public class CertificatesResponseModels : BaseResponse<AdminDto>
    {
        public IEnumerable<CertificateDto> Data { get; set; }
    }

}
