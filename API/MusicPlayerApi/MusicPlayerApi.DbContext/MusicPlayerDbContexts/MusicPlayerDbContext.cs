using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using MusicPlayerApi.Core.Entities;

namespace MusicPlayerApi.DbContexts.MusicPlayerDbContexts
{
    public class MusicPlayerDbContext : DbContext
    {
        private readonly IConfiguration _configuration;

        public MusicPlayerDbContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(_configuration.GetConnectionString("MusicPlayerConnectionString"));
        }
    }
}
