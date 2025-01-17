using System.Collections;
using JKFrame;

public class DialogJumpEvent : IDialogEvent
{
    public int targetDialogID;
    public int targetStepIndex;
    public void ConverString(string excelString)
    {
        string[] args = excelString.Split(",");
        targetDialogID = int.Parse(args[0]);
        targetStepIndex = int.Parse(args[1]);
    }

    public IEnumerator ExcuteBlocking()
    {
        return null;
    }

    public void Execute()
    {
        DialogConfig dialogConfig = DialogManager.Instance.GetDialogConfig(targetDialogID);
        UISystem.Close<UI_DialogWindow>();
        UISystem.Show<UI_DialogWindow>().StartDialog(dialogConfig, targetStepIndex);
    }
}
