using Formula1.Models;
using Microsoft.EntityFrameworkCore;

namespace Formula1.Data
{
    public class ApplicationDB : DbContext
    {
        public ApplicationDB(DbContextOptions<ApplicationDB> options) : base(options) { }

        public DbSet<Driver> Drivers { get; set; }
    }
}
