using Microsoft.EntityFrameworkCore;
using GorillacApi.Models;

namespace GorillacApi
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<ContactMessage> ContactMessages { get; set; }
    }
}
