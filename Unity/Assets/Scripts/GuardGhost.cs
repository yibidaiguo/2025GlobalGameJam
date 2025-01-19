using System.Collections;
using JKFrame;
using UnityEngine;
using UnityEngine.UI;

public class GuardGhost : MonoBehaviour
{
    public Image image;
    public float timer = 0.1f;
    
    public Animator animator;
    
    private Coroutine coroutine;

    private void Start()
    {
        image.enabled = false;
        EventSystem.AddTypeEventListener<BubbleBoomEvent>(OnBubbleBoom);
        EventSystem.AddTypeEventListener<BlowEvent>(OnBlow);
    }

    private void OnBlow(BlowEvent obj)
    {
        
        
        coroutine = StartCoroutine(Show());
    }

    private void OnBubbleBoom(BubbleBoomEvent obj)
    {
        
        coroutine = StartCoroutine(Show());
    }

    public void StopShowCoroutine()
    {
        if (coroutine!= null)
        {
            StopCoroutine(coroutine);
        }
    }
    
    IEnumerator Show()
    {
        image.enabled = true;
        yield return new WaitForSeconds(timer);
        image.enabled = false;
    }
}
