using System;
using System.Threading.Tasks;
using Cake.Common;
using Cake.Common.IO;
using Cake.Common.Tools.DotNet;
using Cake.Common.Tools.DotNet.Build;
using Cake.Common.Tools.DotNet.Clean;
using Cake.Common.Tools.DotNet.Restore;
using Cake.Core;
using Cake.Core.Diagnostics;
using Cake.Frosting;
using Cake.MinVer;

public static class Program
{
    public static int Main(string[] args)
    {
        const string DotnetPackageMinverCli = "dotnet:?package=minver-cli&version=2.5.0";
       
        return new CakeHost()
            .InstallTool(new Uri(DotnetPackageMinverCli))
            .UseContext<BuildContext>()
            .UseWorkingDirectory("..")
            .Run(args);
    }
}

public class BuildContext : FrostingContext
{
    public string MsBuildConfiguration { get; }

    public string Version
    {
        get
        {
            return CreateVersion(this);
        }
    }
    public string ImageName { get; }
    public string DockerHubUrl { get; }

    public string DockerPassword { get; }
    public string DockerUserName { get; }

    public BuildContext(ICakeContext context)
        : base(context)
    {
        MsBuildConfiguration = context.Argument("configuration", "Release");
        ImageName = "bankofgringotts-api";
        DockerUserName = context.EnvironmentVariable("DOCKER_USERNAME", "");
        DockerPassword = context.Argument("DOCKER_PASSWORD", "");
        DockerHubUrl = context.EnvironmentVariable("DOCKER_HUB_URL", "");
    }

    private string CreateVersion(ICakeContext context)
    {
        var minVerSettings = new MinVerSettings
        {
            AutoIncrement = MinVerAutoIncrement.Minor,
            DefaultPreReleasePhase = "beta",
            MinimumMajorMinor = "1.0",
            TagPrefix = "v"
        };

        return context.MinVer(minVerSettings);
    }
}

[TaskName("Clean")]
public sealed class CleanTask : FrostingTask<BuildContext>
{
    public override void Run(BuildContext context)
    {
        context.CleanDirectory("./publish");
        context.CleanDirectories("src/**/obj/");
        context.CleanDirectories("src/**/bin/");
        context.CleanDirectories("test/**/obj/");
        context.CleanDirectories("test/**/bin/");
        var dotNetCleanSettings = new DotNetCleanSettings
        {
            Configuration = context.MsBuildConfiguration,
            NoLogo = true
        };
        context.DotNetClean(".", dotNetCleanSettings);
    }
}

[TaskName(("Restore"))]
public sealed class RestoreTask : FrostingTask<BuildContext>
{
    public override void Run(BuildContext context)
    {
        var dotNetRestoreSettings = new DotNetRestoreSettings
        {
            NoCache = true,
            Force = true
        };
        context.DotNetRestore(".", dotNetRestoreSettings);
    }
}

[TaskName("Build")]
[IsDependentOn(typeof(CleanTask))]
[IsDependentOn(typeof(RestoreTask))]
public sealed class BuildTask : FrostingTask<BuildContext>
{
    public override void Run(BuildContext context)
    {
        context.DotNetBuild(".", new DotNetBuildSettings
        {
            Configuration = context.MsBuildConfiguration,
            NoLogo = true,
            NoRestore = true
        });
    }
}

[TaskName("Publish")]
public sealed class PublishApiTask : FrostingTask<BuildContext>
{
    public override void Run(BuildContext context)
    {
        var settings = new Cake.Common.Tools.DotNet.Publish.DotNetPublishSettings
        {
            Configuration = context.MsBuildConfiguration,
            OutputDirectory = "./publish",
            Runtime = "linux-x64",
            SelfContained = true,
            NoLogo = true,
            PublishSingleFile = true,
            ArgumentCustomization = args => args.Append($"/p:Version={context.Version}")
        };
        context.DotNetPublish("./src/BankOfGringotts.Api/BankOfGringotts.Api.csproj", settings);
    }
}

[TaskName("Default")]
public class DefaultTask : FrostingTask
{
}