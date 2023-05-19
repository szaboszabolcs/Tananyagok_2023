using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Jatekok_WEB_API.Models
{
    public partial class jatekokContext : DbContext
    {
        public jatekokContext()
        {
        }

        public jatekokContext(DbContextOptions<jatekokContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Jatek> Jateks { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseMySQL("server=localhost;database=jatekok;user=root;password=;ssl mode=none;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Jatek>(entity =>
            {
                entity.ToTable("jatek");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.Ar)
                    .HasColumnType("int(11)")
                    .HasColumnName("ar");

                entity.Property(e => e.KepUrl)
                    .IsRequired()
                    .HasColumnName("kepUrl");

                entity.Property(e => e.Leiras)
                    .IsRequired()
                    .HasColumnName("leiras");

                entity.Property(e => e.Megjeleneseve)
                    .HasColumnType("int(11)")
                    .HasColumnName("megjeleneseve");

                entity.Property(e => e.Nev)
                    .IsRequired()
                    .HasMaxLength(70)
                    .HasColumnName("nev");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
