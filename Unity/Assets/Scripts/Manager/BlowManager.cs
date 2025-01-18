using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using JKFrame;
public class BlowManager : MonoBehaviour
{
    [SerializeField] bool canBlow = true;
    [SerializeField] public float timerDuration = 45f;   //吹风机的冷却时间

    [SerializeField] protected Animator animator;   //吹风机的动画

    private List<GameObject>bubbles = new List<GameObject>();//储存所有泡泡

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
        //鼠标右键
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            Blow();
        }

    }
    private void Blow()//吹飞（删除当前所有对话）
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
i
    IEnumerator BlowTimer()//计算冷却时间
    {
        yield return new WaitForSeconds(timerDuration);
        canBlow = true;
    }
    IEnumerator brustOrder()
    {
        float time = 0;
        //遍历currentlevel.sentenceGroup所有子物体
        foreach (GameObject bubble in GameManager.Instance.currentLevelInfo.sentenceGroup.GetComponentsInChildren<GameObject>(true))
            {
                time += 0.1f; 
                if (bubble != null)
                {   
                    yield return CoroutineTool.WaitForSeconds(time);
                    bubble.GetComponent<BubbleBase>().PlayBubbleBurst();
                    Debug.Log("brust");
                }  
            }
    }

}
