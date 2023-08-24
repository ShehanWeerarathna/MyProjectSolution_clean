using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using MyProject.Domain.Entities;

namespace MyProject.Infrastructure.Data;


public class AppDbContext : DbContext
{

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
    public DbSet<Designation> Designations { get; set; }
    public DbSet<Employee> Employees { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

        modelBuilder.Entity<Employee>()
        .HasOne<Designation>(s => s.Designation)
        .WithMany(g => g.Employees)
        .HasForeignKey(s => s.DesignationId);
    }
}

