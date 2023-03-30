using CertificateManagement.Dtos;
using CertificateManagement.Models;
using CertificateManagement.Repository.Interface;
using CertificateManagement.Service.Interfaces;

namespace CertificateManagement.Service.Implementations
{
    public class AdminService : IAdminService
    {

        private readonly IAdminRepository _adminRepository;
        private readonly IUserRepository _userRepository;
        private readonly IRoleRepository _roleRepository;
        public AdminService(IAdminRepository adminRepository, IUserRepository userRepository, IRoleRepository roleRepository)
        {
            _adminRepository = adminRepository;
            _userRepository = userRepository;
            _roleRepository = roleRepository;
        }
        public async Task<BaseResponse<AdminDto>> Create(CreateAdminRequestModel model)
        {
            var adminExists = await _adminRepository.Get(x => x.User.EmailAddress == model.EmailAddress);
            if (adminExists != null) return new BaseResponse<AdminDto>
            {
                Message = "Admin already exist",
                Status = false,
                Data = null,
            };
            var user = new User
            {

                Address = model.Address,
                EmailAddress = model.EmailAddress,
                Password = model.Password,
                PhoneNumber = model.PhoneNumber,
            };
            await _userRepository.Create(user);

            var role = await _roleRepository.Get(r => r.Name == "Admin");
            var userRole = new UserRole
            {
                UserId = user.Id,
                RoleId = role.Id
            };
            user.UserRoles.Add(userRole);
            await _userRepository.Update(user);

            var admin = new Admin
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                UserId = user.Id
            };
            await _adminRepository.Create(admin);

            return new BaseResponse<AdminDto>
            {
                Message = "Successful",
                Status = true,
                Data = new AdminDto
                {
                    Id = admin.Id,
                    FirstName = admin.FirstName,
                    LastName = admin.LastName,
                    EmailAddress = admin.User.EmailAddress,
                    Address = admin.User.Address,
                    Password = admin.User.Password,
                    PhoneNumber = admin.User.PhoneNumber
                }
            };
        }

        public async Task<bool> Delete(int id)
        {
            var admin = await  _adminRepository.Get(id);
            if (admin != null)
            {
                admin.isDeleted = true;
                return true;
            }
            return false;
        }

        public async Task<AdminResponseModel> Get(int id)
        {
            var admin = await _adminRepository.Get(id);
            if(admin != null)
            {
                return new AdminResponseModel
                {
                    Message = "Successful",
                    Status = true,
                    Data = new AdminDto
                    {
                        Id = admin.Id,
                        UserId = admin.UserId,
                        FirstName = admin.FirstName,
                        LastName = admin.LastName,
                        Address = admin.User.Address,
                        Password = admin.User.Password,
                        PhoneNumber = admin.User.PhoneNumber,
                        EmailAddress = admin.User.EmailAddress
                    }
                };
            }
            return new AdminResponseModel
            {
                Message = "admin not found",
                Status = false,
                Data = null
            };
        }

        public async Task<AdminsResponseModels> GetAll()
        {
            var admins = await _adminRepository.GetAll();
            var listOfAdmins = admins.ToList().Select(admin => new AdminDto
            {
                Id = admin.Id,
                UserId = admin.UserId,
                FirstName = admin.FirstName,
                LastName = admin.LastName,
                Address = admin.User.Address,
                Password = admin.User.Password,
                PhoneNumber = admin.User.PhoneNumber,
                EmailAddress = admin.User.EmailAddress
            }).ToList();
            return new AdminsResponseModels
            {
                Message = "ok",
                Status = true,
                Data = listOfAdmins
            };
        }

        public async Task<BaseResponse<AdminDto>> Update(UpdateAdminRequestModel model, int id)
        {
            var admin = await _adminRepository.Get(id);
            if(admin == null)
            {
                return new BaseResponse<AdminDto>
                {
                    Message = "Admin not found. ",
                    Status = false,
                    Data = null
                };
            }
            admin.FirstName = model.FirstName;
            admin.LastName = model.LastName;
            admin.User.Address = model.Address;
            admin.User.PhoneNumber = model.PhoneNumber;
            await _adminRepository.Update(admin);

            return new BaseResponse<AdminDto>
            {
                Message = "User updated successfully...",
                Status = true
            };
        }
    }
}
