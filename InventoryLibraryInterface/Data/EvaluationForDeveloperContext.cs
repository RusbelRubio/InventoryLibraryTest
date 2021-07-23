using InventoryLibrary.Core.Entities;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace InventoryLibrary.Infrastructure.Data
{
    public partial class EvaluationForDeveloperContext : DbContext
    {
        public EvaluationForDeveloperContext()
        {
        }

        public EvaluationForDeveloperContext(DbContextOptions<EvaluationForDeveloperContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Autores> Autores { get; set; }
        public virtual DbSet<AutoresHasLibro> AutoresHasLibros { get; set; }
        public virtual DbSet<Editoriale> Editoriales { get; set; }
        public virtual DbSet<Libro> Libros { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Modern_Spanish_CI_AS");

            modelBuilder.Entity<Autores>(entity =>
            {
                entity.ToTable("autores");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Apellidos)
                    .IsRequired()
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(45)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<AutoresHasLibro>(entity =>
            {
                entity.HasKey(e => new { e.AutoresId, e.LibrosIsbn });

                entity.ToTable("autores_has_libros");

                entity.Property(e => e.AutoresId).HasColumnName("autores_id");

                entity.Property(e => e.LibrosIsbn).HasColumnName("libros_ISBN");

                entity.HasOne(d => d.Autores)
                    .WithMany(p => p.AutoresHasLibros)
                    .HasForeignKey(d => d.AutoresId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_autores_has_libros_autores");

                entity.HasOne(d => d.LibrosIsbnNavigation)
                    .WithMany(p => p.AutoresHasLibros)
                    .HasForeignKey(d => d.LibrosIsbn)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_autores_has_libros_libros");
            });

            modelBuilder.Entity<Editoriale>(entity =>
            {
                entity.ToTable("editoriales");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(45)
                    .IsUnicode(false)
                    .HasColumnName("nombre");

                entity.Property(e => e.Sede)
                    .HasMaxLength(45)
                    .IsUnicode(false)
                    .HasColumnName("sede");
            });

            modelBuilder.Entity<Libro>(entity =>
            {
                entity.HasKey(e => e.Isbn);

                entity.ToTable("libros");

                entity.HasIndex(e => e.EditorialesId, "IX_libros_Editorial")
                    .IsUnique();

                entity.Property(e => e.Isbn)
                    .ValueGeneratedNever()
                    .HasColumnName("ISBN");

                entity.Property(e => e.EditorialesId).HasColumnName("editoriales_id");

                entity.Property(e => e.NPaginas)
                    .HasMaxLength(45)
                    .IsUnicode(false)
                    .HasColumnName("n_paginas");

                entity.Property(e => e.Sinopsis)
                    .HasColumnType("text")
                    .HasColumnName("sinopsis");

                entity.Property(e => e.Titulo)
                    .HasMaxLength(45)
                    .IsUnicode(false)
                    .HasColumnName("titulo");

                entity.HasOne(d => d.Editoriales)
                    .WithOne(p => p.Libro)
                    .HasForeignKey<Libro>(d => d.EditorialesId)
                    .HasConstraintName("FK_libros_editoriales");
            });
        }
    }
}
