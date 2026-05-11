using Microsoft.EntityFrameworkCore;
using Wissance.Pacman.Data.Entities;
using Wissance.Pacman.Data.Sqlite.Tests.Utils;

namespace Wissance.Pacman.Data.Sqlite.Tests.Entities
{
    public class TestTargetFramework : SqliteRelatedTestBase
    {
        [Fact]
        public async Task TestReadAllSuccessfully()
        {
            // DbContext.TargetFrameworks
            IList<TargetFramework> actualTargetFrameworks = await DbContext.TargetFrameworks.ToListAsync();
            Assert.Equal(0, actualTargetFrameworks.Count);
        }
    }
}