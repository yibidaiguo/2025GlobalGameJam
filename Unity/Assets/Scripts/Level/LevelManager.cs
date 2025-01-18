using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using JKFrame;
using UnityEngine;

public class LevelManager : SingletonMono<LevelManager>
{
    private Dictionary<Level, BubbleData> levelDic = new();
    private Dictionary<string, Type> allEventTypeDic;
    
    

    protected override void Awake()
    {
        base.Awake();
        FindAllBubbleEventType();
        ImportLevelConfig();
    }

    private void ImportLevelConfig()
    {
        foreach (var LevelConfig in ConfigManager.I.Tables.TbLevelConfig.DataMap)
        {
            string[] levelconfig = LevelConfig.Key.Split("-");
            Level level = new Level(int.Parse(levelconfig[0]), int.Parse(levelconfig[1]), int.Parse(levelconfig[2]));
            if (!levelDic.ContainsKey(level))
            {
                levelDic.Add(level, GetBubbleData(LevelConfig.Value));
            }
        }
    }
    
    private BubbleData GetBubbleData(cfg.LevelConfig levelConfig)
    {
        BubbleData bubbleData = new BubbleData(levelConfig.Context,levelConfig.Type);
        bubbleData.onStartEventList = ConverDialogEvent(levelConfig.StartEvent);
        bubbleData.onEndEventList = ConverDialogEvent(levelConfig.EndEvent);
        return bubbleData;
    }

    private List<IBubbleEvent> ConverDialogEvent(string eventString)
    {
        List<IBubbleEvent> eventList = new List<IBubbleEvent>();
        if (string.IsNullOrEmpty(eventString)) return eventList;
        string[] eventStrings = eventString.Split('\n'); // 以回车符分割
        for (int i = 0; i < eventStrings.Length; i++)
        {
            string[] eventStringSplit = eventStrings[i].Split(":");
            if (eventStringSplit.Length != 2) Debug.LogError($"泡泡事件格式不符:{eventStrings[i]}");

            string typeString = eventStringSplit[0];
            string valueString = eventStringSplit[1];
            if (allEventTypeDic.TryGetValue($"Bubble{typeString}Event", out Type eventType))
            {
                IBubbleEvent eventObj = (IBubbleEvent)Activator.CreateInstance(eventType);
                eventObj.ConverString(valueString);
                eventList.Add(eventObj);
            }
            else Debug.LogError($"不存在的对话事件类型:{eventType}");
        }

        return eventList;
    }

    private void FindAllBubbleEventType()
    {
        allEventTypeDic = new Dictionary<string, Type>();
        Type interfaceType = typeof(IBubbleEvent);
        Assembly[] assemblies = AppDomain.CurrentDomain.GetAssemblies(); // 所有程序集
        foreach (Assembly assembly in assemblies)
        {
            Type[] types = assembly.GetTypes().Where(t => interfaceType.IsAssignableFrom(t) && !t.IsAbstract).ToArray();
            foreach (Type type in types)
            {
                allEventTypeDic.Add(type.Name, type);
            }
        }
    }
    
    /// <summary>
    /// 获取指定关卡的所有句子
    /// </summary>
    /// <param name="levelValue">关卡值</param>
    /// <returns></returns>
    public Dictionary<int,Sentence> GetLevelAllSentence(int levelValue)
    {
        Dictionary<int, Sentence> SentenceDic = new();
        foreach (Level level in levelDic.Keys)
        {
            if (level.level == levelValue)
            {
                if (!SentenceDic.ContainsKey(level.sentence))
                {
                    Sentence sentence = new Sentence(new List<BubbleData> { levelDic[level] });
                    SentenceDic.Add(level.sentence, sentence);
                }
                else
                {
                    SentenceDic[level.sentence].words.Add(levelDic[level]);
                }
            }
        }

        return SentenceDic;
    }
    /// <summary>
    /// 获取指定关卡指定句子的所有泡泡
    /// </summary>
    /// <param name="levelValue">关卡值</param>
    /// <param name="sentenceValue">句子值</param>
    /// <returns></returns>
    public List<BubbleData> GetBubblesWithLevelAndSentenceValue(int levelValue,int sentenceValue)
    {
        return levelDic
            .Where(kvp => kvp.Key.level == levelValue && kvp.Key.sentence == sentenceValue)
            .Select(kvp => kvp.Value)
            .ToList();
    }
    
}

public struct Level : IEquatable<Level>
{
    public int level;
    public int sentence;
    public int word;

    public Level(int level, int sentence, int word)
    {
        this.level = level;
        this.sentence = sentence;
        this.word = word;
    }

    public bool Equals(Level other)
    {
        return level == other.level && sentence == other.sentence && word == other.word;
    }

    public override bool Equals(object obj)
    {
        return obj is Level other && Equals(other);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(level, sentence, word);
    }
}