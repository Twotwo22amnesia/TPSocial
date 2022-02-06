using Microsoft.EntityFrameworkCore;

namespace TelePSocial.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base (options)
        {
                
        }
    }
}
