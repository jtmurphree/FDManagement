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
        public async Task<IActionResult> CreateApparatus(ApparatusRequestDto apparatusDto)
        {
            var apparatus = new Vehicle_Apparatus
            {
                UnitNum = apparatusDto.UnitNum,
                Make = apparatusDto.Make,
                Model = apparatusDto.Model,
                Year = apparatusDto.Year,
                Mileage = apparatusDto.Mileage,
                MileageDate = apparatusDto.MileageDate,
                ApparatusTypeId = apparatusDto.ApparatusTypeID,
                FuelTypeId = apparatusDto.FuelTypeID,
                DriveTypeId = apparatusDto.DriveTypeID,
                DateAdded = DateTime.Now,
                DateUpdated = null
            };

            apparatus.DateAdded = DateTime.Now;

            await apparatusRepository.CreateAsync(apparatus);

            var response = new ApparatusDto
            {
                ID = apparatus.Id,
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
                    DriveType = app.Vehicle_DriveType.Name,
                    DateAdded = app.DateAdded,
                    DateUpdated = app.DateUpdated
                });
            }

            return Ok(response);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetApparatusById([FromRoute] int id)
        {
            var apparatus = await apparatusRepository.GetByIdAsync(id);

            if(apparatus == null)
            {
                return NotFound();
            }

            var response = new ApparatusDto
            {
                ID = apparatus.Id,
                UnitNum = apparatus.UnitNum,
                Make = apparatus.Make,
                Model = apparatus.Model,
                Year = apparatus.Year,
                Mileage = apparatus.Mileage,
                MileageDate = apparatus.MileageDate,
                ApparatusTypeID = apparatus.ApparatusTypeId,
                ApparatusType = apparatus.Vehicle_ApparatusType.Name,
                FuelTypeID = apparatus.FuelTypeId,
                FuelType = apparatus.Vehicle_FuelType.Name,
                DriveTypeID = apparatus.DriveTypeId,
                DriveType = apparatus.Vehicle_DriveType.Name,
                DateAdded = apparatus.DateAdded,
                DateUpdated = apparatus.DateUpdated
            };

            return Ok(response);
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> UpdateApparatus([FromRoute] int id, ApparatusDto apparatusDto)
        {
            var apparatus = new Vehicle_Apparatus
            {
                Id = id,
                UnitNum = apparatusDto.UnitNum,
                Model = apparatusDto.Model,
                Make = apparatusDto.Make,
                Year = apparatusDto.Year,
                Mileage = apparatusDto.Mileage,
                MileageDate = apparatusDto.MileageDate,
                ApparatusTypeId = apparatusDto.ApparatusTypeID,
                FuelTypeId = apparatusDto.FuelTypeID,
                DriveTypeId = apparatusDto.DriveTypeID,
                DateAdded = apparatusDto.DateAdded,
                DateUpdated = apparatusDto.DateUpdated
            };

            apparatus = await apparatusRepository.UpdateAsync(apparatus);

            if(apparatus == null)
            {
                return NotFound();
            }

            var response = new ApparatusDto
            {
                ID = apparatus.Id,
                UnitNum = apparatus.UnitNum,
                Make = apparatus.Make,
                Model = apparatus.Model,
                Year = apparatus.Year,
                Mileage = apparatus.Mileage,
                MileageDate = apparatus.MileageDate,
                ApparatusTypeID = apparatus.ApparatusTypeId,
                ApparatusType = apparatus.Vehicle_ApparatusType.Name,
                FuelTypeID = apparatus.FuelTypeId,
                FuelType = apparatus.Vehicle_FuelType.Name,
                DriveTypeID = apparatus.DriveTypeId,
                DriveType = apparatus.Vehicle_DriveType.Name,
                DateAdded = apparatus.DateAdded,
                DateUpdated = apparatus.DateUpdated
            };

            return Ok(response);
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteApparatus(int id)
        {
            var apparatus = await apparatusRepository.DeleteAsync(id);

            if(apparatus == null)
            {
                return NotFound();
            }

            var response = new ApparatusDto
            {
                ID = apparatus.Id,
                UnitNum = apparatus.UnitNum,
                Make = apparatus.Make,
                Model = apparatus.Model,
                Year = apparatus.Year,
                Mileage = apparatus.Mileage,
                MileageDate = apparatus.MileageDate,
                ApparatusTypeID = apparatus.ApparatusTypeId,
                ApparatusType = apparatus.Vehicle_ApparatusType.Name,
                FuelTypeID = apparatus.FuelTypeId,
                FuelType = apparatus.Vehicle_FuelType.Name,
                DriveTypeID = apparatus.DriveTypeId,
                DriveType = apparatus.Vehicle_DriveType.Name,
                DateAdded = apparatus.DateAdded,
                DateUpdated = apparatus.DateUpdated
            };

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
        [Route("fueltypes/{id}")]
        public async Task<IActionResult> GetFuelTypeById([FromRoute] int id)
        {
            var fuelType = await apparatusRepository.GetFuelTypeByIdAsync(id);

            if(fuelType == null )
            {
                return NotFound();
            }

            var response = new FuelTypeDto
            {
                ID = fuelType.Id,
                Name = fuelType.Name,
                Description = fuelType.Description
            };

            return Ok(response);
        }

        [HttpDelete]
        [Route("fueltypes/{id}")]
        public async Task<IActionResult> DeleteFuelType([FromRoute] int id)
        {
            var fuel = await apparatusRepository.DeleteFuelTypeAsync(id);

            if(fuel == null )
            {
                return NotFound();
            }

            var response = new FuelTypeDto
            {
                ID = fuel.Id,
                Name = fuel.Name,
                Description = fuel.Description
            };

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

        [HttpGet]
        [Route("drivetypes/{id}")]
        public async Task<IActionResult> GetDriveByid([FromRoute] int id)
        {
            var drive = await apparatusRepository.GetDriveTypeByIdAsync(id);

            if(drive == null )
            {
                return NotFound();
            }

            var response = new DriveTypeDto
            {
                ID = drive.Id,
                Name = drive.Name,
                Description = drive.Description
            };

            return Ok(response);
        }

        [HttpDelete]
        [Route("drivetypes/{id}")]
        public async Task<IActionResult> DeleteDriveType([FromRoute] int id)
        {
            var drive = await apparatusRepository.DeleteDriveTypeAsync(id);

            if(drive == null)
            {
                return NotFound();
            }

            var response = new DriveTypeDto
            {
                ID = drive.Id,
                Name = drive.Name,
                Description = drive.Description
            };

            return Ok(response);
        }

        [HttpPost]
        [Route("adddrivetype")]
        public async Task<IActionResult> CreateDriveType(CategoryRequestDto driveDto)
        {

            var drive = new Vehicle_DriveType
            {
                Name = driveDto.Name,
                Description = driveDto.Description
            };

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
        public async Task<IActionResult> CreateApparatusType(CategoryRequestDto typeDto)
        {
            var type = new Vehicle_ApparatusType
            {
                Name = typeDto.Name,
                Description = typeDto.Description
            };

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
        public async Task<IActionResult> CreateFuelType(CategoryRequestDto fuelTypeDto)
        {
            var fuelType = new Vehicle_FuelType
            {
                Name = fuelTypeDto.Name,
                Description = fuelTypeDto.Description
            };

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
