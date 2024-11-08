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

            if (!_context.Roles.Any())
            {
                await _roleManager.CreateAsync(new IdentityRole("Admin"));
                await _roleManager.CreateAsync(new IdentityRole("Seller"));
                await _roleManager.CreateAsync(new IdentityRole("Buyer"));
            }

            if (!_context.Users.Any())
            {
                var adminEmail = "admin@clothing.com";
                var adminPassword = "Clothes123!";

                var admin = new User
                {
                    UserName = adminEmail,
                    Email = adminEmail,
                    Name = "AdminUser",
                    Address = "London SW1A 1AA",
                };

               var result =  await _userManager.CreateAsync(admin, adminPassword);
                var roleresult = await _userManager.AddToRoleAsync(admin, "Admin");
            }

            if (!_context.Categories.Any())
            {
                var categories = new List<Category>
                {
                    new Category { CategoryName = "Jeans" },
                    new Category { CategoryName = "T-Shirts" },
                    new Category { CategoryName = "Jackets" },
                    new Category { CategoryName = "Shoes" },
                    new Category { CategoryName = "Accessories" },
                    new Category { CategoryName = "Trousers" }
                };

                _context.Categories.AddRange(categories);
                await _context.SaveChangesAsync();
            }

            if (!_context.Items.Any())
            {
                // retrieve existing category and user for item seeding
                var jeansCategory = _context.Categories.FirstOrDefault(c => c.CategoryName == "Jeans");
                var adminUser = _context.Users.FirstOrDefault(u => u.Email == "admin@clothing.com");

                if (jeansCategory != null && adminUser != null)
                {
                    var items = new List<Item>
                    {
                        new Item
                        {
                            ItemName = "Blue Denim Jeans",
                            ItemPrice = 59.99M,
                            ItemSize = "M",
                            Description = "Classic blue denim jeans.",
                            Category = jeansCategory, // Referencing existing category
                            User = adminUser, // Referencing existing user
                            ImageUrl = "https://example.com/blue-jeans.jpg"
                        },

                    };

                    _context.Items.AddRange(items);
                    await _context.SaveChangesAsync();
                }
            }
        }
    }
}