using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Wissance.Pacman.Data.Sqlite.Extensions
{
    public static class SqliteServiceCollectionExtension
    {
        public static IServiceCollection AddSqliteDbContext<TContext>(this IServiceCollection serviceCollection,
            string connectionString)
            where TContext : DbContext
        {
            serviceCollection.AddDbContext<TContext>(options => options
                .UseQueryTrackingBehavior(QueryTrackingBehavior.TrackAll)
                .UseSqlite(connectionString, opts =>
                {
                    opts.CommandTimeout(600);
                    opts.MigrationsAssembly(MigrationAssembly);
                })
                .UseLazyLoadingProxies());
            return serviceCollection;
        }
        
        private const string MigrationAssembly = "Wissance.Pacman.Data.Sqlite";
    }
}