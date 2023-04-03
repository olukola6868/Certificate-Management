using CertificateManagement.ApplicationContext;
using CertificateManagement.Models;
using CertificateManagement.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace CertificateManagement.Repository.Implementations
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {

        public UserRepository(ContextClass context)
        {
            _context = context;
        }
        public async Task<User> Get(int id)
        {
            return await _context.Users
                .Include(c => c.UserRoles)
                .ThenInclude(c => c.Role)
                .Include(c => c.Organization)
                .Include(c => c.Admin)
                .FirstOrDefaultAsync(d => d.Id == id);
        }

        public async Task<User> Get(Expression<Func<User, bool>> expression)
        {
            return await _context.Users
                .Include(c => c.UserRoles)
                 .ThenInclude(c => c.Role)
                 .Include(c => c.Organization)
                 .Include(c => c.Admin)
                 .FirstOrDefaultAsync(expression);
        }

        public async Task<IList<User>> GetAll()
        {
            return await _context.Users
                .Include(c => c.UserRoles)
                 .ThenInclude(c => c.Role)
                 .Include(c => c.Organization)
                 .Include(c => c.Admin)
                 .ToListAsync();
        }
    }
}
