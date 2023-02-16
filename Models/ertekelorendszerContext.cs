using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace ErtekelesX.Models
{
    public partial class ertekelorendszerContext : DbContext
    {
        public ertekelorendszerContext()
        {
        }

        public ertekelorendszerContext(DbContextOptions<ertekelorendszerContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Ertekelesek> Ertekeleseks { get; set; }
        public virtual DbSet<Getter> Getters { get; set; }
        public virtual DbSet<Screening> Screenings { get; set; }
        public virtual DbSet<Szempont> Szemponts { get; set; }
        public virtual DbSet<Végsőpont> Végsőponts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseMySQL("server=localhost;database=ertekelo-rendszer;user=root;password=;ssl mode=none;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Ertekelesek>(entity =>
            {
                entity.ToTable("ertekelesek");

                entity.HasIndex(e => e.ScreeningId, "screening_id");

                entity.HasIndex(e => new { e.ScreeningId, e.SzempontId }, "screening_id_2")
                    .IsUnique();

                entity.HasIndex(e => e.SzempontId, "szempont_id");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.Pontertek)
                    .HasColumnType("int(11)")
                    .HasColumnName("pontertek");

                entity.Property(e => e.ScreeningId)
                    .HasColumnType("int(11)")
                    .HasColumnName("screening_id");

                entity.Property(e => e.SzempontId)
                    .HasColumnType("int(11)")
                    .HasColumnName("szempont_id");

                entity.HasOne(d => d.Screening)
                    .WithMany(p => p.Ertekeleseks)
                    .HasForeignKey(d => d.ScreeningId)
                    .HasConstraintName("ertekelesek_ibfk_3");

                entity.HasOne(d => d.Szempont)
                    .WithMany(p => p.Ertekeleseks)
                    .HasForeignKey(d => d.SzempontId)
                    .HasConstraintName("ertekelesek_ibfk_4");
            });

            modelBuilder.Entity<Getter>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("getter");

                entity.Property(e => e.Nev)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("nev");

                entity.Property(e => e.Pontertek)
                    .HasColumnType("int(11)")
                    .HasColumnName("pontertek");

                entity.Property(e => e.SzempontNev)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("szempont-nev");

                entity.Property(e => e.Szorzo)
                    .HasColumnType("int(11)")
                    .HasColumnName("szorzo");

                entity.Property(e => e.VégsőPont)
                    .HasColumnType("bigint(21)")
                    .HasColumnName("végső pont");
            });

            modelBuilder.Entity<Screening>(entity =>
            {
                entity.ToTable("screening");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.Nev)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("nev");
            });

            modelBuilder.Entity<Szempont>(entity =>
            {
                entity.ToTable("szempont");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.SzempontNev)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("szempont-nev");

                entity.Property(e => e.Szorzo)
                    .HasColumnType("int(11)")
                    .HasColumnName("szorzo");
            });

            modelBuilder.Entity<Végsőpont>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("végsőpont");

                entity.Property(e => e.Nev)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("nev");

                entity.Property(e => e.VégsőPont1)
                    .HasColumnType("decimal(42,0)")
                    .HasColumnName("végső pont")
                    .HasDefaultValueSql("'NULL'");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
