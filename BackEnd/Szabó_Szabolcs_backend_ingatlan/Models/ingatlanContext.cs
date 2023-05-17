﻿using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Szabó_Szabolcs_backend_ingatlan.Models
{
    public partial class ingatlanContext : DbContext
    {
        public ingatlanContext()
        {
        }

        public ingatlanContext(DbContextOptions<ingatlanContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Ingatlanok> Ingatlanoks { get; set; }
        public virtual DbSet<Kategoriak> Kategoriaks { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseMySQL("server=localhost;database=ingatlan;user=root;password=;ssl mode=none;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Ingatlanok>(entity =>
            {
                entity.ToTable("ingatlanok");

                entity.HasIndex(e => e.Kategoria, "kategoria");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.Ar)
                    .HasColumnType("int(12)")
                    .HasColumnName("ar");

                entity.Property(e => e.HirdetesDatuma)
                    .HasColumnType("date")
                    .HasColumnName("hirdetesDatuma")
                    .HasDefaultValueSql("'current_timestamp()'");

                entity.Property(e => e.Kategoria)
                    .HasColumnType("int(11)")
                    .HasColumnName("kategoria");

                entity.Property(e => e.KepUrl)
                    .IsRequired()
                    .HasColumnName("kepUrl");

                entity.Property(e => e.Leiras)
                    .IsRequired()
                    .HasColumnName("leiras");

                entity.Property(e => e.Tehermentes).HasColumnName("tehermentes");

                entity.HasOne(d => d.KategoriaNavigation)
                    .WithMany(p => p.Ingatlanoks)
                    .HasForeignKey(d => d.Kategoria)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("ingatlanok_ibfk_1");
            });

            modelBuilder.Entity<Kategoriak>(entity =>
            {
                entity.ToTable("kategoriak");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.Nev)
                    .IsRequired()
                    .HasColumnName("nev");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
