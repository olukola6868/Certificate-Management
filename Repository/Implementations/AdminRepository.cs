using CertificateManagement.ApplicationContext;
using CertificateManagement.Models;
using CertificateManagement.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace CertificateManagement.Repository.Implementations
{
    public class AdminRepository<T> : BaseRepository<Admin>, IAdminRepository
    {
        public AdminRepository(ContextClass context)
        {
            _context = context;
        }
        public async Task<Admin> Get(int id)
        {
            return await _context.Admins
                .Include(c => c.User)
                .FirstOrDefaultAsync(d => d.Id == id);
        }

        public async Task<Admin> Get(Expression<Func<Admin, bool>> expression)
        {
            return await _context.Admins
                .Include(c => c.User)
                .FirstOrDefaultAsync(expression);
        }

        public async Task<IList<Admin>> GetAll()
        {
            return await _context.Admins
                .Include(c => c.User)
                .ToListAsync();
        }
    }
}
