using CertificateManagement.Dtos;

namespace CertificateManagement.Service.Interfaces
{
    public interface IUserService
    {
        public Task<UserResponseModel> Get(int id);
        public Task<UsersResponseModels> GetAll();
        public Task<BaseResponse<UserDto>> Login(LoginUserRequestModel model);
    }
}
