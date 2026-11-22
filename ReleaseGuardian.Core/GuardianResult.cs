namespace ReleaseGuardian.Core;

public record GuardianResult(
    string Version,
    bool IsValid,
    string Status,
    string Message
);