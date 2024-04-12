namespace FDManagement.Repositories.Interface
{
    public interface IApparatusRepository
    {
        Task<Vehicle_Apparatus> CreateAsync(Vehicle_Apparatus apparatus);
        Task<Vehicle_Apparatus?> UpdateAsync(Vehicle_Apparatus apparatus);
        Task<Vehicle_Apparatus?> DeleteAsync(int id);
        Task<Vehicle_DriveType> CreateDriveTypeAsync(Vehicle_DriveType driveType);
        Task<Vehicle_ApparatusType> CreateApparatusTypeAsync(Vehicle_ApparatusType apparatusType);
        Task<Vehicle_FuelType> CreateFuelTypeAsync(Vehicle_FuelType fuelType);
        Task<Vehicle_FuelType?> UpdateFuelTypeAsync(Vehicle_FuelType fuelType);
        Task<Vehicle_FuelType?> DeleteFuelTypeAsync(int id);
        Task<Vehicle_ApparatusType?> UpdateApparatusTypeAsync(Vehicle_ApparatusType type);
        Task<Vehicle_ApparatusType?> DeleteApparatusTypeAsync(int id);
        Task<Vehicle_DriveType?> UpdateDriveTypeAsync(Vehicle_DriveType driveType);
        Task<Vehicle_DriveType?> DeleteDriveTypeAsync(int id);
        Task<IEnumerable<Vehicle_Apparatus>> GetAllAsync();
        Task<IEnumerable<Vehicle_ApparatusType>> GetTypesAsync();
        Task<IEnumerable<Vehicle_FuelType>> GetFuelTypesAsync();
        Task<IEnumerable<Vehicle_DriveType>> GetDriveTypesAsync();
    }
}
