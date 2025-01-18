using System;
using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

public class CurrentLevel : MonoBehaviour
{
    [SerializeField] private RectTransform sentenceGroup;
    [ShowInInspector] private int currentLevel;//当前对话
    [ShowInInspector] private int currentSentenceIndex;//当前对话的索引
    [ShowInInspector] public Sentence currentSentence { get; private set; }
    [ShowInInspector] public Dictionary<int, Sentence> currentSentencesDic { get; private set; } = new();


    private Coroutine sentenceCoroutine;
    private bool sentenceActive;
    
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

    public void StopSentenceCoroutine()
    {
        if (sentenceCoroutine != null)
            StopCoroutine(sentenceCoroutine);
        sentenceActive = false;
    }
    
    private IEnumerator LevelShow()
    {
        for (int i = 1; i <= currentSentencesDic.Count; i++)
        {
            sentenceActive = true;
            currentSentenceIndex = i;
            if (currentSentencesDic.TryGetValue(currentSentenceIndex, out var sentence))
            {
                currentSentence = sentence;
                if (currentSentence.words.Count < 1)
                {
                    continue;
                }
                bool isFinish = false;
                

                sentenceCoroutine = StartCoroutine(StartSentence(currentSentence, ()=>isFinish = true));

                while (!isFinish)
                {
                    yield return null;
                    if (!sentenceActive) break;
                }

                
                yield return StartCoroutine(StartSentence(currentSentence));
                
                sentenceEnd();
            }

        }
    }


    private void sentenceEnd()//每句话的结束
    {
        AngryManager.Instance.IncreaseAngry();
        HealthManager.Instance.HealthCaculate();
    }

    
    private IEnumerator StartSentence(Sentence sentence,Action onComplete = null)
    {
        for (int i = 0; i < sentence.words.Count; i++)

        {
            BubbleBase bubble = BubbleDataToType.DataToType(sentence.words[i]);
            if (bubble == null) continue;
            bool isFinish = false;

            if ((int)bubble.Data.type == 1)
                HealthManager.Instance.harmfulThingsAdd(bubble.gameObject);
            
            
            bubble.transform.SetParent(sentenceGroup);
            
            bubble.StartContentShow(() => { isFinish = true; });
            while (!isFinish)
            {
                yield return null;
                if(!bubble.IsSurvive()) break;
            }

        }
        onComplete?.Invoke();

    }

}
