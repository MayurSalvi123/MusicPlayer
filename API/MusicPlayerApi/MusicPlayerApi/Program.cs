using Microsoft.EntityFrameworkCore;
using MusicPlayerApi.DbContexts.MusicPlayerDbContexts;

namespace MusicPlayerApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1",
                    new Microsoft.OpenApi.Models.OpenApiInfo 
                    {
                        Title = "Music Player APIs",
                        Description = "Music Player Swagger Endpoints",
                        Version = "v1"
                    });
            });

            builder.Services.AddDbContext<MusicPlayerDbContext>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI(options =>
                {
                    options.SwaggerEndpoint("/swagger/v1/swagger.json", "Music Player");
                });
            }

            app.MapSwagger();

            app.UseHttpsRedirection();

            //app.UseRouting();

            app.UseAuthorization();

            app.MapControllers();

            //app.UseEndpoints(endpoints =>
            //{
            //    endpoints.MapControllers();
            //});

            app.Run();
        }
    }
}