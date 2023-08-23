using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using MyProject.Domain.Entities;

namespace MyProject.Infrastructure.Data;


public class AppDbContext : DbContext
{
    private readonly IConfiguration _configuration;
    public AppDbContext(DbContextOptions<AppDbContext> options, IConfiguration configuration) : base(options)
    {
        _configuration = configuration;
    }
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

