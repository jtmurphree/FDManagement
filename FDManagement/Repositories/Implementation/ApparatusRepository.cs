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

        public async Task<Vehicle_Apparatus> CreateAsync(Vehicle_Apparatus apparatus)
        {
            await dbContext.Vehicle_Apparatus.AddAsync(apparatus);
            await dbContext.SaveChangesAsync();
            return apparatus;
        }

        public async Task<Vehicle_DriveType> CreateDriveTypeAsync(Vehicle_DriveType driveType)
        {
            await dbContext.Vehicle_DriveTypes.AddAsync(driveType);
            await dbContext.SaveChangesAsync();
            return driveType;
        }

        public async Task<Vehicle_ApparatusType> CreateApparatusTypeAsync(Vehicle_ApparatusType type)
        {
            await dbContext.Vehicle_ApparatusTypes.AddAsync(type);
            await dbContext.SaveChangesAsync();
            return type;
        }

        public async Task<Vehicle_FuelType> CreateFuelTypeAsync(Vehicle_FuelType fuel)
        {
            await dbContext.Vehicle_FuelTypes.AddAsync(fuel);
            await dbContext.SaveChangesAsync();
            return fuel;
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

        public async Task<Vehicle_Apparatus?> UpdateAsync(Vehicle_Apparatus apparatus)
        {
            var existingApparatus = dbContext.Vehicle_Apparatus.Where(x => x.Id == apparatus.Id).FirstOrDefaultAsync();

            if(existingApparatus != null)
            {
                dbContext.Entry(existingApparatus).CurrentValues.SetValues(apparatus);
                await dbContext.SaveChangesAsync();
                return apparatus;
            }

            return null;
        }

        public Task<Vehicle_Apparatus?> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Vehicle_FuelType?> UpdateFuelTypeAsync(Vehicle_FuelType fuelType)
        {
            throw new NotImplementedException();
        }

        public Task<Vehicle_FuelType?> DeleteFuelTypeAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Vehicle_ApparatusType?> UpdateApparatusTypeAsync(Vehicle_ApparatusType type)
        {
            throw new NotImplementedException();
        }

        public Task<Vehicle_ApparatusType?> DeleteApparatusTypeAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Vehicle_DriveType?> UpdateDriveTypeAsync(Vehicle_DriveType driveType)
        {
            throw new NotImplementedException();
        }

        public Task<Vehicle_DriveType?> DeleteDriveTypeAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
