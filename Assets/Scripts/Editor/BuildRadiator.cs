// #if UNITY_EDITOR
// using System;
// using System.Collections.Generic;
// using UnityEngine;
// using UnityEditor;
// using System.IO;
// using UnityEditor.Build.Reporting;
// using ZipFile = Ionic.Zip.ZipFile; // this uses the Unity port of DotNetZip https://github.com/r2d2rigo/dotnetzip-for-unity
//
// public class BuildRadiator : ScriptableObject
// {
//     [MenuItem("BuildRadiator/Build Windows")]
//     public static void StartWindows()
//     {
//         string path = $"{GetProjectFolderPath()}/Builds/";
//         string[] filename = path.Split('/'); // do this so I can grab the project folder name
//         BuildPlayer(BuildTarget.StandaloneWindows, Application.productName, $"{path}/");
//     }
//
//     // this is the main player builder function
//     private static void BuildPlayer(BuildTarget buildTarget, string filename, string path)
//     {
//         string fileExtension = "";
//         string dataPath = "";
//         string modifier = "";
//         string date = DateTime.Now.ToString("yyMMdd");
//
//         // configure path variables based on the platform we're targeting
//         switch (buildTarget)
//         {
//             case BuildTarget.StandaloneWindows:
//             case BuildTarget.StandaloneWindows64:
//                 modifier = "_windows";
//                 fileExtension = ".exe";
//                 dataPath = "_Data/";
//                 break;
//             // case BuildTarget.StandaloneOSXIntel:
//             // case BuildTarget.StandaloneOSXIntel64:
//             // case BuildTarget.StandaloneOSXUniversal:
//             // 	modifier = "_mac-osx";
//             // 	fileExtension = ".app";
//             // 	dataPath = fileExtension + "/Contents/";
//             // 	break;
//             // case BuildTarget.StandaloneLinux:
//             // case BuildTarget.StandaloneLinux64:
//             // case BuildTarget.StandaloneLinuxUniversal:
//             // 	modifier = "_linux";
//             // 	dataPath = "_Data/";
//             // 	switch ( buildTarget ) {
//             // 	case BuildTarget.StandaloneLinux: fileExtension = ".x86"; break;
//             // 	case BuildTarget.StandaloneLinux64: fileExtension = ".x64"; break;
//             // 	case BuildTarget.StandaloneLinuxUniversal: fileExtension = ".x86_64"; break;
//             // 	}
//             // 	break;
//         }
//
//         Debug.Log($"====== BuildPlayer: {buildTarget} at {path}{filename}");
//         EditorUserBuildSettings.SwitchActiveBuildTarget(BuildTargetGroup.Standalone, buildTarget);
//
//         // build out the player
//         string buildPath = $"{path}{filename}{modifier}/";
//         Debug.Log($"buildpath: {buildPath}");
//         string playerPath = buildPath + filename + modifier + fileExtension;
//         Debug.Log($"playerpath: {playerPath}");
//
//         BuildReport report = BuildPipeline.BuildPlayer(GetScenePaths(), playerPath, buildTarget, BuildOptions.ShowBuiltPlayer);
//
//
//         if (report.summary.result == BuildResult.Succeeded)
//         {
//             CopyFileFromProjectAssets(buildPath, "Attributions.md");
//             DetectUselessFiles(buildPath);
//             CompressDirectory(buildPath, $"{path}/{filename}{modifier}-{Application.version}-{date}.zip");
//         }
//         else
//         {
//             Debug.LogError($"Build state {report.summary.result}");
//         }
//     }
//
//     // from http://wiki.unity3d.com/index.php?title=AutoBuilder
//     private static string[] GetScenePaths()
//     {
//         string[] scenes = new string[EditorBuildSettings.scenes.Length];
//         for (int i = 0; i < scenes.Length; i++)
//         {
//             scenes[i] = EditorBuildSettings.scenes[i].path;
//         }
//
//         return scenes;
//     }
//
//     private static string GetProjectFolderPath()
//     {
//        return Application.dataPath.Replace("Assets","");
//     }
//     
//     /// <summary>
//     /// copies over files from somewhere in my project folder to my standalone build's path
//     /// </summary>
//     /// <param name="fullDataPath"></param>
//     /// <param name="assetsFolderPath">do not put a "/" at beginning of assetsFolderName</param>
//     /// <param name="deleteMetaFiles"></param>
//     /// <param name="keepFolder"></param>
//     private static void CopyFromProjectAssets(string fullDataPath, string assetsFolderPath, bool deleteMetaFiles = true,
//         bool keepFolder = true)
//     {
//         string sourcePath = $"{Application.dataPath}/{assetsFolderPath}";
//         string destinationPath = fullDataPath + assetsFolderPath;
//
//         if (keepFolder == false)
//         {
//             destinationPath = destinationPath.Replace(assetsFolderPath, "");
//         }
//
//         if (!Directory.Exists(sourcePath))
//         {
//             Debug.Log($"No {sourcePath} found.");
//             return;
//         }
//
//
//         Debug.Log($"CopyFromProjectAssets: copying over {assetsFolderPath}");
//         FileUtil.ReplaceDirectory(sourcePath, destinationPath); // copy over languages
//
//         // delete all meta files
//         if (!deleteMetaFiles) return;
//         string[] metaFiles = Directory.GetFiles(destinationPath, "*.meta", SearchOption.AllDirectories);
//         foreach (string meta in metaFiles)
//         {
//             FileUtil.DeleteFileOrDirectory(meta);
//         }
//     }
//
//     private static void CopyFileFromProjectAssets(string fullDataPath, string assetsPath)
//     {
//         string sourcePath = $"{Application.dataPath}/Infos/{assetsPath}";
//         string destinationPath = fullDataPath + "/" + assetsPath;
//         Debug.Log($"CopyFromProjectAssets: copying over {assetsPath}");
//         FileUtil.ReplaceFile(sourcePath, destinationPath); // copy over languages
//     }
//
//     private static void DetectUselessFiles(string buildPath)
//     {
//         DirectoryInfo dirInfo = new(buildPath);
//         IEnumerable<DirectoryInfo> dirs = dirInfo.EnumerateDirectories("*DoNotShip*", new EnumerationOptions
//             { RecurseSubdirectories = false });
//
//         foreach (DirectoryInfo name in dirs)
//         {
//             Debug.LogError(name);
//         }
//     }
//
//     // compress the folder into a ZIP file, uses https://github.com/r2d2rigo/dotnetzip-for-unity
//     private static void CompressDirectory(string directory, string zipFileOutputPath)
//     {
//         Debug.Log($"attempting to compress {directory} into {zipFileOutputPath}");
//         // display fake percentage, I can't get zip.SaveProgress event handler to work for some reason, whatever
//         EditorUtility.DisplayProgressBar("COMPRESSING... please wait", zipFileOutputPath, 0.38f);
//         using (ZipFile zip = new())
//         {
//             zip.ParallelDeflateThreshold =
//                 -1; // DotNetZip bugfix that corrupts DLLs / binaries http://stackoverflow.com/questions/15337186/dotnetzip-badreadexception-on-extract
//             zip.AddDirectory(directory);
//             //DoNotShip
//             zip.Save(zipFileOutputPath);
//         }
//
//         EditorUtility.ClearProgressBar();
//     }
// }
// #endif