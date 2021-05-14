using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Infra.Context
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        {
        }

        public DbSet<User> users { get; set; }
        public DbSet<Game> games { get; set; }
    }
}