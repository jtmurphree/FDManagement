using FDManagement.Repositories.Interface;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata.Ecma335;

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

        public async Task<Vehicle_Apparatus?> DeleteAsync(int id)
        {
            var existingApp = await dbContext.Vehicle_Apparatus.FirstOrDefaultAsync(x => x.Id == id);

            if (existingApp is null)
            {
                return null;
            }

            dbContext.Vehicle_Apparatus.Remove(existingApp);
            await dbContext.SaveChangesAsync();
            return existingApp;
        }

        public async Task<Vehicle_FuelType?> UpdateFuelTypeAsync(Vehicle_FuelType fuelType)
        {
            var existingFuelType = await dbContext.Vehicle_FuelTypes.FirstOrDefaultAsync(x => x.Id == fuelType.Id);

            if (existingFuelType == null)
            {
                return null;
            }

            dbContext.Entry(existingFuelType).CurrentValues.SetValues(fuelType);
            await dbContext.SaveChangesAsync();
            return fuelType;
        }

        public async Task<Vehicle_FuelType?> DeleteFuelTypeAsync(int id)
        {
            var existingFuelType = await dbContext.Vehicle_FuelTypes.FirstOrDefaultAsync(x => x.Id == id);

            if(existingFuelType == null)
            {
                return null;
            }

            dbContext.Vehicle_FuelTypes.Remove(existingFuelType);
            await dbContext.SaveChangesAsync();
            return existingFuelType;
        }

        public async Task<Vehicle_ApparatusType?> UpdateApparatusTypeAsync(Vehicle_ApparatusType type)
        {
            var existingType = await dbContext.Vehicle_ApparatusTypes.FirstOrDefaultAsync(x => x.Id == type.Id);

            if (existingType == null)
            {
                return null;
            }

            dbContext.Entry(existingType).CurrentValues.SetValues(type);
            await dbContext.SaveChangesAsync();
            return existingType;
            
        }

        public async Task<Vehicle_ApparatusType?> DeleteApparatusTypeAsync(int id)
        {
            var existingType = await dbContext.Vehicle_ApparatusTypes.FirstOrDefaultAsync(x => x.Id == id);

            if(existingType == null)
            {
                return null;
            }

            dbContext.Vehicle_ApparatusTypes.Remove(existingType);
            await dbContext.SaveChangesAsync();
            return existingType;
        }

        public async Task<Vehicle_DriveType?> UpdateDriveTypeAsync(Vehicle_DriveType driveType)
        {
            var existingDriveType = await dbContext.Vehicle_DriveTypes.FirstOrDefaultAsync(x => x.Id == driveType.Id);        
            
            if(existingDriveType == null)
            {
                return null;
            }

            dbContext.Entry(existingDriveType).CurrentValues.SetValues(driveType);
            await dbContext.SaveChangesAsync();
            return existingDriveType;
        }

        public async Task<Vehicle_DriveType?> DeleteDriveTypeAsync(int id)
        {
            var existingDriveType = await dbContext.Vehicle_DriveTypes.FirstOrDefaultAsync(x => x.Id == id);

            if(existingDriveType == null)
            {
                return null;
            }

            dbContext.Vehicle_DriveTypes.Remove(existingDriveType);
            await dbContext.SaveChangesAsync();
            return existingDriveType;
        }

        public async Task<Vehicle_Apparatus?> GetByIdAsync(int id)
        {
            var apparatus = await dbContext.Vehicle_Apparatus.Include(d => d.Vehicle_DriveType).Include(t => t.Vehicle_ApparatusType).Include(f => f.Vehicle_FuelType).FirstOrDefaultAsync(x => x.Id == id);

            if(apparatus == null)
            {
                return null;
            }

            return apparatus;
        }

        public async Task<Vehicle_ApparatusType?> GetTypeByIdAsync(int id)
        {
            var type = await dbContext.Vehicle_ApparatusTypes.FirstOrDefaultAsync(x => x.Id == id);

            if(type == null)
            {
                return null;
            }

            return type;
        }

        public async Task<Vehicle_FuelType?> GetFuelTypeByIdAsync(int id)
        {
            var fuelType = await dbContext.Vehicle_FuelTypes.FirstOrDefaultAsync(x => x.Id == id);

            if(fuelType == null)
            {
                return null;
            }

            return fuelType;
        }
    }
}
