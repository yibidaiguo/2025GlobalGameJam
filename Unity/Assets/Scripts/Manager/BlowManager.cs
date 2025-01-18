using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using JKFrame;

public class BlowManager : MonoBehaviour
{
    [SerializeField] bool canBlow = true;
    [SerializeField] public float timerDuration = 45f;

    [SerializeField] private Animator animator;

    private List<GameObject> bubbles = new List<GameObject>();

    public static BlowManager Instance { get; private set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
            Debug.LogError("Duplicate BlowManager found!");
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            Blow();
        }
    }

    private void Blow()
    {
        if (canBlow)
        {
            canBlow = false;
            StartCoroutine(BlowTimer());
            GameManager.Instance.currentLevelInfo.StopSentenceCoroutine();
            Debug.Log("Blow");
            StartCoroutine(brustOrder());
        }
    }

    public void AddBubble(GameObject bubble)
    {
        bubbles.Add(bubble);
    }

    IEnumerator BlowTimer()
    {
        yield return new WaitForSeconds(timerDuration);
        canBlow = true;
    }

    IEnumerator brustOrder()
    {
        float time = 0.1f;

        foreach (BubbleBase bubble in GameManager.Instance.currentLevelInfo.sentenceGroup
                     .GetComponentsInChildren<BubbleBase>(true))
        {
            if (bubble != null)
            {
                yield return CoroutineTool.WaitForSeconds(time);
                bubble.PlayBubbleBurst();
                Debug.Log("brust");
            }
        }
    }
}