using Microsoft.EntityFrameworkCore;
using RecomERP.MobileAPI.Domain.Models.RecomERP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecomERP.MobileAPI.Infrastructure.Persistence
{
    public class RecomERPContext : DbContext
    {
        public RecomERPContext(DbContextOptions<RecomERPContext> options) : base(options) { }
        public DbSet<DeviceInwardingDetails> DeviceInwardingDetails { get; set; }
        public DbSet<Model> Models { get; set; }
        public DbSet<POMaster> POMaster { get; set; }
        public DbSet<PODetails> PODetails { get; set; }
        public DbSet<Vendor> Vendor { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<HomeBanner> HomeBanners { get; set; }
        public DbSet<ThumbBanner> ThumbBanners { get; set; }
        public DbSet<HomeProductBlock> HomeProductBlocks { get; set; }
        public DbSet<HomeProductBlockItem> HomeProductBlockItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Brand>(entity =>
            {
                entity.HasKey(u => u.BrandID);
            });

            modelBuilder.Entity<DeviceInwardingDetails>(entity =>
            {
                entity.HasKey(u => u.DeviceInwardingID);
                entity.Ignore(o => o.Id);
                entity.Ignore(m => m.ModifiedBy);
                entity.Ignore(m => m.ModifiedOn);
            });


            modelBuilder.Entity<Model>(entity =>
            {

                entity.HasKey(e => e.ModelID);
                entity.Ignore(u => u.Id);
                entity.Ignore(u => u.GUId);
                entity.Ignore(u => u.ModifiedBy);
                entity.Ignore(u => u.ModifiedOn);


            });

            modelBuilder.Entity<POMaster>(entity =>
            {
                entity.HasKey(u => u.POMasterID);
                entity.Ignore(o => o.VendorGUID);
                entity.Ignore(m => m.ModifiedBy);
                entity.Ignore(m => m.ModifiedOn);
            });

            modelBuilder.Entity<PODetails>(entity =>
            {
                entity.HasKey(e => e.PODetailID);
            });

        }
    }
}
