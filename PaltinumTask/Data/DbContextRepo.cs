using Microsoft.EntityFrameworkCore;
using PaltinumTask.Model;

namespace PaltinumTask.Data
{
    public class DbContextRepo : DbContext
    {
        public DbContextRepo(DbContextOptions<DbContextRepo> options) : base(options)
        {

        }

        public DbSet<Platinum> platinums { get; set; }

    }
}
