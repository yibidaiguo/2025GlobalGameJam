using System.Collections.Generic;
using System.IO;
using JKFrame;
using Sirenix.OdinInspector;
using UnityEditor;
using UnityEngine;

[CreateAssetMenu(menuName = "配置/对话索引配置",fileName = "对话索引配置")]
public class DialogIndexConfig : ConfigBase
{
    [Header("对话文件配置路径")]
    public string dialogConfigPath;
    
    public Dictionary<int,DialogConfig> dialogIndex = new();

    [Button("导入对话配置")]
    public void ImportDialogConfig()
    {
        ImportDialogConfig(dialogConfigPath);
    }

    private void ImportDialogConfig(string path)
    {
        dialogIndex.Clear();
        
        string[] files = Directory.GetFiles(path);
        int index = 40000;
        foreach (string file in files)
        {
            if (Path.GetExtension(file) == ".asset")
            {
                index++;
                DialogConfig asset = AssetDatabase.LoadAssetAtPath<DialogConfig>(file);
                dialogIndex[index] = asset;
            }
        }

        string[] directories = Directory.GetDirectories(path);
        foreach (string directory in directories)
        {
            ImportDialogConfig(directory);
        }
    }
}
