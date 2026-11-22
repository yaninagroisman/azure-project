namespace ReleaseGuardian.Core;

public static class GuardianService
{
    public static GuardianResult ValidateRelease(string? version)
    {
        bool isValid = VersionValidator.IsValid(version);

        if (isValid)
        {
            return new GuardianResult(
                version!,
                true,
                "READY",
                "Version validation passed"
            );
        }

        return new GuardianResult(
            version ?? "unknown",
            false,
            "BLOCKED",
            "Invalid application version"
        );
    }
}