using Microsoft.EntityFrameworkCore;
using RestApiSample.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestApiSample.Models
{
    public class BookLibraryContext : DbContext
    {
        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }

        public BookLibraryContext(DbContextOptions<BookLibraryContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Author>().HasData(new Author
            {
                Id = Guid.Parse("48a103e8-e483-48a2-ae94-7a96af854cdb"),
                FirstName = "Victor Hugo",
                LastName = "Hogo"
            },
            new Author
            {
                Id = Guid.Parse("56b0a249-d3b9-4e6e-9ada-68c9cd37b427"),
                FirstName = "Lev",
                LastName = "Tolstoy"
            });

            modelBuilder.Entity<Book>().HasData(new Book
            {
                Id = Guid.Parse("d28888e9-2ba9-473a-a40f-e38cb54f9b35"),
                AuthorId = Guid.Parse("48a103e8-e483-48a2-ae94-7a96af854cdb"),
                Name = "Notre Dame'ın Kamburu"
            },
            new Book
            {
                Id = Guid.Parse("da2fd609-d754-4feb-8acd-c4f9ff13ba96"),
                AuthorId = Guid.Parse("48a103e8-e483-48a2-ae94-7a96af854cdb"),
                Name = "Sefiller"
            },
             new Book
             {
                 Id = Guid.Parse("2902b665-1190-4c70-9915-b9c2d7680450"),
                 AuthorId = Guid.Parse("56b0a249-d3b9-4e6e-9ada-68c9cd37b427"),
                 Name = "İnsan Ne İle Yaşar"
             },
              new Book
              {
                  Id = Guid.Parse("102b566b-ba1f-404c-b2df-e2cde39ade09"),
                  AuthorId = Guid.Parse("56b0a249-d3b9-4e6e-9ada-68c9cd37b427"),
                  Name = "Savaş ve Barış"
              }

            );

            base.OnModelCreating(modelBuilder);
        }

    }
}
