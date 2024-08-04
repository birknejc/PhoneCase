using Microsoft.EntityFrameworkCore;
using PhoneCase.Models;

namespace PhoneCase.DBServices
{
    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) 
        {

        }
        public DbSet<CustomCase> Cases { get; set; }
    }
}
