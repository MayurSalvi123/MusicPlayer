using Microsoft.EntityFrameworkCore;
using MusicPlayerApi.Core.Entities;

namespace MusicPlayerApi.DbContexts.MusicPlayerDbContexts
{
    public class MusicPlayerDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("");
        }
    }
}
