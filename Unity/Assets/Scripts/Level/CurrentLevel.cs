using System;
using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

public class CurrentLevel : MonoBehaviour
{
    [SerializeField] private RectTransform sentenceGroup;
    [ShowInInspector] private int currentLevel;
    [ShowInInspector] private int currentSentenceIndex;
    [ShowInInspector] public Sentence currentSentence { get; private set; }
    [ShowInInspector] public Dictionary<int, Sentence> currentSentencesDic { get; private set; } = new();


    private void OnEnable()
    {
        currentLevel = GameManager.Instance.currentLevel;
        currentSentenceIndex = 0;
        if (currentLevel != 0)
        {
            currentSentencesDic.Clear();
            currentSentencesDic = LevelManager.Instance.GetLevelAllSentence(currentLevel);
        }

        GameManager.Instance.RegisterLevel(this);
    }

    private void OnDisable()
    {
        currentSentencesDic.Clear();
        currentLevel = 0;
        GameManager.Instance.UnregisterLevel(this);
    }
    
    public void StartGame()
    {
        StartCoroutine(LevelShow());
    }
    
    private IEnumerator LevelShow()
    {
        for (int i = 1; i <= currentSentencesDic.Count; i++)
        {
            currentSentenceIndex = i;
            if (currentSentencesDic.TryGetValue(currentSentenceIndex, out var sentence))
            {
                currentSentence = sentence;
                if (currentSentence.words.Count < 1)
                {
                    continue;
                }
                
                yield return StartCoroutine(StartSentence(currentSentence));
                
                //TODO:这里需要进行结算伤害
                
            }

        }
    }

    private IEnumerator StartSentence(Sentence sentence)
    {
        foreach (var word in sentence.words)
        {
            BubbleBase bubble = BubbleDataToType.DataToType(word,sentenceGroup);
            if (bubble == null) continue;
            bool isFinish = false;
            bubble.transform.SetParent(sentenceGroup, false);
            bubble.StartContentShow((() => { isFinish = true; }));
            while (!isFinish)
            {
                yield return null;
            }
        }
    }
}