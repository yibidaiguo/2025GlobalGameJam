using Sirenix.OdinInspector;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "Config/DialogConfig")]
public class DialogConfig : SerializedScriptableObject
{
    [ListDrawerSettings(ShowIndexLabels = true, ShowPaging = false)]
    public List<DialogStepConfig> stepList = new List<DialogStepConfig>();
}
