using FDManagement.Repositories.Interface;
using Microsoft.EntityFrameworkCore;

namespace FDManagement.Repositories.Implementation
{
    public class ApparatusRepository : IApparatusRepository
    {
        private readonly ApplicaionDbContext dbContext;

        public ApparatusRepository(ApplicaionDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public Task<Vehicle_Apparatus> CreateAsync(Vehicle_Apparatus apparatus)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Vehicle_Apparatus>> GetAllAsync()
        {
            return await dbContext.Vehicle_Apparatus.Include(a => a.Vehicle_FuelType).Include(a => a.Vehicle_DriveType).Include(a => a.Vehicle_ApparatusType).ToListAsync();
        }

        public async Task<IEnumerable<Vehicle_DriveType>> GetDriveTypesAsync()
        {
            return await dbContext.Vehicle_DriveTypes.ToListAsync();
        }

        public async Task<IEnumerable<Vehicle_FuelType>> GetFuelTypesAsync()
        {
            return await dbContext.Vehicle_FuelTypes.ToListAsync();
        }

        public async Task<IEnumerable<Vehicle_ApparatusType>> GetTypesAsync()
        {
            return await dbContext.Vehicle_ApparatusTypes.ToListAsync();
        }
    }
}
