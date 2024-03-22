using Microsoft.AspNetCore.Mvc;
using FDManagement.Repositories.Interface;
using FDManagement.Models.DTO;

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
        public async Task<IActionResult> CreateUser(Global_User user)
        {
            await userRepository.CreateAsync(user);

            var response = new UserDto
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
                DateAdded = user.DateAdded,
                DateUpdated = user.DateUpdated
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
        [Route("api/[controller]/{id}")]
        public async Task<IActionResult> GetUserByID(int id)
        {
            var user = await userRepository.GetById(id);

            return Ok(user);
        }

        [HttpGet]
        [Route("api/[controller]/roles")]
        public async Task<IActionResult> GetUserRoles()
        {
            var roles = await userRepository.GetRolesAsync();
            var response = new List<UserRoleDto>();

            foreach(var role in roles)
            {
                response.Add(new UserRoleDto
                {
                    ID = role.Id,
                    Name = role.Name,
                    Descrtiption = role.Description
                });
            }

            return Ok(response);
        }

        [HttpGet]
        [Route("api/[controller]/registerdRoles")]
        public async Task<IActionResult> GetRegisteredRoles()
        {
            var roles = await userRepository.GetRegisteredRolesAsync();
            var response = new List<RegisteredUserRoleDto>();

            foreach(var role in roles)
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
        [Route("api/[controller]/CreateUserRole")]
        public async Task<IActionResult> CreateUserRole(Global_UserRole role)
        {
            await userRepository.CreateRoleAsync(role);
            return Ok(role);
        }

        [HttpPost]
        [Route("api/[controller]/CreateRegisteredRole")]
        public async Task<IActionResult> CreateRegisteredRole(Global_RegisteredUserRole role)
        {
            await userRepository.CreateRegisteredRoleAsync(role);
            return Ok(role);
        }
    }
}
