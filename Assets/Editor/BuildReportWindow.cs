using System.IO;
using UnityEngine;
using UnityEditor;


public class BuildReportWindow : EditorWindow
{
    private static string[] _assetsAndFiles;
    private static string _logFilePath;


    [MenuItem("Window/Build report info")]
    public static void ShowBuildInfo()
    {
        _logFilePath = "";
        GetWindow(typeof(BuildReportWindow));       
    }


    private static bool OpenLogFile()
    {
        _logFilePath = EditorUtility.OpenFilePanel("Choose log file with build report", Application.dataPath, "log");
        return string.IsNullOrEmpty(_logFilePath) ? false : true;       
       
    }
          

    private static void GetBuildReportLog()
    {  
        var reportLog = File.ReadAllText(_logFilePath).
            Split("Used Assets and files from the Resources folder, sorted by uncompressed size:\r\n")[1];
        if(reportLog.Length == 0)
        {
            EditorUtility.DisplayDialog("Message","Report was not generated.","OK");
            return;
        }
        reportLog = reportLog.Split("\r\n---")[0];
        _assetsAndFiles = reportLog.Split("\r\n");     
    }


    private Vector2 scrollPosition;
    private void OnGUI()
    {       
        scrollPosition = EditorGUILayout.BeginScrollView(scrollPosition);
        GUILayout.Label("Assets", EditorStyles.boldLabel);
        GUILayout.TextField(_logFilePath, EditorStyles.boldLabel);

        if (GUILayout.Button("Choose log", GUI.skin.button, GUILayout.Height(25)))
        {
            if (OpenLogFile())
            {
                GetBuildReportLog(); 
               
            }
        }

        if(_logFilePath.Length != 0)
        {
            GUILayout.BeginVertical();
            foreach (var str in _assetsAndFiles)
            {
                var path = str.Split("% ")[1];
                GUILayout.BeginHorizontal();
                if (path.StartsWith("Assets"))
                {
                    var size = str.Split("	 ")[0];
                    GUILayout.Label(size, GUI.skin.box, GUILayout.Width(80), GUILayout.Height(25));
                    if (GUILayout.Button(path, GUI.skin.button, GUILayout.Height(30)))
                    {
                        EditorGUIUtility.PingObject(AssetDatabase.LoadAssetAtPath<Object>(path));
                    }
                }
                GUILayout.EndHorizontal();
            }
            GUILayout.EndVertical();
        }

        EditorGUILayout.EndScrollView();       
        
    }

}


   


