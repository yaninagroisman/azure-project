using System.Reflection;
using ReleaseGuardian.Core;

string version = Assembly.GetExecutingAssembly()
    .GetName().Version?.ToString(3) ?? "unknown";

Console.WriteLine("================================");
Console.WriteLine("      RELEASE GUARDIAN");
Console.WriteLine("================================");

Console.WriteLine($"Application Version: {version}");

bool isValid = VersionValidator.IsValid(version);

if (isValid)
{
    Console.WriteLine("Version Validation: PASSED");
    Console.WriteLine("Guardian Status: READY");
}
else
{
    Console.WriteLine("Version Validation: FAILED");
    Console.WriteLine("Guardian Status: BLOCKED");

    Environment.ExitCode = 1;
}