using CertificateManagement.Models;
using System.Linq.Expressions;

namespace CertificateManagement.Repository.Interface
{
    public interface IAdminRepository : IBaseRepository<Admin>
    {
        Task<Admin> Get(int id);
        Task<Admin> Get(Expression<Func<Admin, bool>> expression);
        Task<IList<Admin>> GetAll();
    }
}
