using Microsoft.EntityFrameworkCore;

namespace Games.Api.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        {
        }

        public DbSet<User> users { get; set; }
    }
}