using CertificateManagement.ApplicationContext;
using CertificateManagement.Models;
using CertificateManagement.Repository.Interface;

namespace CertificateManagement.Repository.Implementations
{
    public class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity, new()
    {
        protected ContextClass _context;

        public async Task<T> Create(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<T> Update(T entity)
        {
            _context.Set<T>().Update(entity);
            await _context.SaveChangesAsync();
            return entity;
        }
    }
}
