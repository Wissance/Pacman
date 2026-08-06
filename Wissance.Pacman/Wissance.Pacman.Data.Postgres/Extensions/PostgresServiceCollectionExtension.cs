using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Wissance.Pacman.Data.Postgres.Extensions
{
    public static class PostgresServiceCollectionExtension
    {
        public static IServiceCollection AddPostgresDbContext<TContext>(this IServiceCollection serviceCollection,
            string connectionString)
            where TContext : DbContext
        {
            serviceCollection.AddDbContext<TContext>(options => options
                .UseQueryTrackingBehavior(QueryTrackingBehavior.TrackAll)
                .UseNpgsql(connectionString, opts =>
                {
                    opts.CommandTimeout(600);
                    opts.MigrationsAssembly(MigrationAssembly);
                })
                .UseLazyLoadingProxies());
            return serviceCollection;
        }
        
        private const string MigrationAssembly = "Wissance.Pacman.Data.Postgres";
    }
}