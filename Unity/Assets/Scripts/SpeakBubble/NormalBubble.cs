using System.Collections;
using JKFrame;
using UnityEngine;

public class NormalBubble : BubbleBase
{
    public static readonly int IsDie = Animator.StringToHash("IsDie");

    protected override void OnEnable()
    {
        base.OnEnable();
        btn.onClick.AddListener(OnBoom);
        StartCoroutine(LifeCountdown());
    }
    
    /// <summary>
    /// 泡泡爆炸的回调
    /// </summary>

    private void OnBoom()//泡泡被点击
    {
        animator.SetTrigger("IsDie");
        PlayBurstSound();
        EventSystem.TypeEventTrigger(new BubbleBoomEvent());
        isSurvive = false;
    }
    
    IEnumerator LifeCountdown()
    {
        yield return CoroutineTool.WaitForSeconds(GameManager.Instance.bubbleConfig.poppingBubbleLifeTime);
        
        btn.onClick.RemoveListener(OnBoom);
    }
}

public struct BubbleBoomEvent
{
    
}
