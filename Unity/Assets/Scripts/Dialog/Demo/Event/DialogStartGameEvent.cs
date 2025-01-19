using System.Collections;

public class DialogStartGameEvent : IDialogEvent
{
    public void Execute()
    {
        GameManager.Instance.currentLevelInfo.StartGame();
    }

    public IEnumerator ExcuteBlocking()
    {
        throw new System.NotImplementedException();
    }

    public void ConverString(string excelString)
    {
        
    }
}
