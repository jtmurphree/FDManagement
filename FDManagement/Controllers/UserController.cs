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
                    DateAdded = user.DateAdded,
                    DateUpdated = user.DateUpdated
                });
            }
            return Ok(response);
        }
    }
}
