using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Scaffolding.Internal;

namespace Dag1.Infrastructure;

public partial class DbpDag1Context : DbContext
{
    public DbpDag1Context()
    {
    }

    public DbpDag1Context(DbContextOptions<DbpDag1Context> options)
        : base(options)
    {
    }

    public virtual DbSet<Author> Authors { get; set; }

    public virtual DbSet<Book> Books { get; set; }

    public virtual DbSet<Bookshelf> Bookshelves { get; set; }

    public virtual DbSet<Format> Formats { get; set; }

    public virtual DbSet<Genre> Genres { get; set; }

    public virtual DbSet<Publisher> Publishers { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySql("server=127.0.0.1;port=3306;user=root;password=Passw0rd;database=dbp_dag1", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.46-mysql"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_0900_ai_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<Author>(entity =>
        {
            entity.HasKey(e => e.Author1).HasName("PRIMARY");

            entity.ToTable("authors");

            entity.Property(e => e.Author1).HasColumnName("Author");
            entity.Property(e => e.Nationality).HasMaxLength(255);
        });

        modelBuilder.Entity<Book>(entity =>
        {
            entity.HasKey(e => e.Isbn).HasName("PRIMARY");

            entity.ToTable("books");

            entity.HasIndex(e => e.Author, "fk_author");

            entity.HasIndex(e => e.GenreId, "fk_genre_id");

            entity.HasIndex(e => e.Publisher, "fk_publisher");

            entity.Property(e => e.Isbn).HasColumnName("ISBN");
            entity.Property(e => e.GenreId).HasColumnName("Genre_id");
            entity.Property(e => e.Title).HasMaxLength(255);

            entity.HasOne(d => d.AuthorNavigation).WithMany(p => p.Books)
                .HasForeignKey(d => d.Author)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_author");

            entity.HasOne(d => d.Genre).WithMany(p => p.Books)
                .HasForeignKey(d => d.GenreId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_genre_id");

            entity.HasOne(d => d.PublisherNavigation).WithMany(p => p.Books)
                .HasForeignKey(d => d.Publisher)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_publisher");
        });

        modelBuilder.Entity<Bookshelf>(entity =>
        {
            entity.HasKey(e => e.BookId).HasName("PRIMARY");

            entity.ToTable("bookshelf");

            entity.HasIndex(e => e.BorrowedBy, "fk_borrowed_by");

            entity.HasIndex(e => e.FormatId, "fk_format_id");

            entity.HasIndex(e => e.Isbn, "fk_isbn");

            entity.Property(e => e.BookId).HasColumnName("Book_id");
            entity.Property(e => e.BorrowedBy).HasColumnName("Borrowed_by");
            entity.Property(e => e.FormatId).HasColumnName("Format_id");
            entity.Property(e => e.Isbn).HasColumnName("ISBN");

            entity.HasOne(d => d.BorrowedByNavigation).WithMany(p => p.Bookshelves)
                .HasForeignKey(d => d.BorrowedBy)
                .HasConstraintName("fk_borrowed_by");

            entity.HasOne(d => d.Format).WithMany(p => p.Bookshelves)
                .HasForeignKey(d => d.FormatId)
                .HasConstraintName("fk_format_id");

            entity.HasOne(d => d.IsbnNavigation).WithMany(p => p.Bookshelves)
                .HasForeignKey(d => d.Isbn)
                .HasConstraintName("fk_isbn");
        });

        modelBuilder.Entity<Format>(entity =>
        {
            entity.HasKey(e => e.FormatId).HasName("PRIMARY");

            entity.ToTable("formats");

            entity.Property(e => e.FormatId).HasColumnName("Format_id");
            entity.Property(e => e.Name).HasMaxLength(255);
        });

        modelBuilder.Entity<Genre>(entity =>
        {
            entity.HasKey(e => e.GenreId).HasName("PRIMARY");

            entity.ToTable("genres");

            entity.Property(e => e.GenreId).HasColumnName("Genre_id");
            entity.Property(e => e.Name).HasMaxLength(255);
        });

        modelBuilder.Entity<Publisher>(entity =>
        {
            entity.HasKey(e => e.Publisher1).HasName("PRIMARY");

            entity.ToTable("publishers");

            entity.Property(e => e.Publisher1).HasColumnName("Publisher");
            entity.Property(e => e.Country).HasMaxLength(255);
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PRIMARY");

            entity.ToTable("users");

            entity.HasIndex(e => e.Email, "Email").IsUnique();

            entity.Property(e => e.UserId).HasColumnName("User_id");
            entity.Property(e => e.Name).HasMaxLength(255);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
