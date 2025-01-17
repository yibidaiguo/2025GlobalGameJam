using Sirenix.OdinInspector;
using System.Collections.Generic;
using UnityEngine;

public class DialogStepConfig
{
    public bool player;
    [HideLabel, Multiline(2)] public string content;
    public List<IDialogEvent> onStartEventList = new List<IDialogEvent>();
    public List<IDialogEvent> onEndEventList = new List<IDialogEvent>();
    public string iconName;
    public string spakerName;
}

