using Microsoft.EntityFrameworkCore;
using Wissance.Pacman.Data.Entities;
using Wissance.Pacman.Data.Sqlite.Tests.ExpectedData;
using Wissance.Pacman.Data.Sqlite.Tests.Utils;
using Wissance.Pacman.Tests.Common.Checkers;

namespace Wissance.Pacman.Data.Sqlite.Tests.Entities
{
    public class TestTargetFramework : SqliteRelatedTestBase
    {
        [Fact]
        public async Task TestReadAllSuccessfully()
        {
            IList<TargetFramework> actualTargetFrameworks = await DbContext.TargetFrameworks.ToListAsync();
            TargetFrameworkChecker.Check(ExpectedTargetFrameworks.Data, actualTargetFrameworks);
        }

        [Theory]
        [InlineData("net6.0")]
        public async Task TestCreateSameTargetFrameworkFailed(string targetFramework)
        {
            int beforeAddTargetFrameworksCount = await DbContext.TargetFrameworks.CountAsync();
            TargetFramework newFramework = new TargetFramework()
            {
                Id = Guid.NewGuid(),
                Name = targetFramework
            };
            
            await DbContext.TargetFrameworks.AddAsync(newFramework);
            int result = await DbContext.SaveChangesAsync();
            Assert.True(result < 0);
            int afterAddTargetFrameworksCount = await DbContext.TargetFrameworks.CountAsync();
            Assert.Equal(beforeAddTargetFrameworksCount, afterAddTargetFrameworksCount);
        }
    }
}