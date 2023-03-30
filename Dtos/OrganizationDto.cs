namespace CertificateManagement.Dtos
{
    public class OrganizationDto
    {
        public int Id { get; set; }
        public string OrganizationName { get; set; }
        public bool IsApproved { get; set; }
        public string CAC { get; set; }
        public string Logo { get; set; }
        public string OrganizationDescription { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string LocalGovernment { get; set; }
        public string Address { get; set; }
        public string EmailAddress { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
    }
    public class CreateOrganizationRequestModel
    {
        public string OrganizationName { get; set; }
        public IFormFile CAC { get; set; }
        public IFormFile Logo { get; set; }
        public string OrganizationDescription { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string LocalGovernment { get; set; }
        public string Address { get; set; }
        public string EmailAddress { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
    }
    public class UpdateOrganizationRequestModel
    {
        public string OrganizationName { get; set; }
        public IFormFile CAC { get; set; }
        public IFormFile Logo { get; set; }
        public string OrganizationDescription { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string LocalGovernment { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
    }
    public class OrganizationResponseModel : BaseResponse<OrganizationDto>
    {
        public OrganizationDto Data { get; set; }
    }

    public class OrganizationsResponseModels : BaseResponse<OrganizationDto>
    {
        public IEnumerable<OrganizationDto> Data { get; set; }
    }
}
