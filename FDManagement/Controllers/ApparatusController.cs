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
            await apparatusRepository.CreateAsync(apparatus);
            //implement dto?
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
                    ApparatusType = app.ApparatusType,
                    FuelType = app.FuelType,
                    DriveType = app.DriveType
                });
            }

            return Ok(response);
        }

        [HttpGet]
        [Route("api/[controller]/types")]
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
        [Route("api/[controller]/FuelTypes")]
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
        [Route("api/[controller]/DriveTypes")]
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
    }
}
