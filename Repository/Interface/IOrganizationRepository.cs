using CertificateManagement.Models;
using System.Linq.Expressions;

namespace CertificateManagement.Repository.Interface
{
    public interface IOrganizationRepository : IBaseRepository<Organization>
    {
        Task<Organization> Get(int id);
        Task<IList<Organization>> GetUnapprovedOrganizations();
        Task<Organization> Get(Expression<Func<Organization, bool>> expression);
        Task<IList<Organization>> GetAll();
    }
}
