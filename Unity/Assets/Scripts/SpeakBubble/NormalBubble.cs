using System.Collections;
using JKFrame;
using Unity.VisualScripting;
using UnityEngine;

public class NormalBubble : BubbleBase
{
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
        PrickManager.Instance.prick(gameObject);
    }
    
    IEnumerator LifeCountdown()
    {
        yield return CoroutineTool.WaitForSeconds(GameManager.Instance.bubbleConfig.poppingBubbleLifeTime);
        
        btn.onClick.RemoveListener(OnBoom);
    }
}
