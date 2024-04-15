using Microsoft.AspNetCore.Mvc;
using FDManagement.Repositories.Interface;
using FDManagement.Models.DTO;
using System.Reflection.Metadata;
using Microsoft.Identity.Client;

namespace FDManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository userRepository;

        public UserController(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser(AddUserRequestDto userDto)
        {
            var user = new Global_User()
            {
                FirstName = userDto.FirstName,
                LastName = userDto.LastName,
                Email = userDto.Email,
                PhoneNumber = userDto.PhoneNumber,
                DisplayName = userDto.DisplayName,
                UserName = userDto.UserName,
                EmployeeId = userDto.EmployeeId,
                PasswordHash = userDto.PasswordHash,
                UserRoleId = userDto.UserRoleId,
                AccessFailedCount = 0,
                DateAdded = userDto.DateAdded,
                TempPw = false
            };

            await userRepository.CreateAsync(user);

            var response = new UserDto
            {
                ID = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                UserName = user.UserName,
                Email = user.Email,
                PhoneNumber = user.PhoneNumber,
                DisplayName = user.DisplayName,
                EmployeeId = user.EmployeeId,
                PasswordHash = user.PasswordHash,
                AccessFailedCount = user.AccessFailedCount,
                UserRoleId = user.UserRoleId,
                DateAdded = DateTime.Now,
                DateUpdated = null,
                TempPw = user.TempPw
            };

            return Ok(response);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {
            var users = await userRepository.GetAllAsync();
            var response = new List<UserDto>();

            foreach (var user in users)
            {
                response.Add(new UserDto
                {
                    ID = user.Id,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Email = user.Email,
                    PhoneNumber = user.PhoneNumber,
                    DisplayName = user.DisplayName,
                    EmployeeId = user.EmployeeId,
                    PasswordHash = user.PasswordHash,
                    AccessFailedCount = user.AccessFailedCount != null ? (int)user.AccessFailedCount : 0,
                    UserRoleId = user.Global_RegisteredUserRole != null ? user.Global_RegisteredUserRole.Global_UserRole.Id : null,
                    UserRoleName = user.Global_RegisteredUserRole != null ? user.Global_RegisteredUserRole.Global_UserRole.Name : "",
                    DateAdded = user.DateAdded,
                    DateUpdated = user.DateUpdated
                });
            }
            return Ok(response);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetUserByID([FromRoute] int id)
        {
            var user = await userRepository.GetUserByIdAsync(id);

            if (user is null)
            {
                return NotFound();
            }

            var response = new UserDto
            {
                ID = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                UserName = user.UserName,
                DisplayName = user.DisplayName,
                EmployeeId = user.EmployeeId,
                PhoneNumber = user.PhoneNumber,
                Email = user.Email,
                PasswordHash = user.PasswordHash,
                UserRoleName = user.Global_RegisteredUserRole != null ? user.Global_RegisteredUserRole.Global_UserRole.Name : "",
                UserRoleId = user.UserRoleId,
                AccessFailedCount = user.AccessFailedCount,
                DateAdded = user.DateAdded,
                DateUpdated = user.DateUpdated,
                TempPw = user.TempPw
            };

            return Ok(response);
        }

        [HttpGet]
        [Route("roles")]
        public async Task<IActionResult> GetUserRoles()
        {
            var roles = await userRepository.GetRolesAsync();
            var response = new List<UserRoleDto>();

            foreach (var role in roles)
            {
                response.Add(new UserRoleDto
                {
                    ID = role.Id,
                    Name = role.Name,
                    Description = role.Description
                });
            }

            return Ok(response);
        }

        [HttpGet]
        [Route("registerdRoles")]
        public async Task<IActionResult> GetRegisteredRoles()
        {
            var roles = await userRepository.GetRegisteredRolesAsync();
            var response = new List<RegisteredUserRoleDto>();

            foreach (var role in roles)
            {
                response.Add(new RegisteredUserRoleDto
                {
                    ID = role.Id,
                    UserID = role.UserId,
                    RoleID = role.RoleId
                });
            }

            return Ok(response);
        }

        [HttpPost]
        [Route("createuserrole")]
        public async Task<IActionResult> CreateUserRole(Global_UserRole role)
        {
            await userRepository.CreateRoleAsync(role);
            return Ok(role);
        }

        [HttpPost]
        [Route("createregisteredrole")]
        public async Task<IActionResult> CreateRegisteredRole(Global_RegisteredUserRole role)
        {
            await userRepository.CreateRegisteredRoleAsync(role);
            return Ok(role);
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> EditUser([FromRoute] int id, UpdateUserRequestDto request)
        {
            //convert to domain model
            var user = new Global_User
            {
                Id = id,
                FirstName = request.FirstName,
                LastName = request.LastName,
                UserName = request.UserName,
                DisplayName = request.DisplayName,
                EmployeeId = request.EmployeeId,
                PhoneNumber = request.PhoneNumber,
                Email = request.Email,
                PasswordHash = request.PasswordHash,
                UserRoleId = request.UserRoleId,
                AccessFailedCount = request.AccessFailedCount,
                DateAdded = request.DateAdded,
                DateUpdated = request.DateUpdated,
            };

            user = await userRepository.UpdateUserAsync(user);

            if(user == null)
            {
                return NotFound();
            }

            //Convertt to dto
            var response = new UserDto
            {
                ID = user.Id,
                FirstName = request.FirstName,
                LastName = request.LastName,
                UserName = request.UserName,
                EmployeeId = request.EmployeeId,
                DisplayName = request.DisplayName,
                PhoneNumber = request.PhoneNumber,
                Email = request.Email,
                UserRoleId = request.UserRoleId,
                DateUpdated = request.DateUpdated,
                DateAdded = request.DateAdded,
                UserRoleName = request.UserRoleName,
                AccessFailedCount = request.AccessFailedCount,
                PasswordHash = request.PasswordHash,
                TempPw = request.tempPw
            };

            return Ok(response);
        
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteUser([FromRoute] int id)
        {
            var user = await userRepository.DeleteUserAsync(id);

            if (user is null)
            {
                return NotFound();
            }

            var response = new UserDto
            {
                ID = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                UserName = user.UserName,
                DisplayName = user.DisplayName,
                EmployeeId = user.EmployeeId,
                PhoneNumber = user.PhoneNumber,
                Email = user.Email,
                PasswordHash = user.PasswordHash,
                UserRoleId = user.UserRoleId,
                UserRoleName = user.Global_RegisteredUserRole.Global_UserRole.Name,
                AccessFailedCount = user.AccessFailedCount,
                DateAdded = user.DateAdded,
                DateUpdated = user.DateUpdated,
                TempPw = user.TempPw
            };

            return Ok(response);
        }

        [HttpPut]
        [Route("roles/{id}")]
        public async Task<IActionResult> UpdateUserRole([FromRoute] int id, UserRoleDto roleDto)
        {
            var role = new Global_UserRole
            {
                Id = id,
                Name = roleDto.Name,
                Description = roleDto.Description,
            };

            role = await userRepository.UpdateRoleAsync(role);

            if(role == null)
            {
                return NotFound();
            }

            var response = new UserRoleDto
            {
                ID = role.Id,
                Name = role.Name,
                Description = role.Description,
            };

            return Ok(response); 
        }

        [HttpDelete]
        [Route("roles/{id}")]
        public async Task<IActionResult> DeleteUserRole([FromRoute] int id)
        {
            var role = await userRepository.DeleteRoleAsync(id);

            if(role is null)
            {
                return NotFound();
            }

            var response = new UserRoleDto
            {
                ID = role.Id,
                Name = role.Name,
                Description = role.Description
            };

            return Ok(response);
        }
    }
}
