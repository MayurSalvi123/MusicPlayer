using Microsoft.EntityFrameworkCore;
using MusicPlayerApi.DbContexts.MusicPlayerDbContexts;

namespace MusicPlayerApi
{
    public class Startup
    {
        public IConfiguration _configuration { get; }
        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<MusicPlayerDbContext>(options =>
                options.UseNpgsql(_configuration.GetConnectionString("MusicPlayerConnectionString")));
        }
    }
}
