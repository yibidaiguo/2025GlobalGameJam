using System.Collections.Generic;
using JKFrame;
using UnityEngine;

[CreateAssetMenu(menuName = "配置/对话索引配置",fileName = "对话索引配置")]
public class DialogIndexConfig : ConfigBase
{
    public Dictionary<int,DialogConfig> dialogIndex = new();
}
