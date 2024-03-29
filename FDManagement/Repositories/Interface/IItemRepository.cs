namespace FDManagement.Repositories.Interface
{
    public interface IItemRepository
    {
        Task<Inventory_Item> CreateAsync(Inventory_Item item);
        Task<Inventory_Category> CreatCategoryAsync(Inventory_Category category);
        Task<IEnumerable<Inventory_Item>> GetAllAsync();
        Task<IEnumerable<Inventory_Category>> GetCategoriesAsync();
    }
}
