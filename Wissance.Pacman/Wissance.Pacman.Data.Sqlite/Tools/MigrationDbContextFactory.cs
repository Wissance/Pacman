using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore.Migrations.Internal;
using Wissance.WebApiToolkit.Data.Ef.Tools;

namespace Wissance.Pacman.Data.Sqlite.Tools
{
    internal class MigrationDbContextFactory: IDesignTimeDbContextFactory<PacmanDbContext>
    {
        public PacmanDbContext CreateDbContext(string[] args)
        {
            string connStr = _dbContextHelper.GetConnStrFromJsonConfig(MigrationProject, JsonConfigFile, ConnStrPath);
            DbContextOptionsBuilder<PacmanDbContext> builder = new DbContextOptionsBuilder<PacmanDbContext>()
                .UseSqlite(connStr, b => b.MigrationsAssembly(MigrationProject));
            PacmanDbContext context = _dbContextHelper.Create<PacmanDbContext>(opts => new PacmanDbContext(opts), builder.Options);
            return context;
        }
        
        private const string MigrationProject = "Wissance.Pacman.Data.Sqlite";
        private const string JsonConfigFile = "migration.settings.json";
        private const string ConnStrPath = "Db.ConnStr";
        private readonly DbContextHelper _dbContextHelper = new DbContextHelper();
    }
}