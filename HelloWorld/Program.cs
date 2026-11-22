using System.Reflection;
using ReleaseGuardian.Core;

string version = Assembly.GetExecutingAssembly()
    .GetName().Version?.ToString(3) ?? "unknown";

GuardianResult result = GuardianService.ValidateRelease(version);

Console.WriteLine("================================");
Console.WriteLine("       🛡️  RELEASE GUARDIAN");
Console.WriteLine("================================");

Console.WriteLine($"Application Version: {result.Version}");
Console.WriteLine($"Version Validation: {(result.IsValid ? "PASSED" : "FAILED")}");
Console.WriteLine($"Guardian Status: {result.Status}");
Console.WriteLine($"Message: {result.Message}");

if (!result.IsValid)
{
    Environment.ExitCode = 1;
}