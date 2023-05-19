using Microsoft.EntityFrameworkCore;
using Sber_ASPTT.Models;
using System.Collections.Generic;

namespace Sber_ASPTT
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }

        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
        }
    }
}
