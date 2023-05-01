using CertificateManagement.ApplicationContext;
using CertificateManagement.Models;
using CertificateManagement.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace CertificateManagement.Repository.Implementations
{
    public class CertificateRepository : BaseRepository<Certificate>, ICertificateRepsitory
    {
        public CertificateRepository(ContextClass context)
        {
            _context = context;
        }
        public async Task<Certificate> Get(int id)
        {
            return await _context.Certificates
               .Include(c => c.Organization)
               .FirstOrDefaultAsync(d => d.Id == id);
        }

        public async Task<Certificate> Get(Expression<Func<Certificate, bool>> expression)
        {
            return await _context.Certificates
                .Include(c => c.Organization)
                .FirstOrDefaultAsync(expression);
        }

        public async Task<IList<Certificate>> GetAll()
        {
            return await _context.Certificates
                .Include(c => c.Organization)
                .ToListAsync();
        }

        public async Task<Certificate> GetByCode(string CertificateCode)
        {
             return await _context.Certificates
               .Include(c => c.Organization)
               .FirstOrDefaultAsync(d => d.CertificateCode == CertificateCode);
        }
    }
}
