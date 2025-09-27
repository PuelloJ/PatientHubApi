
using Microsoft.EntityFrameworkCore;
using PatientHubApi.Core.Entities;

namespace PatientHubApi.Infrastructure.Data;

public class ApplicationDbContext : DbContext
{

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

    public DbSet<Patient> Patients { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Patient>(entitty =>
        {
            entitty.HasKey(e => e.PatientId);
            entitty.HasIndex(e => new { e.DocumentType, e.DocumentNumber }).IsUnique();
            entitty.Property(e => e.DocumentType).HasMaxLength(10).IsRequired();
            entitty.Property(e => e.DocumentNumber).HasMaxLength(20).IsRequired();
            entitty.Property(e => e.FirstName).HasMaxLength(80).IsRequired();
            entitty.Property(e => e.LastName).HasMaxLength(80).IsRequired();
            entitty.Property(e => e.Email).HasMaxLength(120);
            entitty.Property(e => e.PhoneNumber).HasMaxLength(20);
            entitty.Property(e => e.CreatedAt).HasDefaultValueSql("GETUTCDATE()");
        });
    }


}
