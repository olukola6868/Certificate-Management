namespace CertificateManagement.Repository.Interface
{
    public interface IBaseRepository<T>
    {
         Task<T> Create(T entity);
         Task<T> Update(T entity);
    }
}
