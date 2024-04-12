using FDManagement.Repositories.Interface;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc.Routing;
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

        public async Task<Global_User?> UpdateUserAsync(Global_User user)
        {
            var existingUser = await dbContext.Global_Users.FirstOrDefaultAsync(x => x.Id == user.Id);

            if (existingUser != null)
            {
                dbContext.Entry(existingUser).CurrentValues.SetValues(user);
                await dbContext.SaveChangesAsync();
                return user;
            }

            return null;
        }

        public async Task<Global_User?> DeleteUserAsync(int id)
        {
            var existingUser = await dbContext.Global_Users.Include(u => u.Global_RegisteredUserRoles).Include(u => u.Global_RegisteredUserRole.Global_UserRole).FirstOrDefaultAsync(x => x.Id == id);

            if (existingUser is null) 
            {
                return null;
            }
            
            dbContext.Global_Users.Remove(existingUser);
            await dbContext.SaveChangesAsync();
            return existingUser;
        }

        public async Task<Global_UserRole?> UpdateRoleAsync(Global_UserRole role)
        {
            var existingRole = dbContext.Global_UserRoles.Where(x => x.Id == role.Id).FirstOrDefault();

            if(existingRole != null)
            {
                dbContext.Entry(existingRole).CurrentValues.SetValues(role);
                await dbContext.SaveChangesAsync();
                return role;
            }

            return null;
        }

        public async Task<Global_UserRole?> DeleteRoleAsync(int id)
        {
            var existingRole = dbContext.Global_UserRoles.Where(x => x.Id == id).FirstOrDefault();

            if(existingRole is null)
            {
                return null;
            }

            dbContext.Global_UserRoles.Remove(existingRole);
            await dbContext.SaveChangesAsync();
            return existingRole;
        }
    }
}
