using System.Runtime.CompilerServices;
using Replicant;
using VerifyTests;

public static class ModuleInitializer
{
    [ModuleInitializer]
    public static void Init()
    {
        VerifierSettings.ModifySerialization(
            settings =>
            {
                settings.AddExtraSettings(x => x.Converters.Add(new ResultConverter()));
                settings.IgnoreMember<Result>(x => x.ContentPath);
                settings.IgnoreMembers(
                    "StackTrace",
                    "Content-Length",
                    "X-Amzn-Trace-Id",
                    "Server",
                    "origin");
            });
    }
}