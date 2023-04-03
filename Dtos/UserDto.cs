namespace CertificateManagement.Dtos
{
    public class UserDto
    {
        public int Id { get; set; }
        public string Address { get; set; }
        public string EmailAddress { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
        public IList<RoleDto> Roles { get; set; } = new List<RoleDto>();
    }
    public class CreateUserRequestModel
    {
        public string Address { get; set; }
        public string EmailAddress { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
    }
    public class LoginUserRequestModel
    {
        public string EmailAddress { get; set; }
        public string Password { get; set; }
        public IList<RoleDto> Roles { get; set; } = new List<RoleDto>();
    }
    public class UserResponseModel : BaseResponse<UserDto>
    {
        public UserDto Data { get; set; }
    }

    public class UsersResponseModels : BaseResponse<UserDto>
    {
        public IEnumerable<UserDto> Data { get; set; }
    }
}
