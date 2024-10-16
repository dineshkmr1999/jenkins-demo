using UnityEditor;
using UnityEngine;

public class BuildScript
{
    public static void PerformBuild()
    {
        string[] args = System.Environment.GetCommandLineArgs();
        string buildPath = "";
        string buildTargetArg = "StandaloneOSX"; // Default target

        // Parse command-line arguments
        for (int i = 0; i < args.Length; i++)
        {
            if (args[i] == "-buildPath" && i + 1 < args.Length)
            {
                buildPath = args[i + 1];
            }
            else if (args[i] == "-buildTarget" && i + 1 < args.Length)
            {
                buildTargetArg = args[i + 1]; // Set the build target from the argument
            }
        }

        // Validate the build path
        if (string.IsNullOrEmpty(buildPath))
        {
            Debug.LogError("No build path specified. Please provide a valid -buildPath argument.");
            return;
        }

        Debug.Log("Build path: " + buildPath);
        Debug.Log("Build target: " + buildTargetArg);

        // Determine the build target based on input
        BuildTarget buildTarget;
        switch (buildTargetArg)
        {
            case "StandaloneWindows":
                buildTarget = BuildTarget.StandaloneWindows;
                buildPath += "/YourGameName.exe"; // Add platform-specific directory
                break;
            case "StandaloneWindows64":
                buildTarget = BuildTarget.StandaloneWindows64;
                buildPath += "/Windows64/YourGameName.exe"; // Add platform-specific directory
                break;
            case "StandaloneOSX":
                buildTarget = BuildTarget.StandaloneOSX;
                buildPath += "/macOS/YourGameName.app"; // Add platform-specific directory
                break;
            case "Android":
                buildTarget = BuildTarget.Android;
                buildPath += "/Android/YourGameName.apk"; // Add platform-specific directory
                break;
            default:
                Debug.LogError("Unsupported build target: " + buildTargetArg);
                return;
        }

        // Proceed with building the player
        BuildPipeline.BuildPlayer(EditorBuildSettings.scenes, buildPath, buildTarget, BuildOptions.None);

        Debug.Log("Build completed successfully!!!!");
    }
}
