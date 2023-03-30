using CertificateManagement.Models;
using Microsoft.EntityFrameworkCore;

namespace CertificateManagement.ApplicationContext
{
    public class ContextClass : DbContext
    {
        public ContextClass(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Certificate> Certificates { get; set; }
        public DbSet<Organization> Organizations { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
    }
}
