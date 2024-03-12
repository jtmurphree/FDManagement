using Microsoft.EntityFrameworkCore;

namespace FDManagement.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

    }
}
