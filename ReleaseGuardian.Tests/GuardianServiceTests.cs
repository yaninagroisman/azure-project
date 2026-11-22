using ReleaseGuardian.Core;
using Xunit;

namespace ReleaseGuardian.Tests;

public class GuardianServiceTests
{
    [Theory]
    [InlineData("1.0.0")]
    [InlineData("1.2.3")]
    [InlineData("2.5.10")]
    public void ValidRelease_ShouldBeReady(string version)
    {
        GuardianResult result =
            GuardianService.ValidateRelease(version);

        Assert.True(result.IsValid);
        Assert.Equal("READY", result.Status);
        Assert.Equal(version, result.Version);
        Assert.Equal("Version validation passed", result.Message);
    }

    [Theory]
    [InlineData("0.1.0")]
    [InlineData("invalid")]
    [InlineData("")]
    [InlineData(null)]
    public void InvalidRelease_ShouldBeBlocked(string? version)
    {
        GuardianResult result =
            GuardianService.ValidateRelease(version);

        Assert.False(result.IsValid);
        Assert.Equal("BLOCKED", result.Status);
        Assert.Equal("Invalid application version", result.Message);
    }
}