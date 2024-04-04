namespace FDManagement.Models.DTO
{
    public class UserDto
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string DisplayName { get; set; }
        public string EmployeeId { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public int? UserRoleId { get; set; }
        public string UserRoleName { get; set; }
        public int? AccessFailedCount { get; set; }
        public DateTime DateAdded { get; set; }
        public DateTime? DateUpdated { get; set; }
        public bool TempPw { get; set; }
    }
}
