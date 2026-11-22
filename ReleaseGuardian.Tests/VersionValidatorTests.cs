using ReleaseGuardian.Core;
using Xunit;

namespace ReleaseGuardian.Tests;

public class VersionValidatorTests
{
    [Theory]
    [InlineData("1.0.0")]
    [InlineData("1.2.3")]
    [InlineData("2.0.0")]
    [InlineData("10.5.20")]
    public void ValidVersions_ShouldPass(string version)
    {
        Assert.True(VersionValidator.IsValid(version));
    }

    [Theory]
    [InlineData("0.1.0")]
    [InlineData("hello")]
    [InlineData("1.0")]
    [InlineData("")]
    [InlineData(null)]
    public void InvalidVersions_ShouldFail(string? version)
    {
        Assert.False(VersionValidator.IsValid(version));
    }
}
