using Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Data.Contexts;

public class DataContext(DbContextOptions options) : DbContext(options)
{
    public DbSet<ProjectEntity> Projects { get; set; }
    public DbSet<CustomerEntity> Customers { get; set; }
    public DbSet<ProjectManagerEntity> ProjectManagers { get; set; }
    public DbSet<ServiceEntity> Services { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ProjectEntity>()
            .Property(p => p.ProjectNumber)
            .HasMaxLength(10);

        modelBuilder.Entity<ProjectEntity>()
            .Property(p => p.Status)
            .HasMaxLength(20);

        modelBuilder.Entity<CustomerEntity>()
            .Property(c => c.PhoneNumber)
            .HasMaxLength(15);

        modelBuilder.Entity<ProjectManagerEntity>()
            .Property(pm => pm.PhoneNumber)
            .HasMaxLength(15);
    }
}