using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MyProject.Model;
using System;

namespace MyProject.Context
{
    public class DatabaseContext : IdentityDbContext<User>
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<FavouriteItem> FavouriteItems { get; set; }
        public DbSet<Chat> Chats { get; set; }
        public DbSet<Payment> Payments { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionbuilder)
        {
            var folder = Environment.SpecialFolder.MyDocuments;
            var path = Environment.GetFolderPath(folder);
            var dbPath = Path.Join(path, "database.db");
            optionbuilder.UseSqlite($"Data Source={dbPath}");
        }

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
    }
}
