using System;
using System.Collections;
using JKFrame;
using UnityEngine;
using UnityEngine.Serialization;

public class SceneTransition : SingletonMono<SceneTransition>
{
    public Animator fadeAnimator;
    
    public IEnumerator FadeIn(Action onCompleted = null)
    {

        fadeAnimator.gameObject.SetActive(true);
        
        fadeAnimator.Play("Transition");
        yield return null;
        while (fadeAnimator.GetCurrentAnimatorStateInfo(0).normalizedTime < 1)
        {
            yield return null;
        }
        fadeAnimator.gameObject.SetActive(false);
        onCompleted?.Invoke();
    }
    
}
