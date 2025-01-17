using System.Collections;
using JKFrame;
using Unity.VisualScripting;

public class PoppingBubble : BubbleBase
{

    protected override void OnEnable()
    {
        base.OnEnable();
        btn.onClick.AddListener(OnBoom);
        StartCoroutine(LifeCountdown());
    }
    
    /// <summary>
    /// 泡泡爆炸的事件
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
