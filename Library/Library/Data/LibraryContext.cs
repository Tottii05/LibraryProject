using Microsoft.EntityFrameworkCore;
using Library.Models;
namespace Library.Data
{
    public class LibraryContext : DbContext
    {
        public LibraryContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Book> Books { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Loan> Loans { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Book>(entity =>
            {
                entity.ToTable("books");      
                entity.Property(e => e.Id).HasColumnName("id");
                entity.Property(e => e.Title).HasColumnName("title");
                entity.Property(e => e.Author).HasColumnName("author");
                entity.Property(e => e.Category).HasColumnName("category");
                entity.Property(e => e.BookType).HasColumnName("booktype");
                entity.Property(e => e.Volume).HasColumnName("volume");
                entity.Property(e => e.Available).HasColumnName("available");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("users");
                entity.Property(e => e.Id).HasColumnName("id");
                entity.Property(e => e.Name).HasColumnName("name");
                entity.Property(e => e.Email).HasColumnName("email");
                entity.Property(e => e.Phone).HasColumnName("phone");
                entity.Property(e => e.Password).HasColumnName("password");
            });

            modelBuilder.Entity<Loan>(entity =>
            {
                entity.ToTable("loans");
                entity.Property(e => e.Id).HasColumnName("id");
                entity.Property(e => e.UserId).HasColumnName("userid");
                entity.Property(e => e.BookId).HasColumnName("bookid");
                entity.Property(e => e.LoanDate).HasColumnName("loandate");
                entity.Property(e => e.ReturnDate).HasColumnName("returndate");
            });
        }
    }
}
