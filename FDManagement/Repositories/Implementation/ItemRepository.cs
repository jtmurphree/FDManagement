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
        public Task<Inventory_Item> Create(Inventory_Item item)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Inventory_Item>> GetAllAsync()
        {
            return await dbContext.Inventory_Items.ToListAsync();
        }

        public async Task<IEnumerable<Inventory_Category>> GetCategoriesAsync()
        {
            return await dbContext.Inventory_Categories.ToListAsync();
        }
    }
}
