using ContactApi.Models;
using Microsoft.EntityFrameworkCore;

namespace ContactApi.Context
{
    public class ContactsContext : DbContext
    {
        public ContactsContext(DbContextOptions<ContactsContext> options)
            : base(options) { }

        public ContactsContext()
        {
        }

        public DbSet<Contacts> Contacts { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<JobTitle> JobTitle { get; set; }
    }
}