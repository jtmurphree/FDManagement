namespace FDManagement.Repositories.Interface
{
    public interface IItemRepository
    {
        Task<Inventory_Item> CreateAsync(Inventory_Item item);
        Task<Inventory_Item?> UpdateAsync(Inventory_Item item);
        Task<Inventory_Item?> DeleteAsync(int id);
        Task<Inventory_Item?> GetAsync(int id);
        Task<Inventory_Category> CreatCategoryAsync(Inventory_Category category);
        Task<Inventory_Category?> UpdateCategoryAsync(Inventory_Category category);
        Task<Inventory_Category?> DeleteCategoryAsync(int id);
        Task<Inventory_Category?> GetCategoryAsync(int id);
        Task<IEnumerable<Inventory_Item>> GetAllAsync();
        Task<IEnumerable<Inventory_Category>> GetCategoriesAsync();
    }
}
