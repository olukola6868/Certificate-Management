using CertificateManagement.Models;
using System.Linq.Expressions;

namespace CertificateManagement.Repository.Interface
{
    public interface IRoleRepository : IBaseRepository<Role>
    {
         Task<Role> Get(int id);
         Task<Role> Get(Expression<Func<Role, bool>> expression);
         Task<IList<Role>> GetAll();
    }
}
