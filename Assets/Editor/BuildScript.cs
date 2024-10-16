using UnityEditor;
using UnityEngine;  // Needed for Debug.Log

public class BuildScript
{
    public static void PerformBuild()
    {
        string buildPath = System.Environment.GetCommandLineArgs()[4];  // The path to the build output
        Debug.Log("Build path: " + buildPath);  // Add this for debugging

        // Build the player with the scenes and target for macOS
        BuildPipeline.BuildPlayer(EditorBuildSettings.scenes, buildPath, BuildTarget.StandaloneOSX, BuildOptions.None);

        Debug.Log("Build completed successfully!");
    }
}
