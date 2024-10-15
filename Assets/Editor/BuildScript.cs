using UnityEditor;

public class BuildScript
{
    public static void PerformBuild()
    {
        string buildPath = System.Environment.GetCommandLineArgs()[4];  // The path to the build output done.
        BuildPipeline.BuildPlayer(EditorBuildSettings.scenes, buildPath, BuildTarget.StandaloneOSX, BuildOptions.None);
    }
}
