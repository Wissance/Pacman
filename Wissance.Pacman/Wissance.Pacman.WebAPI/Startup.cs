using System.Data;
using System.Data.Common;
using Microsoft.EntityFrameworkCore;
using Wissance.Pacman.Data;
using Wissance.Pacman.Data.Postgres.Extensions;
using Wissance.Pacman.Data.Sqlite.Extensions;
using Wissance.Pacman.WebAPI.Configuration;
using Wissance.Pacman.WebAPI.Initializer;
using Wissance.Pacman.WebAPI.Managers;
using Wissance.Pacman.WebAPI.Middleware;
using Wissance.WebApiToolkit.Core.Managers;

namespace Wissance.Pacman.WebAPI
{
    enum DatabaseType { Unknown, SqlServer, MySql, Oracle, PostgresSql, Sqlite }
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
                /*app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                     c.SwaggerEndpoint("/swagger/v1/swagger.json", AppName);
                });*/
            }

            app.UseMiddleware<NuGetApiKeyMiddleware>();
            
            app.UseRouting();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }

        private void ConfigureDatabase(IServiceCollection services)
        {
            // Pacman could use either SQLite or Postgres therefore 
            // services.ConfigureSqliteDbContext<PacmanDbContext>(_config.Database.ConnStr);
            DatabaseType dbType = DetermineDbType(_config.Database.ConnStr);
            switch (dbType)
            {
                case DatabaseType.Sqlite:
                    services.AddSqliteDbContext<PacmanDbContext>(_config.Database.ConnStr);
                    break;
                case DatabaseType.PostgresSql:
                    services.AddPostgresDbContext<PacmanDbContext>(_config.Database.ConnStr);
                    break;
                default:
                    throw new InvalidDataException($"Provided connection string is not related to the SQLite or Postgres, you could create an issue on the github:");
            }

            ServiceProvider serviceProvider = services.BuildServiceProvider();
            PacmanDbContext modelContext = serviceProvider.GetRequiredService<PacmanDbContext>();
            modelContext.Database.Migrate();
            DataInitializer.Init(modelContext, IsDevelopmentHostingEnvironment());
        }

        private void ConfigureLogging(IServiceCollection services)
        {
            
        }

        private void ConfigureAppServices(IServiceCollection services)
        {
            // add file management
            services.AddScoped<IFileManager>(sp =>
            {
                ILoggerFactory loggerFactory = sp.GetRequiredService<ILoggerFactory>();
                return new WebFolderFileManager(
                    new Dictionary<string, string>() {{_config.Storage.Name, _config.Storage.Src}}, loggerFactory);
            });
        }
        
        private void ConfigureWebApi(IServiceCollection services)
        {
            ConfigureManagers(services);
            ConfigureControllers(services);
        }

        private void ConfigureManagers(IServiceCollection services)
        {
            services.AddScoped<ServiceIndexManager>();
            services.AddScoped<PackageManager>();
        }
        
        private void ConfigureControllers(IServiceCollection services)
        {
            services.AddControllers();
        }

        private DatabaseType DetermineDbType(string connStr)
        {
            DbConnectionStringBuilder builder = new DbConnectionStringBuilder()
            {
                ConnectionString = connStr
            };
            // 1. Check for SQLite
            if (builder.ContainsKey("Data Source") &&
                builder["Data Source"].ToString().EndsWith(".db", StringComparison.OrdinalIgnoreCase)
                || builder.ContainsKey("Uri") || builder.ContainsKey("Full Uri"))
                return DatabaseType.Sqlite;
            // 2. Check for MySQL | MariaDB
            if (builder.ContainsKey("Allow Zero Datetime")) 
                return DatabaseType.MySql;
            if (builder.ContainsKey("Server") && (builder.ContainsKey("Uid") || builder.ContainsKey("User Id")) && 
                !builder.ContainsKey("Port"))
            {
                // Fallback check as 'Server' and 'User Id' overlap with SQL Server
                if (connStr.Contains("port=", StringComparison.OrdinalIgnoreCase) || connStr.Contains("sslmode=", StringComparison.OrdinalIgnoreCase))
                    return DatabaseType.MySql;
            }
            // 3. Check for PostgresSQL
            if (builder.ContainsKey("Host") || connStr.Contains("SearchPath=", StringComparison.OrdinalIgnoreCase))
                return DatabaseType.PostgresSql;

            // 4. Check for Oracle
            if (builder.ContainsKey("User Id") && (builder.ContainsKey("Data Source") || builder.ContainsKey("Proxy User")) && 
                connStr.Contains("Min Pool Size", StringComparison.OrdinalIgnoreCase) == false)
            {
                if (connStr.Contains("Integrated Security", StringComparison.OrdinalIgnoreCase) || connStr.Contains("DBA Privilege", StringComparison.OrdinalIgnoreCase))
                    return DatabaseType.Oracle;
            }

            // 5. Check for SQL Server (Default fallback for common enterprise structures)
            if (builder.ContainsKey("Initial Catalog") || builder.ContainsKey("Integrated Security") || builder.ContainsKey("Trusted_Connection"))
                return DatabaseType.SqlServer;

            return DatabaseType.Unknown;
        }

        private bool IsDevelopmentHostingEnvironment()
        {
            return string.Equals(Environment.EnvironmentName.ToLower(), "development");
        }
        
        private IConfiguration Configuration { get; }
        private IWebHostEnvironment Environment { get; }

        private const string ApplicationConfigSectionName = "Application";
        private const string AppName = "Wissance.Pacman.WebAPI";

        private readonly ApplicationConfig _config;
    }
}