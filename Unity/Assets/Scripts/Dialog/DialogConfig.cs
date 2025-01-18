using Sirenix.OdinInspector;
using System.Collections.Generic;
using JKFrame;
using UnityEngine;
[CreateAssetMenu(menuName = "配置/对话配置")]
public class DialogConfig : ConfigBase
{
    [ListDrawerSettings(ShowIndexLabels = true, ShowPaging = false)]
    public List<DialogStepConfig> stepList = new List<DialogStepConfig>();
}
