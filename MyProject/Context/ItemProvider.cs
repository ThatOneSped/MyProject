using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MyProject.Model;

namespace MyProject.Context

{
    public class ItemProvider
    {
        private readonly DatabaseContext _context; //dependency injection for dbcontext

        public ItemProvider(DatabaseContext context)
        {
            _context = context;
        }

        public async Task<List<Item>> GetItemsAsync() //method to get all items and their category
        {
            return await _context.Items.Include(i => i.Category).ToListAsync();
        }

        public async Task<Item?> GetItemByIdAsync(int id) //method to get an item and its category by its items ID
        {
            return await _context.Items.Include(i => i.Category).FirstOrDefaultAsync(i => i.ID == id);
        }

        public async Task AddItemAsync(Item item) //method to create an item to the database
        {
            _context.Items.Add(item);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteItemAsync(int id) //method to delete item from database
        {
            var item = await _context.Items.FindAsync(id);
            if (item != null)
            {
                _context.Items.Remove(item);
                await _context.SaveChangesAsync();
            }
        }

        public async Task EditItemAsync(Item item) //method to edit item
        {
            _context.Items.Update(item);
            await _context.SaveChangesAsync();
        }
    }
}
