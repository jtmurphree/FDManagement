
namespace FDManagement.Repositories.Interface
{
    public interface IUserRepository
    {
        Task<Global_User> CreateAsync(Global_User user);
        Task<IEnumerable<Global_User>> GetAllAsync();
    }
}
