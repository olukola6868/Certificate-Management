using CertificateManagement.Dtos;

namespace CertificateManagement.Service.Interfaces
{
    public interface IAdminService
    {
        Task<BaseResponse<AdminDto>> Create(CreateAdminRequestModel model);
        Task<BaseResponse<AdminDto>> Update(UpdateAdminRequestModel model, int id);
        Task<AdminResponseModel> Get(int id);
        Task<AdminsResponseModels> GetAll();
        public Task<bool> Delete(int id);
    }
}
