using Microsoft.EntityFrameworkCore;
using Wissance.Pacman.Data;
using Wissance.Pacman.WebAPI.Configuration;

namespace Wissance.Pacman.WebAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration, IWebHostEnvironment env)
        {
            Configuration = configuration;
            Environment = env;
            _config = Configuration.GetSection(ApplicationConfigSectionName).Get<ApplicationConfig>();
        }
        
        public void ConfigureServices(IServiceCollection services)
        {
            ConfigureDatabase(services);
            ConfigureLogging(services);
            ConfigureAppServices(services);
            ConfigureWebApi(services);
        }
        
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", AppName);
            });

            app.UseRouting();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }

        private void ConfigureDatabase(IServiceCollection services)
        {
            // ??? 
            // services.ConfigureSqliteDbContext<PacmanDbContext>(_config.Database.ConnStr);
            
            ServiceProvider serviceProvider = services.BuildServiceProvider();
            PacmanDbContext modelContext = serviceProvider.GetRequiredService<PacmanDbContext>();
            modelContext.Database.Migrate();
        }

        private void ConfigureLogging(IServiceCollection services)
        {
            
        }

        private void ConfigureAppServices(IServiceCollection services)
        {
            
        }
        
        private void ConfigureWebApi(IServiceCollection services)
        {
            
        }
        
        private IConfiguration Configuration { get; }
        private IWebHostEnvironment Environment { get; }

        private const string ApplicationConfigSectionName = "Application";
        private const string AppName = "Wissance.Pacman.WebAPI";

        private readonly ApplicationConfig _config;
    }
}