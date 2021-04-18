using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace DAL
{
    public partial class dp_musicContext : DbContext
    {
        public dp_musicContext()
        {
        }

        public dp_musicContext(DbContextOptions<dp_musicContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Album> Album { get; set; }
        public virtual DbSet<Band> Band { get; set; }
        public virtual DbSet<Bandgenre> Bandgenre { get; set; }
        public virtual DbSet<Composition> Composition { get; set; }
        public virtual DbSet<Genre> Genre { get; set; }
        public virtual DbSet<Reflection> Reflection { get; set; }
        public virtual DbSet<Selected> Selected { get; set; }
        public virtual DbSet<User> User { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Album>(entity =>
            {
                entity.ToTable("album");

                entity.HasIndex(e => e.BandId)
                    .HasName("Album_fk0");

                entity.Property(e => e.Description).HasMaxLength(1000);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(40);

                entity.HasOne(d => d.Band)
                    .WithMany(p => p.Album)
                    .HasForeignKey(d => d.BandId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Album_fk0");
            });

            modelBuilder.Entity<Band>(entity =>
            {
                entity.ToTable("band");

                entity.Property(e => e.CountryCode)
                    .IsRequired()
                    .HasMaxLength(2);

                entity.Property(e => e.Description).HasMaxLength(1000);

                entity.Property(e => e.FoundationDate).HasColumnType("date");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(40);
            });

            modelBuilder.Entity<Bandgenre>(entity =>
            {
                entity.HasKey(e => new { e.BandId, e.GenreId })
                    .HasName("PRIMARY");

                entity.ToTable("bandgenre");

                entity.HasIndex(e => e.GenreId)
                    .HasName("BandGenre_fk1");

                entity.HasOne(d => d.Band)
                    .WithMany(p => p.Bandgenre)
                    .HasForeignKey(d => d.BandId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("BandGenre_fk0");

                entity.HasOne(d => d.Genre)
                    .WithMany(p => p.Bandgenre)
                    .HasForeignKey(d => d.GenreId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("BandGenre_fk1");
            });

            modelBuilder.Entity<Composition>(entity =>
            {
                entity.ToTable("composition");

                entity.HasIndex(e => e.AlbumId)
                    .HasName("Composition_fk0");

                entity.HasIndex(e => e.BandId)
                    .HasName("Composition_fk1");

                entity.HasIndex(e => e.GenreId)
                    .HasName("Composition_fk2");

                entity.Property(e => e.Id).HasMaxLength(36);

                entity.Property(e => e.Description).HasMaxLength(500);

                entity.Property(e => e.Lyrics).HasMaxLength(300);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.Album)
                    .WithMany(p => p.Composition)
                    .HasForeignKey(d => d.AlbumId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Composition_fk0");

                entity.HasOne(d => d.Band)
                    .WithMany(p => p.Composition)
                    .HasForeignKey(d => d.BandId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Composition_fk1");

                entity.HasOne(d => d.Genre)
                    .WithMany(p => p.Composition)
                    .HasForeignKey(d => d.GenreId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Composition_fk2");
            });

            modelBuilder.Entity<Genre>(entity =>
            {
                entity.ToTable("genre");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(700);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(20);
            });

            modelBuilder.Entity<Reflection>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.CompositionId })
                    .HasName("PRIMARY");

                entity.ToTable("reflection");

                entity.HasIndex(e => e.CompositionId)
                    .HasName("Reflection_fk1");

                entity.Property(e => e.UserId).HasMaxLength(36);

                entity.Property(e => e.CompositionId).HasMaxLength(36);

                entity.Property(e => e.Feedback)
                    .IsRequired()
                    .HasMaxLength(1000);

                entity.HasOne(d => d.Composition)
                    .WithMany(p => p.Reflection)
                    .HasForeignKey(d => d.CompositionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Reflection_fk1");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Reflection)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Reflection_fk0");
            });

            modelBuilder.Entity<Selected>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.CompositionId })
                    .HasName("PRIMARY");

                entity.ToTable("selected");

                entity.HasIndex(e => e.CompositionId)
                    .HasName("Selected_fk1");

                entity.Property(e => e.UserId).HasMaxLength(36);

                entity.Property(e => e.CompositionId).HasMaxLength(36);

                entity.HasOne(d => d.Composition)
                    .WithMany(p => p.Selected)
                    .HasForeignKey(d => d.CompositionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Selected_fk1");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Selected)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Selected_fk0");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("user");

                entity.HasIndex(e => e.Email)
                    .HasName("Email")
                    .IsUnique();

                entity.HasIndex(e => e.Login)
                    .HasName("Login")
                    .IsUnique();

                entity.Property(e => e.Id).HasMaxLength(36);

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(120);

                entity.Property(e => e.Login)
                    .IsRequired()
                    .HasMaxLength(40);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(72);

                entity.Property(e => e.Role)
                    .IsRequired()
                    .HasMaxLength(15);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
