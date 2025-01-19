using System.Collections.Generic;
using System.Linq;
using JKFrame;
using UnityEngine;
using cfg;
//管理所有的受伤行为
public class HealthManager : SingletonMono<HealthManager>
{
    public int healthMax = 100;//生命值上限
    public int health;//生命值
    public int damage = 1;//伤害
    private List<GameObject> harmfulThings = new ();
    
    protected override void Awake()
    {
        base.Awake();
        health = healthMax;
    }

    public void HealthCaculate()
    {
        //炸
        foreach (BubbleBase bubble in GameManager.Instance.currentLevelInfo.sentenceGroup.GetComponentsInChildren<BubbleBase>(true))
            { 
                if (bubble != null)
                {   
                    bubble.PlayBubbleBurst();
                } 
            }
        //计算伤害
        int countPassed = 0;
        int countNow = 0;
        int badcount = 0;
        foreach (BubbleBase bubble in GameManager.Instance.currentLevelInfo.sentenceGroup.GetComponentsInChildren<BubbleBase>(true))
        {
            if(bubble.Data.type == BubbleType.NormalBubble)
            {   
                countNow ++;
            }
            else
            {
                badcount ++;
            }
        }
        foreach(BubbleData bubble in GameManager.Instance.currentLevelInfo.currentSentence.words)
        {
            if(bubble.type == BubbleType.NormalBubble)
            {   
                countPassed ++;
            }
        }


        //计算伤害
        health -= (countPassed - countNow + badcount)* damage;

        //判断是否死亡
        if (health <= 0)
        {
            //Todo 死亡动画
        }

        //清空列表
        harmfulThings.Clear();
    }

    public void GoNextLevel()
    {
        Debug.Log("GoNextLevel");
        int maxkey = GameManager.Instance.currentLevelInfo.currentSentencesDic.Keys.Max();
        Debug.Log(maxkey);
        if (GameManager.Instance.currentLevelInfo.currentSentenceIndex == maxkey)
        {
            Debug.Log("通关");
            GameManager.Instance.NextLevel();
        }
    }

}

