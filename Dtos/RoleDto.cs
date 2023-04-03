namespace CertificateManagement.Dtos
{
    public class RoleDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public IList<UserDto> Users { get; set; }
    }
    public class CreateRoleRequestModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
    public class UpdateRoleRequestModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
    public class RoleResponseModel : BaseResponse<RoleDto>
    {
        public RoleDto Data { get; set; }
    }

    public class RolesResponseModels : BaseResponse<RoleDto>
    {
        public IEnumerable<RoleDto> Data { get; set; }
    }
}
