using Microsoft.EntityFrameworkCore;
using Splid.Infrastructure.Models;

namespace Splid.Infrastructure
{
    public class SplidDbContext : DbContext
    {
        public SplidDbContext(DbContextOptions<SplidDbContext> options)
            : base(options)
        {
        }

        internal DbSet<Group> Groups { get; set; }
    }
}