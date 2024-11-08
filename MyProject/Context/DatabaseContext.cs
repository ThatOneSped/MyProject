using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using MyProject.Model;
using System;

namespace MyProject.Context
{
    public class DatabaseContext : IdentityDbContext<User>
    {
        private IWebHostEnvironment _environment;

        public DatabaseContext(DbContextOptions<DatabaseContext> options, IWebHostEnvironment environment) : base(options)
        {
            _environment = environment;
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<FavouriteItem> FavouriteItems { get; set; }
        public DbSet<Chat> Chats { get; set; }
        public DbSet<Payment> Payments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Chat>(chat =>
            {
                chat.HasOne(chat => chat.To)
                    .WithMany(user => user.ReceivedChats)
                    .HasForeignKey(chat => chat.ToUserId)
                    .IsRequired()
                    .OnDelete(DeleteBehavior.Cascade);

                chat.HasOne(chat => chat.From)
                    .WithMany(user => user.SentChats)
                    .HasForeignKey(chat => chat.FromUserId)
                    .IsRequired()
                    .OnDelete(DeleteBehavior.Cascade);
            });
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionbuilder)
        {
            var folder = Path.Combine(_environment.WebRootPath, "database");
            if (!Directory.Exists(folder))
            {
                Directory.CreateDirectory(folder);
            }
            optionbuilder.UseSqlite($"Data Source={folder}/database.db");
        }
    }
}