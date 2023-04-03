using CertificateManagement.Dtos;
using CertificateManagement.Models;
using CertificateManagement.Repository.Interface;
using CertificateManagement.Service.Interfaces;

namespace CertificateManagement.Service.Implementations
{
    public class CertificateService : ICertificateService
    {
        private readonly ICertificateRepsitory _certificateRepository;
        private readonly IWebHostEnvironment _webHost;
        public CertificateService(ICertificateRepsitory certificateRepository, IWebHostEnvironment webHost)
        {
            _certificateRepository = certificateRepository;
            _webHost = webHost;
        }

        public async Task<BaseResponse<CertificateDto>> Create(CreateCertificateRequestModel model)
        {
           var number = Guid.NewGuid().ToString().Remove(7);
            // var certificateExists = _certificateRepository.Get(a => a.CertificateCode == model.CertificateCode);
            // if(certificateExists != null) return new BaseResponse<CertificateDto>
            // {
            //     Message = "Certificate already exits",
            //     Status = false,
            //     Data = null
            // };
            var certificate = new Certificate
            {
                CertificateCode = number,
                FirstName = model.FirstName,
                LastName = model.LastName,
                CertificatePreference = model.CertificatePreference,
                Comment = model.Comment,
                QRCodeText = model.QRCodeText
            };
            await _certificateRepository.Create(certificate);

            var folderPath = Path.Combine(Directory.GetCurrentDirectory() + "\\Signatures\\");
            if (!System.IO.Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }
            if (model.Signature != null)
            {
                var fileName = Path.GetFileNameWithoutExtension(model.Signature.FileName);
                var filePath = Path.Combine(folderPath, model.Signature.FileName);
                var extension = Path.GetExtension(model.Signature.FileName);
                if (!System.IO.Directory.Exists(filePath))
                {
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await model.Signature.CopyToAsync(stream);

                    }
                    certificate.Signature = fileName;
                }
            }
            await _certificateRepository.Update(certificate);
            return new BaseResponse<CertificateDto>
            {
                Message = "Certificate created successfully",
                Status = true,                
            };
        }

        public async Task<bool> Delete(int id)
        {
            var admin = await _certificateRepository.Get(id);
            if (admin != null)
            {
                admin.isDeleted = true;
                return true;
            }
            return false;
        }

        public async Task<CertificateResponseModel> Get(int id)
        {
            var certificate = await _certificateRepository.Get(id);
            if(certificate == null)
            {
                return new CertificateResponseModel
                {
                    Message = "Certificate not found",
                    Status = false,
                    Data = null
                };
            }
            return new CertificateResponseModel
            {
                Message = "Successfully",
                Status = true,
                Data = new CertificateDto
                {
                    FirstName = certificate.FirstName,
                    LastName = certificate.LastName,
                    CertificateCode = certificate.CertificateCode,
                    CertificatePreference = certificate.CertificatePreference,
                    Comment = certificate.Comment,
                    Date = certificate.Date,
                    Signature = certificate.Signature,
                    QRCodeText = certificate.QRCodeText
                }
            };
        }

        public async Task<CertificatesResponseModels> GetAll()
        {          
            var certificates = await _certificateRepository.GetAll();
            if(certificates == null)
            {
                return new CertificatesResponseModels
                {
                    Message = "No certificate exist",
                    Status = false,
                    Data = null
                };
            }
            var listOfCertificates = certificates.ToList().Select(certificate => new CertificateDto
            {
                Id = certificate.Id,
                FirstName = certificate.FirstName,
                LastName = certificate.LastName,
                CertificateCode = certificate.CertificateCode,
                CertificatePreference = certificate.CertificatePreference,
                Comment = certificate.Comment,
                Date = certificate.Date,
                Signature = certificate.Signature,
                QRCodeText = certificate.QRCodeText
            }).ToList();
            return new CertificatesResponseModels
            {
                Message = "Successful",
                Status = true,
                Data = listOfCertificates
            };
        }

        public async Task<BaseResponse<CertificateDto>> Update(UpdateCertificateRequestModel model , int id)
        {
            var certificate = await _certificateRepository.Get(a => a.Id == id);
            if (certificate == null) return new BaseResponse<CertificateDto>
            {
                Message = "Certificate not found",
                Status = false,
                Data = null
            };
            var folderPath = Path.Combine(Directory.GetCurrentDirectory() + "\\Signatures\\");
            if (!System.IO.Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }
            var fileName = Path.GetFileNameWithoutExtension(model.Signature.FileName);
            var filePath = Path.Combine(folderPath, model.Signature.FileName);
            var extension = Path.GetExtension(model.Signature.FileName);
            if (!System.IO.Directory.Exists(filePath))
            {
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await model.Signature.CopyToAsync(stream);
                }
                certificate.Signature = fileName;
            }

            certificate.FirstName = model.FirstName;
            certificate.LastName = model.LastName;
            certificate.Comment = model.Comment;
            certificate.Date = model.Date;
            certificate.CertificatePreference = model.CertificatePreference;
            
            await _certificateRepository.Update(certificate);

            return new BaseResponse<CertificateDto>
            {
                Message = "Certificate updated successfully",
                Status = true,
            };
        }
    }
}
