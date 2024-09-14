using BoardGameAPI.Entities;
using Microsoft.EntityFrameworkCore;

namespace BoardGameAPI.Data
{
    public class DataContext: DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<BoardGame> BoardGames { get; set; }
    }
}
