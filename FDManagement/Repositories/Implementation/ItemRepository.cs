using FDManagement.Repositories.Interface;
using Microsoft.EntityFrameworkCore;

namespace FDManagement.Repositories.Implementation
{
    public class ItemRepository : IItemRepository
    {
        private readonly ApplicaionDbContext dbContext;

        public ItemRepository(ApplicaionDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<Inventory_Category> CreatCategoryAsync(Inventory_Category category)
        {
            await dbContext.Inventory_Categories.AddAsync(category);
            await dbContext.SaveChangesAsync();
            return category;
        }

        public async Task<Inventory_Item> CreateAsync(Inventory_Item item)
        {
            await dbContext.Inventory_Items.AddAsync(item);
            await dbContext.SaveChangesAsync();
            return item;
        }

        public async Task<IEnumerable<Inventory_Item>> GetAllAsync()
        {
            return await dbContext.Inventory_Items.Include(i => i.Inventory_Category).ToListAsync();
        }

        public async Task<IEnumerable<Inventory_Category>> GetCategoriesAsync()
        {
            return await dbContext.Inventory_Categories.ToListAsync();
        }
    }
}
