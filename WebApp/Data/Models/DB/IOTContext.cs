using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Data.Models.DB
{
    public partial class IOTContext : DbContext
    {
        public IOTContext()
        {
        }

        public IOTContext(DbContextOptions<IOTContext> options)
            : base(options)
        {
        }

        public virtual DbSet<CountrySignals> CountrySignals { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=.;Database=IOT;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CountrySignals>(entity =>
            {
                entity.Property(e => e.Country)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });
        }
    }
}
