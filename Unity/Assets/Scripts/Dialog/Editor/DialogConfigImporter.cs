using UnityEngine;
using UnityEditor;
using System.IO;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Linq;

public static class DialogConfigImporter
{
    private static string soDirPath = "Assets/Config/SO/Dialog";
    private static string excelDirPath = "Assets/Config/Excel/Dialog";
    private static Dictionary<string, Type> allEventTypeDic;
    [MenuItem("Porject/DialogConfigImporter")]
    public static void ImprotAll()
    {
        FindAllDialogEventType();

        // 遍历全部的Excel文件
        string[] filePaths = Directory.GetFiles(excelDirPath, "*.*", SearchOption.AllDirectories);
        foreach (string filePath in filePaths)
        {
            // 过滤掉meta文件、临时文件（~$）
            if (filePath.EndsWith(".meta") || filePath.Contains("~$")) continue;
            string fullPath = $"{Application.dataPath.Replace("/Assets", "")}/{filePath}";
            ImprotExcel(fullPath);
        }
        AssetDatabase.SaveAssets();
        AssetDatabase.Refresh();
        Debug.Log("DialogConfigImport Succeed");
    }

    private static void ImprotExcel(string excelPath)
    {
        FileInfo fileInfo = new FileInfo(excelPath);
        string configPath = $"{soDirPath}/{Path.GetFileNameWithoutExtension(fileInfo.Name)}.asset";
        DialogConfig dialogConfig = AssetDatabase.LoadAssetAtPath<DialogConfig>(configPath);
        bool create = dialogConfig == null;
        if (create) dialogConfig = ScriptableObject.CreateInstance<DialogConfig>();

        using (ExcelPackage excelPackage = new ExcelPackage(fileInfo))
        {
            ExcelWorksheet worksheet = excelPackage.Workbook.Worksheets[1]; // EPPlus的很多开头都是从1开始
            int maxCol = worksheet.Cells.Columns;
            dialogConfig.stepList.Clear();
            for (int y = 2; y < maxCol; y++)
            {
                if (string.IsNullOrEmpty(worksheet.Cells[y, 1].Text.Trim())) break;
                DialogStepConfig step = new DialogStepConfig();
                step.player = Convert.ToBoolean(worksheet.Cells[y, 1].Value);
                step.content = worksheet.Cells[y, 2].Text.Trim();
                step.onStartEventList = ConverDialogEvent(worksheet.Cells[y, 3].Text.Trim());
                step.onEndEventList = ConverDialogEvent(worksheet.Cells[y, 4].Text.Trim());
                dialogConfig.stepList.Add(step);
            }
        }

        if (create) AssetDatabase.CreateAsset(dialogConfig, configPath);
        else EditorUtility.SetDirty(dialogConfig);
    }


    private static List<IDialogEvent> ConverDialogEvent(string eventString)
    {
        List<IDialogEvent> eventList = new List<IDialogEvent>();
        if (string.IsNullOrEmpty(eventString)) return eventList;
        string[] eventStrings = eventString.Split('\n'); // 以回车符分割
        for (int i = 0; i < eventStrings.Length; i++)
        {
            string[] eventStringSplit = eventStrings[i].Split(":");
            if (eventStringSplit.Length != 2) Debug.LogError($"对话事件格式不符:{eventStrings[i]}");

            string typeString = eventStringSplit[0];
            string valueString = eventStringSplit[1];
            if (allEventTypeDic.TryGetValue($"Dialog{typeString}Event", out Type eventType))
            {
                IDialogEvent eventObj = (IDialogEvent)Activator.CreateInstance(eventType);
                eventObj.ConverString(valueString);
                eventList.Add(eventObj);
            }
            else Debug.LogError($"不存在的对话事件类型:{eventType}");
        }
        return eventList;
    }

    private static void FindAllDialogEventType()
    {
        allEventTypeDic = new Dictionary<string, Type>();
        Type interfaceType = typeof(IDialogEvent);
        Assembly[] assemblies = AppDomain.CurrentDomain.GetAssemblies(); // 所有程序集
        foreach (Assembly assembly in assemblies)
        {
            Type[] types = assembly.GetTypes().Where(t => interfaceType.IsAssignableFrom(t) && !t.IsAbstract).ToArray();
            foreach (Type type in types)
            {
                allEventTypeDic.Add(type.Name, type);
            }
        }
    }
}
