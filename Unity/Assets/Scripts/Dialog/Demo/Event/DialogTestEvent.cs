using System.Collections;
using UnityEngine;

public class DialogTestEvent : IDialogEvent
{
    public string info;
    public void ConverString(string excelString)
    {
        info = excelString;
    }
    public IEnumerator ExcuteBlocking()
    {
        return null;
    }

    public void Execute()
    {
        Debug.Log(info);
    }
}
