using Microsoft.AspNetCore.Authorization.Infrastructure;
using Wissance.Pacman.Data.Entities;
using Xunit;

namespace Wissance.Pacman.Tests.Common.Checkers
{
    public static class TargetFrameworkChecker
    {
        public static void Check(TargetFramework expected, TargetFramework actual)
        {
            Assert.Equal(expected.Id, actual.Id);
            Assert.Equal(expected.Name.ToLower(), actual.Name.ToLower());
        }

        public static void Check(IList<TargetFramework> expected, IList<TargetFramework> actual)
        {
            Assert.Equal(expected.Count, actual.Count);
            foreach (TargetFramework e in expected)
            {
                TargetFramework a = actual.FirstOrDefault(i => i.Id == e.Id);
                Assert.NotNull(a);
                Check(e, a);
            }
        }
    }
}