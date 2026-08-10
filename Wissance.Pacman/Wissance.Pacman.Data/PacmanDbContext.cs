using Microsoft.EntityFrameworkCore;
using Wissance.Pacman.Data.Entities;
using Wissance.Pacman.Data.Mappers;

namespace Wissance.Pacman.Data
{
    public class PacmanDbContext : DbContext
    {
        public PacmanDbContext()
        {
            
        }
        
        public PacmanDbContext(DbContextOptions<PacmanDbContext> options) 
            : base(options)
        {
            
        }
        
        public override int SaveChanges()
        {
            try
            {
                return base.SaveChanges();
            }
            catch (Exception e)
            {
                return -1;
            }
        }

        public async Task<int> SaveChangesAsync()
        {
            try
            {
                return await base.SaveChangesAsync();
            }
            catch (Exception e)
            {
                return -1;
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
            modelBuilder.Entity<Tag>().Map();
            modelBuilder.Entity<TargetFramework>().Map();
            modelBuilder.Entity<PackageOwner>().Map();
            modelBuilder.Entity<PackageVersionStats>().Map();
            modelBuilder.Entity<PackageDependency>().Map();
            modelBuilder.Entity<PackageVersion>().Map();
            modelBuilder.Entity<Package>().Map();
            modelBuilder.Entity<ResourceMetadata>().Map();
            modelBuilder.Entity<Localization>().Map();
            modelBuilder.Entity<LocalizationString>().Map();
            modelBuilder.Entity<ApiKey>().Map();
        }

        public DbSet<Package> Packages { get; set; }
        public DbSet<PackageVersion> PackageVersions { get; set; }
        public DbSet<PackageVersionStats> PackageVersionStats { get; set; }
        public DbSet<PackageDependency> PackageDependencies { get; set; }
        public DbSet<PackageOwner> PackageOwners { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<TargetFramework> TargetFrameworks { get; set; }
        public DbSet<ResourceMetadata> Resources { get; set; }
        public DbSet<Localization> Localizations { get; set; }
        public DbSet<LocalizationString> LocalizationStrings { get; set; }
        public DbSet<ApiKey> ApiKeys { get; set; }
    }
}