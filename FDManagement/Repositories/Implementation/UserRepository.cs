//using FDManagement.Models.Domain;
using FDManagement.Repositories.Interface;
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

        public async Task<IEnumerable<Global_User>> GetAllAsync()
        {
            var users = await dbContext.Global_Users.ToListAsync();
            return users;
        }
    }
}
