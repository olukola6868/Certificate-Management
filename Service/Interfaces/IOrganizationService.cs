using CertificateManagement.Dtos;

namespace CertificateManagement.Service.Interfaces
{
    public interface IOrganizationService
    {
        Task<BaseResponse<OrganizationDto>> Create(CreateOrganizationRequestModel model);
        Task<OrganizationResponseModel> Get(int id);
        Task<OrganizationsResponseModels> GetAll();
        Task<BaseResponse<OrganizationDto>> Update(UpdateOrganizationRequestModel model, int id);
        public Task<bool> Delete(int id);
    }
}
