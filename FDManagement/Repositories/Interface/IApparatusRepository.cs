namespace FDManagement.Repositories.Interface
{
    public interface IApparatusRepository
    {
        Task<Vehicle_Apparatus> CreateAsync(Vehicle_Apparatus apparatus);
        Task<IEnumerable<Vehicle_Apparatus>> GetAllAsync();
        Task<IEnumerable<Vehicle_ApparatusType>> GetTypesAsync();
        Task<IEnumerable<Vehicle_FuelType>> GetFuelTypesAsync();
        Task<IEnumerable<Vehicle_DriveType>> GetDriveTypesAsync();
    }
}
