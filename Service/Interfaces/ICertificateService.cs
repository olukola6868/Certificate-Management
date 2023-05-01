using CertificateManagement.Dtos;

namespace CertificateManagement.Service.Interfaces
{
    public interface ICertificateService
    {
        Task<BaseResponse<CertificateDto>> Create(CreateCertificateRequestModel model);
        public Task<bool> Delete(int id);
        Task<CertificateResponseModel> Get(int id);
        Task<CertificateResponseModel> GetByCode(string CertificateCode);
        Task<CertificatesResponseModels> GetAll();
        Task<BaseResponse<CertificateDto>> Update(UpdateCertificateRequestModel model, int id);
    }
}
