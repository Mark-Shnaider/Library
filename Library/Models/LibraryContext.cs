using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Library.Models
{
    public class LibraryContext : DbContext
    {
        public DbSet<Book> Books { get; set; }
        public DbSet<Reader> Readers { get; set; }
        public DbSet<Copy> Copies { get; set; }
        public LibraryContext(DbContextOptions<LibraryContext> options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Reader>().ToTable("Reader");
            modelBuilder.Entity<Book>().ToTable("Book");
            modelBuilder.Entity<Copy>().ToTable("Copy");
        }
    }
}
