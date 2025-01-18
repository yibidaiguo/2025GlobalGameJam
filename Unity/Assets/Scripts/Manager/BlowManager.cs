using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using JKFrame;
public class BlowManager : MonoBehaviour
{
    [SerializeField] bool canBlow = true;
    [SerializeField] public float timerDuration = 45f;   //���������ȴʱ��

    [SerializeField] protected Animator animator;   //������Ķ���

    private List<GameObject>bubbles = new List<GameObject>();//������������

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
        //����Ҽ�
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            Blow();
        }

    }
    private void Blow()//���ɣ�ɾ����ǰ���жԻ���
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
    IEnumerator BlowTimer()//������ȴʱ��
    {
        yield return new WaitForSeconds(timerDuration);
        canBlow = true;
    }
    IEnumerator brustOrder()
    {
        float time = 0;
        //����currentlevel.sentenceGroup����������
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
