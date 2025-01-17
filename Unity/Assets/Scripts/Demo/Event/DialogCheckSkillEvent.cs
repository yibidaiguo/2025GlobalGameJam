using System.Collections;
using JKFrame;

public class DialogCheckSkillEvent : IDialogEvent
{
    public void ConverString(string excelString)
    {
    }

    public IEnumerator ExcuteBlocking()
    {
        return null;
    }

    public void Execute()
    {
        if (Player.Instance.currentSkill != null)
        {
            UISystem.Close<UI_DialogWindow>();
        }
    }
}
