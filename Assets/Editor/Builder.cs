using System;
using System.Linq;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.Build.Reporting;

public class Builder
{

    public static void BuildWithCLIArgs()
    {
        var buildPlayerOptions = new BuildPlayerOptions();

        SetScenes(ref buildPlayerOptions);
        SetLocation(ref buildPlayerOptions);
        SetTargetPlatform(ref buildPlayerOptions);
        SetDevBuild(ref buildPlayerOptions);

        var buildReport = BuildPipeline.BuildPlayer(buildPlayerOptions);
        if (buildReport.summary.result == BuildResult.Succeeded)
        {
            Console.WriteLine("Build succeeded: " + buildReport.summary.totalSize + " bytes");
        }
    }


    private static void SetDevBuild(ref BuildPlayerOptions options)
    {
        var value = GetCommandValue("--development");
        if(bool.TryParse(value, out var isDevelopment) && isDevelopment)
        {
            options.options |= BuildOptions.Development | BuildOptions.AllowDebugging 
                | BuildOptions.ConnectWithProfiler;     
        }
    }
          

    private static void SetLocation(ref BuildPlayerOptions options)
    {
        var value = GetCommandValue("--location");
        options.locationPathName = value;
    }


    private static void SetTargetPlatform(ref BuildPlayerOptions options)
    {
        var value = GetCommandValue("--target");
        options.target |= Enum.Parse<BuildTarget>(value);
    }


    private static string GetCommandValue(string commandBegin)
    {
        var element = Environment.GetCommandLineArgs().First(arg =>
            arg.StartsWith(commandBegin, StringComparison.CurrentCultureIgnoreCase));
        return element.Split('=')[1];
    }


    private static void SetScenes(ref BuildPlayerOptions options)
    {
        List<string> scenesList = new List<string>();
        foreach (var scene in EditorBuildSettings.scenes)
        {
            if (scene.enabled)
            {
                scenesList.Add(scene.path);
            }
        }
        options.scenes = scenesList.ToArray(); 

    }
}
