using CertificateManagement.Models;
using System.Linq.Expressions;

namespace CertificateManagement.Repository.Interface
{
    public interface ICertificateRepsitory : IBaseRepository<Certificate>
    {
        Task<Certificate> Get(int id);
        Task<Certificate> Get(Expression<Func<Certificate, bool>> expression);
        Task<IList<Certificate>> GetAll();
    }
}
