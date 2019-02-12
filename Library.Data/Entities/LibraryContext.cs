using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.Data.Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace Library.Data.Entities
{
    public class LibraryContext : DbContext
    {
        //objekt priko kojeg se povezujemo na bazu


        public DbSet<Author> Authors { get; set; }
        public DbSet<AuthorBook> AuthorBooks { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Loan> Loans { get; set; }
        public DbSet<Publisher> Publishers { get; set; }
        public DbSet<Student> Students { get; set; }

        //configuring many to many relations , Fluent Api
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(ConfigurationManager.ConnectionStrings["LibraryDatabase"].ConnectionString);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AuthorBook>()
                .HasOne(b => b.Book)
                .WithMany(ab => ab.AuthorsBooks)
                .HasForeignKey(b => b.BookId);
            modelBuilder.Entity<AuthorBook>()
                .HasOne(a => a.Author)
                .WithMany(ab => ab.AuthorBooks)
                .HasForeignKey(a => a.AuthorId);

            modelBuilder.Entity<Loan>()
                .HasOne(s => s.Student)
                .WithMany(l => l.Loans)
                .HasForeignKey(s => s.StudentId);
            modelBuilder.Entity<Loan>()
                .HasOne(b => b.Book)
                .WithMany(l => l.Loans)
                .HasForeignKey(b => b.BookId);


        }

    }
}
