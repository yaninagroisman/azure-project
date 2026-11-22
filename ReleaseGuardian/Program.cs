using ReleaseGuardian.Core;

if (args.Length != 1)
{
    Console.Error.WriteLine(
        "Usage: ReleaseGuardian <application-version>"
    );
    return 1;
}

string version = args[0];

GuardianResult result = GuardianService.ValidateRelease(version);

Console.WriteLine("================================");
Console.WriteLine("     🛡️  RELEASE GUARDIAN");
Console.WriteLine("================================");

Console.WriteLine($"Application Version: {result.Version}");
Console.WriteLine($"Version Validation: {(result.IsValid ? "PASSED" : "FAILED")}");
Console.WriteLine($"Guardian Status: {result.Status}");
Console.WriteLine($"Message: {result.Message}");

return result.IsValid ? 0 : 1;