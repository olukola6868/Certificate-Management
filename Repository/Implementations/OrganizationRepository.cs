using CertificateManagement.ApplicationContext;
using CertificateManagement.Models;
using CertificateManagement.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace CertificateManagement.Repository.Implementations
{
    public class OrganizationRepository<T> : BaseRepository<Organization>, IOrganizationRepository
    {
        public OrganizationRepository(ContextClass context)
        {
            _context = context;
        }
        public async Task<Organization> Get(int id)
        {
            return await _context.Organizations
                .Include(c => c.Certificates)
                .FirstOrDefaultAsync(d => d.Id == id);
        }

        public async Task<Organization> Get(Expression<Func<Organization, bool>> expression)
        {
            return await _context.Organizations
                .Include(c => c.Certificates)
                .FirstOrDefaultAsync(expression);

        }

        public async Task<IList<Organization>> GetAll()
        {
            return await _context.Organizations
               .Include(c => c.Certificates)
               .ToListAsync();

        }

        public async Task<IList<Organization>> GetUnapprovedOrganizations()
        {
            return await _context.Organizations.Where(x => x.IsApproved == false)
                .ToListAsync();
        }
    }
}
