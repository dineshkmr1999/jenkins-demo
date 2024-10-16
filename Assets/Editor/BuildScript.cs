using UnityEditor;
using UnityEngine;

public class BuildScript
{
    public static void PerformBuild()
    {
        string[] args = System.Environment.GetCommandLineArgs();
        string buildPath = "";

        // Find the -buildPath argument in the command-line args
        for (int i = 0; i < args.Length; i++)
        {
            if (args[i] == "-buildPath" && i + 1 < args.Length)
            {
                buildPath = args[i + 1];
                break;
            }
        }

        if (string.IsNullOrEmpty(buildPath))
        {
            Debug.LogError("No build path specified. Please provide a valid -buildPath argument.");
            return;
        }

        Debug.Log("Build path: " + buildPath);

        // Proceed with building the player
        BuildPipeline.BuildPlayer(EditorBuildSettings.scenes, buildPath, BuildTarget.StandaloneWindows, BuildOptions.None);

        Debug.Log("Build completed successfully!!");
    }
}