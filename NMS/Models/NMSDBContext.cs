using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace NMS.Models
{
    public partial class NMSDBContext : DbContext
    {
        public virtual DbSet<Number> Number { get; set; }

        public virtual DbSet<Customer> Customer { get; set; }

        public NMSDBContext(DbContextOptions<NMSDBContext> options)
            : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Number>(entity =>
            {
                entity.ToTable("number");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.ActiveDate)
                    .HasColumnName("activeDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.CeaseDate)
                    .HasColumnName("ceaseDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.CustomerDescription)
                    .HasColumnName("customerDescription")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Description)
                    .HasColumnName("description")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.FkCustomer).HasColumnName("fkCustomer");

                entity.Property(e => e.FkGroup).HasColumnName("fkGroup");

                entity.Property(e => e.Number1)
                    .IsRequired()
                    .HasColumnName("number")
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.ToTable("customer");

                entity.HasIndex(e => e.FkExceptionLcr)
                    .HasName("CustomerLcr");

                entity.HasIndex(e => e.Name)
                    .HasName("name_UNIQUE");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.BlockAnonymous)
                    .HasColumnName("blockAnonymous")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Customercol)
                    .HasColumnName("customercol")
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.DefaultBillingNumber)
                    .HasColumnName("defaultBillingNumber")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Description)
                    .HasColumnName("description")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.FkExceptionLcr).HasColumnName("fkExceptionLcr");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.NonGeo)
                    .HasColumnName("nonGeo")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.RoutingNumber)
                    .HasColumnName("routingNumber")
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });
        }
    }
}
