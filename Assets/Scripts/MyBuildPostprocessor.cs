// #if UNITY_EDITOR
// using System;
// using System.Collections.Generic;
// using System.IO;
// using System.Linq;
// using Ionic.Zip;
// using UnityEngine;
// using UnityEditor;
// using UnityEditor.Callbacks;
//
// public class MyBuildPostprocessor
// {
//     private const string EXPORT_PATH = "Exports";
//
//     [PostProcessBuild(1)]
//     public static void OnPreProcess()
//     {
//     }
//
//     [PostProcessBuild(1)]
//     public static void OnPostprocessBuild(BuildTarget a_target, string a_pathToBuildExe)
//     {
//         Debug.Log(a_pathToBuildExe);
//         string date = DateTime.Now.ToString("yyMMdd");
//         string buildPath = Path.GetDirectoryName(a_pathToBuildExe);
//         string exportZipPath = $"{buildPath}/{EXPORT_PATH}/{Application.productName}-{Application.version}-{date}.zip";
//
//
//         // exportZipPath = GetUniqueFileName(exportZipPath);
//         Debug.Log(exportZipPath);
//         CompressDirectory(buildPath, exportZipPath);
//     }
//
//     private static void CompressDirectory(string buildPath, string zipFileOutputPath)
//     {
//         string exportPath = $"{buildPath}/{EXPORT_PATH}";
//
//         if (!Directory.Exists(exportPath)) Directory.CreateDirectory(exportPath);
//
//         Debug.Log($"attempting to compress {buildPath} into {zipFileOutputPath}");
//
//         string[] excludedPatterns = { "_donotship", "export", ".zip" };
//         string[] fileToAdds = { "Attributions.md", "" };
//
//         EditorUtility.DisplayProgressBar("（ﾉ｡\u2267\u25c7\u2266）ﾉ[COMPRESSING] Please wait...", zipFileOutputPath,
//             .38f);
//         using (ZipFile zip = new())
//         {
//             zip.AddDirectory(buildPath, "");
//
//             foreach (ZipEntry entry in zip.Entries.ToArray())
//             {
//                 string relativePath = entry.FileName;
//
//                 // Vérifie si le chemin correspond à un motif d'exclusion
//                 foreach (string pattern in excludedPatterns)
//                 {
//                     if (!relativePath.ToLower().Contains(pattern)) continue;
//                     zip.RemoveEntry(entry);
//                     break;
//                 }
//
//                 foreach (string fileToAdd in fileToAdds)
//                 {
//                     zip.AddFile($"{Application.dataPath}/Infos/{fileToAdd}");
//                 }
//             }
//
//             zip.Save(zipFileOutputPath);
//         }
//
//         EditorUtility.ClearProgressBar();
//     }
//
//     private static string GetUniqueFileName(string filePath)
//     {
//         string directory = Path.GetDirectoryName(filePath) ?? "";
//         string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(filePath);
//         string extension = Path.GetExtension(filePath);
//
//         char suffix = 'A';
//         string uniqueFilePath;
//
//         do
//         {
//             uniqueFilePath = Path.Combine(directory, $"{fileNameWithoutExtension}-{suffix}{extension}");
//             suffix++;
//         } while (File.Exists(uniqueFilePath) && suffix <= 'Z');
//
//         return uniqueFilePath;
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
//     [MenuItem("Build/Build & Zip")]
//     public static void Build()
//     {
//         string path = $"{Application.dataPath.Replace("Assets", "")}/Builds/";
//         const BuildTarget buildTarget = BuildTarget.StandaloneWindows;
//         const string fileExtension = ".exe";
//
//         EditorUserBuildSettings.SwitchActiveBuildTarget(BuildTargetGroup.Standalone, buildTarget);
//
//         string buildPath = $"{path}{Application.productName}/";
//         string playerPath = buildPath + Application.productName + fileExtension;
//
//         BuildPipeline.BuildPlayer(GetScenePaths(), playerPath, buildTarget, BuildOptions.ShowBuiltPlayer);
//     }
// }
// #endif