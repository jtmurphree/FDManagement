using FDManagement.Repositories.Interface;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace FDManagement.Repositories.Implementation
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicaionDbContext dbContext;

        public UserRepository(ApplicaionDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<Global_User> CreateAsync(Global_User user)
        {
            await dbContext.Global_Users.AddAsync(user);
            await dbContext.SaveChangesAsync();
            return user;
        }

        public async Task<Global_RegisteredUserRole> CreateRegisteredRoleAsync(Global_RegisteredUserRole userRole)
        {
            await dbContext.Global_RegisteredUserRoles.AddAsync(userRole);
            await dbContext.SaveChangesAsync();
            return userRole;
        }

        public async Task<Global_UserRole> CreateRoleAsync(Global_UserRole userRole)
        {
            await dbContext.Global_UserRoles.AddAsync(userRole);
            await dbContext.SaveChangesAsync();
            return userRole;
        }

        public async Task<IEnumerable<Global_User>> GetAllAsync()
        {
            return await dbContext.Global_Users.Include(u => u.Global_RegisteredUserRole.Global_UserRole).ToListAsync();
        }

        public async Task<Global_User?> GetUserById(int id)
        {
            var user = await dbContext.Global_Users.Include(u => u.Global_RegisteredUserRoles).Include(v => v.Global_RegisteredUserRole.Global_UserRole).FirstOrDefaultAsync(x => x.Id == id);
            
            if(user == null)
            {
                user = new Global_User();
            }

            return user;
        }

        public async Task<IEnumerable<Global_RegisteredUserRole>> GetRegisteredRolesAsync()
        {
            return await dbContext.Global_RegisteredUserRoles.ToListAsync();
        }

        public async Task<IEnumerable<Global_UserRole>> GetRolesAsync()
        {
            return await dbContext.Global_UserRoles.ToListAsync();
        }
    }
}
