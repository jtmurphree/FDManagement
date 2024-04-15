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

        public async Task<Inventory_Item?> DeleteAsync(int id)
        {
            var existingItem = await dbContext.Inventory_Items.Include(x => x.Inventory_Category).FirstOrDefaultAsync(x => x.Id == id);

            if(existingItem == null)
            {
                return null;
            }

            dbContext.Inventory_Items.Remove(existingItem);
            await dbContext.SaveChangesAsync();
            return existingItem;
        }

        public async Task<Inventory_Category?> DeleteCategoryAsync(int id)
        {
            var existingCategory = await dbContext.Inventory_Categories.FirstOrDefaultAsync(x => x.Id == id);

            if(existingCategory == null)
            {
                return null;
            }

            dbContext.Inventory_Categories.Remove(existingCategory);
            await dbContext.SaveChangesAsync();
            return existingCategory;
        }

        public async Task<IEnumerable<Inventory_Item>> GetAllAsync()
        {
            return await dbContext.Inventory_Items.Include(i => i.Inventory_Category).ToListAsync();
        }

        public async Task<Inventory_Item?> GetAsync(int id)
        {
            var item = await dbContext.Inventory_Items.Include(c => c.Inventory_Category).FirstOrDefaultAsync(x => x.Id ==id);

            if(item == null)
            {
                return null;
            }

            return item;
        }

        public async Task<IEnumerable<Inventory_Category>> GetCategoriesAsync()
        {
            return await dbContext.Inventory_Categories.ToListAsync();
        }

        public async Task<Inventory_Category?> GetCategoryAsync(int id)
        {
            var category = await dbContext.Inventory_Categories.FirstOrDefaultAsync(x => x.Id == id);

            if(category == null)
            {
                return null;
            }

            return category;
        }

        public async Task<Inventory_Item?> UpdateAsync(Inventory_Item item)
        {
            var existingItem = await dbContext.Inventory_Items.Include(c => c.Inventory_Category).FirstOrDefaultAsync(x => x.Id == item.Id);

            if(existingItem == null)
            {
                return null;
            }

            dbContext.Entry(existingItem).CurrentValues.SetValues(item);
            await dbContext.SaveChangesAsync();
            return existingItem;
        }

        public async Task<Inventory_Category?> UpdateCategoryAsync(Inventory_Category category)
        {
            var existingCategory = await dbContext.Inventory_Categories.FirstOrDefaultAsync(x => x.Id == category.Id);

            if(existingCategory == null)
            {
                return null;
            }

            dbContext.Entry(existingCategory).CurrentValues.SetValues(category);
            await dbContext.SaveChangesAsync();
            return existingCategory;
        }
    }
}
