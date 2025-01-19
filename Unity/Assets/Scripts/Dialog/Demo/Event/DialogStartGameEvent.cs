using System.Collections;

public class DialogStartGameEvent : IDialogEvent
{
    public void Execute()
    {
        GameManager.Instance.currentLevelInfo.StartGame();
    }

    public IEnumerator ExcuteBlocking()
    {
        yield return null;
    }

    public void ConverString(string excelString)
    {
        
    }
}
