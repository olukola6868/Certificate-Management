namespace CertificateManagement.Dtos
{
    public class AdminDto
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string EmailAddress { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
    }
    public class CreateAdminRequestModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string EmailAddress { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
    }
    public class UpdateAdminRequestModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
    }
    public class AdminResponseModel : BaseResponse<AdminDto>
    {
        public AdminDto Data { get; set; }
    }

    public class AdminsResponseModels : BaseResponse<AdminDto>
    {
        public IEnumerable<AdminDto> Data { get; set; }
    }
}
