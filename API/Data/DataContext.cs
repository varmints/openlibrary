using API.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<AppUser> Users { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Reservation> Reservations { get; set; }

                protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Reservation>()
                .HasKey(k => new {k.SourceUserId, k.ReservedBookId});

            builder.Entity<Reservation>()
                .HasOne(s => s.SourceUser)
                .WithMany(l => l.ReservedBooks)
                .HasForeignKey(s => s.SourceUserId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<Reservation>()
                .HasOne(s => s.ReservedBook)
                .WithMany(l => l.ReservedByUsers)
                .HasForeignKey(s => s.ReservedBookId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}