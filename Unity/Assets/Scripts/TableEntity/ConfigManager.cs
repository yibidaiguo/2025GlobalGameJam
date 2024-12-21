using System;
using System.IO;
using cfg;
using Luban;
using UnityEngine;

public class ConfigManager
{
    private Tables tables;
    public Tables Tables => tables;
    private void Init()
    {
        // 读取配置文件
        this.tables = new Tables(LoadByteBuf);
    }
    private static ByteBuf LoadByteBuf(string file)
    {
        //string filePath = $"{Application.dataPath}/../../GenerateDatas/bytes/{file}.bytes";
        string filePath = $"Config/GenerateDatas/bytes/{file}";
        return new ByteBuf(Resources.Load<TextAsset>(filePath).bytes);
    }
    #region Singleton

    private static readonly Lazy<ConfigManager> single = new Lazy<ConfigManager>(() =>
    {
        var instance = new ConfigManager();
        instance.Init();
        return instance;
    });

    private ConfigManager()
    {
    }

    public static ConfigManager I => single.Value;

    #endregion
}