using CertificateManagement.ApplicationContext;
using CertificateManagement.Models;
using CertificateManagement.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace CertificateManagement.Repository.Implementations
{
    public class RoleRepository<T> : BaseRepository<Role>, IRoleRepository
    {
        public RoleRepository(ContextClass context)
        {
            _context = context;
        }
        public async Task<Role> Get(int id)
        {
            return await _context.Roles
                .Include(c => c.UserRoles)
                .ThenInclude(c => c.User)
                .FirstOrDefaultAsync(d => d.Id == id);
        }

        public async Task<Role> Get(Expression<Func<Role, bool>> expression)
        {
            return await _context.Roles
                .Include(c => c.UserRoles)
                .ThenInclude(c => c.User)
                .FirstOrDefaultAsync(expression);
        }

        public async Task<IList<Role>> GetAll()
        {
            return await _context.Roles
                .Include(c => c.UserRoles)
                .ThenInclude(c => c.User)
                .ToListAsync();
        }
    }
}
