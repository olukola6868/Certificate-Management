using CertificateManagement.Models;
using System.Linq.Expressions;

namespace CertificateManagement.Repository.Interface
{
    public interface IUserRepository : IBaseRepository<User>
    {
         Task<User> Get(int id);
         Task<User> Get(Expression<Func<User, bool>> expression);
         Task<IList<User>> GetAll();
    }
}
