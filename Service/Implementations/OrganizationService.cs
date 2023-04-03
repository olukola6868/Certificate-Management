using CertificateManagement.Dtos;
using CertificateManagement.Service.Interfaces;

namespace CertificateManagement.Service.Implementations
{
    public class OrganizationService : IOrganizationService
    {
        public Task<BaseResponse<OrganizationDto>> Create(CreateOrganizationRequestModel model)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<OrganizationResponseModel> Get(int id)
        {
            throw new NotImplementedException();
        }

        public Task<OrganizationsResponseModels> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<BaseResponse<OrganizationDto>> Update(UpdateOrganizationRequestModel model, int id)
        {
            throw new NotImplementedException();
        }
    }
}
