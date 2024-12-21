using System.Diagnostics;
using UnityEngine;
using Debug = UnityEngine.Debug;

public class EEditorTool
{
    [UnityEditor.MenuItem("Luban/导表 _#&P",priority = -1)]
    public static void ExportExcel()
    {
        Process.Start(new ProcessStartInfo($"{Application.dataPath}/../Luban/MiniTemplate/gen.bat")
        {
            WorkingDirectory = $"{Application.dataPath}/../Luban/MiniTemplate",
            UseShellExecute = true
        });
    }
    
    [UnityEditor.MenuItem("Luban/打开配置表目录 _#&O",priority = -1)]
    public static void OpenExcelFolder()
    {
        Process.Start(new ProcessStartInfo($"{Application.dataPath}/../Luban/DataTables/Datas")
        {
            UseShellExecute = true
        });
    }
}
