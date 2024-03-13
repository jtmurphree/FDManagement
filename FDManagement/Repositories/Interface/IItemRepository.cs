namespace FDManagement.Repositories.Interface
{
    public interface IItemRepository
    {
        Task<Inventory_Item> Create(Inventory_Item item);
        Task<IEnumerable<Inventory_Item>> GetAllAsync();
        Task<IEnumerable<Inventory_Category>> GetCategoriesAsync();
    }
}
