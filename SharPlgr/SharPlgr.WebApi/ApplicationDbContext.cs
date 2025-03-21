using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using SharPlgr.WebApi.Models;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<TRawWord> RawWords { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // t_raw_word
        modelBuilder.Entity<TRawWord>()
            .ToTable("t_raw_word")
            .HasKey(e => e.Id);
        modelBuilder.Entity<TRawWord>()
            .Property(e => e.Id)
            .HasColumnName("id")
            .ValueGeneratedOnAdd();
        modelBuilder.Entity<TRawWord>()
            .Property(e => e.Word)
            .HasColumnName("word")
            .IsRequired();
        modelBuilder.Entity<TRawWord>()
            .HasIndex(e => e.Word)
            .IsUnique();
    }
}