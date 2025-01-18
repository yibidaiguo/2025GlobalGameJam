using System.Collections.Generic;
using JKFrame;
using Sirenix.OdinInspector;
using UnityEngine;

[CreateAssetMenu(fileName = "新关卡配置", menuName = "配置/关卡配置")]
public class LevelSceneConfig : ConfigBase
{
    [DictionaryDrawerSettings(KeyLabel = "关卡", ValueLabel = "关卡信息")]
    public Dictionary<int, LevelInfo> levels = new();

    public struct LevelInfo
    {
        [LabelText("关卡名称")] public string SceneName;
        [LabelText("是否有剧情")] public bool HaveStory;
        [LabelText("剧情ID")] public int StoryID;
    }
}