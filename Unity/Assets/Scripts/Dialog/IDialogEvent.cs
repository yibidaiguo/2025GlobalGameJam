using System.Collections;

public interface IDialogEvent
{
    public void Execute();
    // 阻塞执行
    public IEnumerator ExcuteBlocking();
    public void ConverString(string excelString);
}
