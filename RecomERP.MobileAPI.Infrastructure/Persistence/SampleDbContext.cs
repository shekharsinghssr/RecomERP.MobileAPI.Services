using Microsoft.EntityFrameworkCore;
using RecomERP.MobileAPI.Domain.Models;
namespace RecomERP.MobileAPI.Infrastructure.Persistence
{
    public class SampleDbContext : DbContext
    {
        public SampleDbContext(DbContextOptions<SampleDbContext> options) : base(options) { }
        public DbSet<SampleModel> Samples { get; set; }
    }
}
