using System.Collections;
using System.Collections.Generic;
using cfg;

public class BubbleData
{
    public string content;
    public BubbleType type;
    public List<IBubbleEvent> onStartEventList = new();
    public List<IBubbleEvent> onEndEventList = new();

    public BubbleData(string content,BubbleType type)
    {
        this.content = content;
        this.type = type;
    }
}

public interface IBubbleEvent
{
    public void Execute();
    // 阻塞执行
    public IEnumerator ExcuteBlocking();
    public void ConverString(string excelString);
}

public struct Sentence
{
    public List<BubbleData> words;
    
    public Sentence(List<BubbleData> words)
    {
        this.words = words ?? new List<BubbleData>();
    }
}