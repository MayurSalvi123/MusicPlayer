using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using MusicPlayerApi.Core.Entities;

namespace MusicPlayerApi.DbContexts.MusicPlayerDbContexts
{
    public class MusicPlayerDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Server=localhost;Port=5432;User Id=postgres;Password=root;Database=musicplayer;");
        }
    }
}
