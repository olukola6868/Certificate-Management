using CertificateManagement.Dtos;

namespace CertificateManagement.Service.Interfaces
{
    public interface ICertificateService
    {
        Task<BaseResponse<CertificateDto>> Create(CreateCertificateRequestModel model);
        Task<CertificateResponseModel> Get(int id);
        Task<CertificatesResponseModels> GetAll();
        Task<BaseResponse<CertificateDto>> Update(UpdateCertificateRequestModel model);
        public Task<bool> Delete(int id);
    }
}
