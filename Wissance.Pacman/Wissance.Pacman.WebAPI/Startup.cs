namespace Wissance.Pacman.WebAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration, IWebHostEnvironment env)
        {
            Configuration = configuration;
            Environment = env;
            // _config = Configuration.GetSection(ApplicationConfigSectionName).Get<ApplicationConfig>();
        }
        
        public void ConfigureServices(IServiceCollection services)
        {
            //ConfigureDatabase(services);
            //ConfigureLogging(services);
            //ConfigureAppServices(services);
            //ConfigureWebApi(services);
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
        
        private IConfiguration Configuration { get; }
        private IWebHostEnvironment Environment { get; }

        private const string ApplicationConfigSectionName = "Application";
        private const string AppName = "Wissance.Pacman.WebAPI";

        // private readonly ApplicationConfig _config;
    }
}