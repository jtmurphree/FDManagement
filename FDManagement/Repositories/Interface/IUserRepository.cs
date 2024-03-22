
namespace FDManagement.Repositories.Interface
{
    public interface IUserRepository
    {
        Task<Global_User> CreateAsync(Global_User user);
        Task<IEnumerable<Global_User>> GetAllAsync();
        Task<Global_User> GetById(int id);
        Task<IEnumerable<Global_UserRole>> GetRolesAsync();
        Task<IEnumerable<Global_RegisteredUserRole>> GetRegisteredRolesAsync();
        Task<Global_UserRole> CreateRoleAsync(Global_UserRole userRole);
        Task<Global_RegisteredUserRole> CreateRegisteredRoleAsync(Global_RegisteredUserRole userRole);
    }
}
