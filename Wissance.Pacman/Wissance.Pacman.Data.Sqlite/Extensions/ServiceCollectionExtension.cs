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
                .UseSqlite(connectionString)
                .UseLazyLoadingProxies());
            return serviceCollection;
        }
    }
}