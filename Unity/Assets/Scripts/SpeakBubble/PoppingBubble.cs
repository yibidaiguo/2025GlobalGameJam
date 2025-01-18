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
    /// 泡泡爆炸的回调
    /// </summary>
    private void OnBoom()//泡泡被点击
    {
        PrickManager.Instance.prick(gameObject);
    }

    IEnumerator LifeCountdown()
    {
        yield return CoroutineTool.WaitForSeconds(GameManager.Instance.bubbleConfig.poppingBubbleLifeTime);

        if (!gameObject.IsDestroyed())
        {
            Destroy(gameObject);
        }
    }
}
