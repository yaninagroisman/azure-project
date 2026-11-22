namespace ReleaseGuardian.Core;

public static class VersionValidator
{
    public static bool IsValid(string? version)
    {
        return Version.TryParse(version, out var parsed)
            && parsed.Major >= 1
            && parsed.Minor >= 0
            && parsed.Build >= 0;
    }
}
