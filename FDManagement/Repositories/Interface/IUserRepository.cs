
namespace FDManagement.Repositories.Interface
{
    public interface IUserRepository
    {
        Task<Global_User> CreateAsync(Global_User user);
        Task<IEnumerable<Global_User>> GetAllAsync();
        Task<Global_User?> GetUserByIdAsync(int id);
        Task<IEnumerable<Global_UserRole>> GetRolesAsync();
        Task<IEnumerable<Global_RegisteredUserRole>> GetRegisteredRolesAsync();
        Task<Global_UserRole> CreateRoleAsync(Global_UserRole userRole);
        Task<Global_RegisteredUserRole> CreateRegisteredRoleAsync(Global_RegisteredUserRole userRole);
        Task<Global_User?> UpdateUserAsync(Global_User user);
        Task<Global_User?> DeleteUserAsync(int id);
        Task<Global_UserRole?> UpdateRoleAsync(Global_UserRole role);
        Task<Global_UserRole?> DeleteRoleAsync(int id);
    }
}
