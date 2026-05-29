using Wissance.Pacman.Data.Entities;
using Wissance.Pacman.Data.Sqlite.Tests.Utils;

namespace Wissance.Pacman.Data.Sqlite.Tests.Entities
{
    public class TestPackage : SqliteRelatedTestBase
    {
        [Fact]
        public async Task TestCreatePackageSuccessfully()
        {
            Package newPackage = new Package()
            {
                Name = "Wissance.Pacman",
                Description = "test package for Wissance.Data",
                IsAvailable = true,
                AdminUserId = Guid.NewGuid(),
                Owners = new List<PackageOwner>()
                {
                    new PackageOwner()
                    {
                        Name = "M.V. Ushakov",
                        IsOrganization = false,
                        AdditionalInfo = ""
                    },
                    new PackageOwner()
                    {
                        Name = "Wissance LLC",
                        IsOrganization = true,
                        AdditionalInfo = ""
                    }
                }
            };

            await DbContext.Packages.AddAsync(newPackage);
            int result = await DbContext.SaveChangesAsync();
            Assert.True(result > 0);
        }

        [Fact]
        public async Task TestUpdatePackageSuccessfully()
        {
            
        }

        [Fact]
        public async Task TestDeletePackageSuccessfulФly()
        {
            
        }
    }
}