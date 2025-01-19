using System.Collections;
using JKFrame;
using UnityEngine;
using UnityEngine.UI;

public class GuardGhost : MonoBehaviour
{
    
    public Animator animator;
    
    private void Start()
    {
        EventSystem.AddTypeEventListener<BubbleBoomEvent>(OnBubbleBoom);
        EventSystem.AddTypeEventListener<BlowEvent>(OnBlow);
    }

    private void OnBlow(BlowEvent obj)
    {
        animator.SetTrigger("Blow");

    }

    private void OnBubbleBoom(BubbleBoomEvent obj)
    {
        animator.SetTrigger("Stab");

    }
    
}
