using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Wissance.Pacman.Data.Sqlite.Tests.Utils
{
    public class SqliteRelatedTestBase : IDisposable
    {
        public SqliteRelatedTestBase()
        {
            SetRandomConnStr();
            DbContextOptionsBuilder<PacmanDbContext> optionsBuilder = BuildOptionsBuilder<PacmanDbContext>(_connStr);
            DbContext = new PacmanDbContext(optionsBuilder.Options);
            DbContext.Database.Migrate();
        }

        public void Dispose()
        {
            DbContext.Database.EnsureDeleted();
            if (File.Exists(_dbFile))
                File.Delete(_dbFile);
        }

        private void SetRandomConnStr()
        {
            string rndGuidStr = Guid.NewGuid().ToString().Replace("-", "_");
            _dbFile = string.Format(SqliteDbFileTemplate, rndGuidStr);
            _connStr = string.Format(ConnStrTemplate, _dbFile);
        }
        
        private DbContextOptionsBuilder<TContext> BuildOptionsBuilder<TContext>(string connectionString, bool trackQueries = true) where TContext : DbContext
        {
            DbContextOptionsBuilder<TContext> optionsBuilder = new DbContextOptionsBuilder<TContext>();
            optionsBuilder.UseSqlite(connectionString, options =>
            {
                options.CommandTimeout(600);
                options.MigrationsAssembly(MigrationAssembly);
            });
            optionsBuilder.UseLazyLoadingProxies();
            optionsBuilder.UseQueryTrackingBehavior(trackQueries ? QueryTrackingBehavior.TrackAll : QueryTrackingBehavior.NoTracking);
            optionsBuilder.UseLoggerFactory(LoggerFactory.Create(builder => builder.AddDebug()));
            optionsBuilder.EnableSensitiveDataLogging();
            return optionsBuilder;
        }
        
        protected PacmanDbContext DbContext { get; private set; }
        
        private const string ConnStrTemplate = "Data Source={0};";
        private const string SqliteDbFileTemplate = "wissance_pacman_{0}_db_tests.db;";
        private const string MigrationAssembly = "Wissance.Pacman.Data.Sqlite";

        private string _connStr;
        private string _dbFile;
    }
}