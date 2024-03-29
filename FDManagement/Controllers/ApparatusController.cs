using Microsoft.AspNetCore.Mvc;
using FDManagement.Repositories.Interface;
using FDManagement.Models.DTO;

namespace FDManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApparatusController : ControllerBase
    {
        private readonly IApparatusRepository apparatusRepository;
        
        public ApparatusController(IApparatusRepository appRipository)
        {
            this.apparatusRepository = appRipository;
        }

        [HttpPost]
        public async Task<IActionResult> CreateApparatus(Vehicle_Apparatus apparatus)
        {
            apparatus.DateAdded = DateTime.Now;
            await apparatusRepository.CreateAsync(apparatus);

            var response = new ApparatusDto
            {
                UnitNum = apparatus.UnitNum,
                Make = apparatus.Make,
                Model = apparatus.Model,
                Year = apparatus.Year,
                Mileage = apparatus.Mileage,
                MileageDate = apparatus.MileageDate,
                ApparatusTypeID = apparatus.ApparatusTypeId,
                FuelTypeID = apparatus.FuelTypeId,
                DriveTypeID = apparatus.DriveTypeId,
                DateAdded = apparatus.DateAdded,
                DateUpdated = apparatus.DateUpdated
            };

            return Ok(apparatus);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllApparatus()
        {
            var apparatus = await apparatusRepository.GetAllAsync();
            var response = new List<ApparatusDto>();

            foreach(var app in apparatus)
            {
                response.Add(new ApparatusDto
                {
                    ID = app.Id,
                    UnitNum = app.UnitNum,
                    Make = app.Make,
                    Model = app.Model,
                    Year = app.Year,
                    Mileage = app.Mileage,
                    MileageDate = app.MileageDate,
                    ApparatusTypeID = app.ApparatusTypeId,
                    ApparatusType = app.Vehicle_ApparatusType.Name,
                    FuelTypeID = app.FuelTypeId,
                    FuelType = app.Vehicle_FuelType.Name,
                    DriveTypeID = app.DriveTypeId,
                    DriveType = app.Vehicle_DriveType.Name
                });
            }

            return Ok(response);
        }

        [HttpGet]
        [Route("types")]
        public async Task<IActionResult> GetTypes()
        {
            var types = await apparatusRepository.GetTypesAsync();
            var response = new List<ApparatusTypeDto>();

            foreach(var type in types)
            {
                response.Add(new ApparatusTypeDto
                {
                    ID = type.Id,
                    Name = type.Name,
                    Description = type.Description
                });
            }

            return Ok(response);
        }

        [HttpGet]
        [Route("fueltypes")]
        public async Task<IActionResult> GetFuelTypes()
        {
            var fuelTypes = await apparatusRepository.GetFuelTypesAsync();
            var response = new List<FuelTypeDto>();

            foreach(var fuelType in fuelTypes)
            {
                response.Add(new FuelTypeDto
                {
                    ID = fuelType.Id,
                    Name = fuelType.Name,
                    Description = fuelType.Description
                });
            }

            return Ok(response);  
        }


        [HttpGet]
        [Route("drivetypes")]
        public async Task<IActionResult> GetDriveTypes()
        {
            var driveTypes = await apparatusRepository.GetDriveTypesAsync();
            var response = new List<FuelTypeDto>();

            foreach (var drive in driveTypes)
            {
                response.Add(new FuelTypeDto
                {
                    ID = drive.Id,
                    Name = drive.Name,
                    Description = drive.Description
                });
            }

            return Ok(response);
        }

        [HttpPost]
        [Route("adddrivetype")]
        public async Task<IActionResult> CreateDriveType(Vehicle_DriveType drive)
        {
            await apparatusRepository.CreateDriveTypeAsync(drive);

            var response = new DriveTypeDto
            {
                ID = drive.Id,
                Name = drive.Name,
                Description = drive.Description
            };

            return Ok(response);
        }

        [HttpPost]
        [Route("addtype")]
        public async Task<IActionResult> CreateApparatusType(Vehicle_ApparatusType type)
        {
            await apparatusRepository.CreateApparatusTypeAsync(type);

            var response = new ApparatusTypeDto
            {
                ID = type.Id,
                Name = type.Name,
                Description = type.Description
            };

            return Ok(response);
        }

        [HttpPost]
        [Route("addfueltype")]
        public async Task<IActionResult> CreateFuelType(Vehicle_FuelType fuelType)
        {
            await apparatusRepository.CreateFuelTypeAsync(fuelType);

            var response = new FuelTypeDto
            {
                ID = fuelType.Id,
                Name = fuelType.Name,
                Description = fuelType.Description
            };

            return Ok(response);
        }
    }
}
