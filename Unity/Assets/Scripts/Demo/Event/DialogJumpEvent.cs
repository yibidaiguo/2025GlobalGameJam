using System.Collections;
using JKFrame;

public class DialogJumpEvent : IDialogEvent
{
    public string targetDialogID;
    public int targetStepIndex;
    public void ConverString(string excelString)
    {
        string[] args = excelString.Split(",");
        targetDialogID = args[0];
        targetStepIndex = int.Parse(args[1]);
    }

    public IEnumerator ExcuteBlocking()
    {
        return null;
    }

    public void Execute()
    {
        DialogConfig dialogConfig = DialogManager.Instance.GetDialogConfig(targetDialogID);
        Player player = UISystem.GetWindow<UI_DialogWindow>().player;
        NPC npc = DialogManager.Instance.npc1;
        UISystem.GetWindow<UI_DialogWindow>().Close();
        UISystem.GetWindow<UI_DialogWindow>().StartDialog(dialogConfig, npc, player, targetStepIndex);
    }
}
