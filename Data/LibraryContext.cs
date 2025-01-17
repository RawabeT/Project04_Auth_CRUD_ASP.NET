﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MVC_Final.Models;
using Microsoft.EntityFrameworkCore;
using System.Configuration;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace MVC_Final.Data
{
    public class LibraryContext : IdentityDbContext
    {
        public LibraryContext(DbContextOptions<LibraryContext> options) : base(options)
        {
           
        }

        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Publisher> Publishers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Author>()
                .HasMany(c => c.Books)
                .WithOne(e => e.Author)
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<Book>().Property(b => b.Price).HasColumnType("decimal(5,3)");

            modelBuilder.Entity<Publisher>()
                .HasMany(p => p.Books)
                .WithOne(b => b.Publisher)
                .OnDelete(DeleteBehavior.Cascade);

            base.OnModelCreating(modelBuilder);
        }
    }
}
