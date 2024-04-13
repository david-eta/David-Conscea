using Conscea_Api.Models;
using Microsoft.EntityFrameworkCore;

namespace Conscea_Api.Data;

public class ConsceaContext : DbContext
{
    public ConsceaContext(DbContextOptions<ConsceaContext> options) : base(options) { return; }

    // using the convention of plural table names and singular class names
    public DbSet<Account> Accounts { get; set; }
    public DbSet<CertInfo> CertInfos { get; set; }
    public DbSet<CertArchive> CertArchives { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // not needed since the names are same, but good practice to have
        modelBuilder.Entity<Account>().ToTable("Account");
        modelBuilder.Entity<CertInfo>().ToTable("CertInfo");
        modelBuilder.Entity<CertArchive>().ToTable("CertArchive");

        modelBuilder.Entity<CertArchive>()
            .HasKey(ca => new { ca.AccountId, ca.CertId, ca.CertifiedDate });

        // Setting the Unique Keys
        modelBuilder.Entity<Account>().HasIndex(a => a.Username).IsUnique();
        modelBuilder.Entity<Account>().HasIndex(a => a.Email).IsUnique();
        modelBuilder.Entity<Account>().HasIndex(a => a.Mobile).IsUnique();
        modelBuilder.Entity<CertInfo>().HasIndex(a => a.Name).IsUnique();

        // primary key(s)
        modelBuilder.Entity<Account>().HasKey(x => x.Id);
    }
}