using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogEnterLevelEvent : IDialogEvent
{
    public int targetLevelID;
    public void Execute()
    {
        GameManager.Instance.EnterTargetLevel(targetLevelID);
    }

    public IEnumerator ExcuteBlocking()
    {
        throw new System.NotImplementedException();
    }

    public void ConverString(string excelString)
    {
        targetLevelID = int.Parse(excelString);
    }
}
