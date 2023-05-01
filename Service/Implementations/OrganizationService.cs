using CertificateManagement.Dtos;
using CertificateManagement.Models;
using CertificateManagement.Repository.Interface;
using CertificateManagement.Service.Interfaces;

namespace CertificateManagement.Service.Implementations
{
    public class OrganizationService : IOrganizationService
    {
        private readonly IOrganizationRepository _organizationRepository;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IUserRepository _userRepository;
        private readonly IRoleRepository _roleRepository;
        public OrganizationService(IOrganizationRepository organizationRepository, IUserRepository userRepository, IRoleRepository roleRepository, IWebHostEnvironment webHostEnvironment)
        {
            _organizationRepository = organizationRepository;
            _roleRepository = roleRepository;
            _userRepository = userRepository;
            _webHostEnvironment = webHostEnvironment;
        }
        public async Task<BaseResponse<OrganizationDto>> Create(CreateOrganizationRequestModel model)
        {
            var organizationExists = await _organizationRepository.Get(a => a.User.EmailAddress == model.EmailAddress);
            if (organizationExists != null) return new BaseResponse<OrganizationDto>
            {
                Message = "Organization already exist",
                Status = false,
                Data = null
            };
            var user = new User
            {
                Address = model.Address,
                EmailAddress = model.EmailAddress,
                PhoneNumber = model.PhoneNumber,
                Password = model.Password,
            };
            await _userRepository.Create(user);




            string CACImage = null;

            if (model.CAC != null)
            {
                var uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "CAC");
                if (!Directory.Exists(uploadsFolder))
                {
                    Directory.CreateDirectory(uploadsFolder);
                }

                var fileName = Guid.NewGuid().ToString() + Path.GetFileName(model.CAC.FileName);
                CACImage = "/CAC/" + fileName;
                var filePath = Path.Combine(uploadsFolder, fileName);
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await model.CAC.CopyToAsync(stream);
                }
            }



            string logoImage = null;

            if (model.Logo != null)
            {
                var uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "Logo");
                if (!Directory.Exists(uploadsFolder))
                {
                    Directory.CreateDirectory(uploadsFolder);
                }

                var fileName = Guid.NewGuid().ToString() + Path.GetFileName(model.Logo.FileName);
                logoImage = "/Logo/" + fileName;
                var filePath = Path.Combine(uploadsFolder, fileName);
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await model.Logo.CopyToAsync(stream);
                }
            }



            var organization = new Organization
            {
                OrganizationName = model.OrganizationName,
                OrganizationDescription = model.OrganizationDescription,
                City = model.City,
                State = model.State,
                LocalGovernment = model.LocalGovernment,
                UserId = user.Id,
                CAC = CACImage,
                Logo = logoImage,
            };

            var role = await _roleRepository.Get(r => r.Name == "Organization");
            var userRole = new UserRole
            {
                UserId = user.Id,
                RoleId = role.Id
            };
            user.UserRoles.Add(userRole);

            await _organizationRepository.Create(organization);





            return new BaseResponse<OrganizationDto>
            {
                Message = "Certificate created successfully",
                Status = true,
            };
        }

        public async Task<bool> Delete(int id)
        {
            var organization = await _organizationRepository.Get(id);
            if (organization != null)
            {
                organization.isDeleted = true;
                return true;
            }
            return false;
        }

        public async Task<OrganizationResponseModel> Get(int id)
        {
            var organization = await _organizationRepository.Get(id);
            if (organization != null) return new OrganizationResponseModel
            {
                Message = "Successful",
                Status = true,
                Data = new OrganizationDto
                {
                    Id = organization.Id,
                    UserId = organization.UserId,
                    OrganizationName = organization.OrganizationName,
                    OrganizationDescription = organization.OrganizationDescription,
                    Address = organization.User.Address,
                    EmailAddress = organization.User.EmailAddress,
                    PhoneNumber = organization.User.PhoneNumber,
                    Password = organization.User.Password,
                    City = organization.City,
                    State = organization.State,
                    LocalGovernment = organization.LocalGovernment,
                    CAC = organization.CAC,
                    Logo = organization.Logo
                }
            };
            return new OrganizationResponseModel
            {
                Message = "Organization not found",
                Status = false,
                Data = null
            };
        }

        public async Task<OrganizationsResponseModels> GetAll()
        {
            var organizations = await _organizationRepository.GetAll();
            if (organizations == null) return new OrganizationsResponseModels
            {
                Message = "Organization is null",
                Status = false,
                Data = null
            };
            var listOfOrganizations = organizations.Select(organization => new OrganizationDto
            {
                Id = organization.Id,
                UserId = organization.UserId,
                OrganizationName = organization.OrganizationName,
                OrganizationDescription = organization.OrganizationDescription,
                Address = organization.User.Address,
                EmailAddress = organization.User.EmailAddress,
                PhoneNumber = organization.User.PhoneNumber,
                Password = organization.User.Password,
                City = organization.City,
                State = organization.State,
                LocalGovernment = organization.LocalGovernment,
                CAC = organization.CAC,
                Logo = organization.Logo
            }).ToList();
            return new OrganizationsResponseModels
            {
                Message = "ok",
                Status = true,
                Data = listOfOrganizations
            };
        }

        public async Task<BaseResponse<OrganizationDto>> Update(UpdateOrganizationRequestModel model, int id)
        {
            var organization = await _organizationRepository.Get(a => a.Id == id);
            if (organization == null) return new BaseResponse<OrganizationDto>
            {
                Message = "Organization not found",
                Status = false,
                Data = null
            };

            string CACImage = null;

            if (model.CAC != null)
            {
                var uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "CAC");
                if (!Directory.Exists(uploadsFolder))
                {
                    Directory.CreateDirectory(uploadsFolder);
                }

                var fileName = Guid.NewGuid().ToString() + Path.GetFileName(model.CAC.FileName);
                CACImage = "/CAC/" + fileName;
                var filePath = Path.Combine(uploadsFolder, fileName);
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await model.CAC.CopyToAsync(stream);
                }
            }


            string logoImage = null;

            if (model.Logo != null)
            {
                var uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "Logo");
                if (!Directory.Exists(uploadsFolder))
                {
                    Directory.CreateDirectory(uploadsFolder);
                }

                var fileName = Guid.NewGuid().ToString() + Path.GetFileName(model.Logo.FileName);
                logoImage = "/Logo/" + fileName;
                var filePath = Path.Combine(uploadsFolder, fileName);
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await model.Logo.CopyToAsync(stream);
                }
            }

            organization.City = model.City;
            organization.User.Address = model.Address;
            organization.User.PhoneNumber = model.PhoneNumber;
            organization.LocalGovernment = model.LocalGovernment;
            organization.OrganizationName = model.OrganizationName;
            organization.OrganizationDescription = model.OrganizationDescription;
            organization.State = model.State;
            organization.CAC = CACImage;
            organization.Logo = logoImage;

            await _organizationRepository.Update(organization);

            return new BaseResponse<OrganizationDto>
            {
                Message = "Organization updated successfully",
                Status = true,
            };
        }
    }
}
