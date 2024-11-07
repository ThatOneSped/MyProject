using Microsoft.AspNetCore.Components.Web.Virtualization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MyProject.Model;

namespace MyProject.Context
{
    public class DatabaseSeeder
    {
        private readonly DatabaseContext _context;
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public DatabaseSeeder(DatabaseContext context, UserManager<User> userManager, RoleManager<IdentityRole> roleManager)
        {
            _context = context;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task Seed()
        {
            await _context.Database.MigrateAsync();

            if (!_context.Users.Any())
            {
                await _roleManager.CreateAsync(new IdentityRole("Admin"));
                await _roleManager.CreateAsync(new IdentityRole("Seller"));
                await _roleManager.CreateAsync(new IdentityRole("Buyer"));

                var adminEmail = "admin@clothing.com";
                var adminPassword = "Clothes123";

                var admin = new User
                {
                    UserName = adminEmail,
                    Email = adminEmail,
                    Name = "AdminUser",
                    Address = "London SW1A 1AA",

                };

                await _userManager.CreateAsync(admin, adminPassword);
                await _userManager.AddToRoleAsync(admin, "Admin");
            }

            if (!_context.Items.Any())
            {
                var items = GetItems();
                _context.Items.AddRange(items);
                await _context!.SaveChangesAsync();
            }
        }

        private List<Item> GetItems()
        {
            return
            [
                new Item { ItemName = "Placeholder", ItemPrice = 999.99M, ItemSize = "L", Description = "Placeholder", Category = new Category { CategoryName = "Placeholder" } }
            ];
        }
    }
}