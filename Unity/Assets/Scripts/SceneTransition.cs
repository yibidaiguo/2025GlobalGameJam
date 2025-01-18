using System;
using System.Collections;
using JKFrame;
using UnityEngine;

public class SceneTransition : SingletonMono<SceneTransition>
{
    public CanvasGroup fadeCanvasGroup;
    
    public IEnumerator FadeIn(Action onCompleted = null)
    {
        if (fadeCanvasGroup == null)
        {
            Debug.LogError("fadeCanvasGroup没有设置!");
            yield break;
        }
        fadeCanvasGroup.alpha = 1;
        while (fadeCanvasGroup.alpha > 0)
        {
            fadeCanvasGroup.alpha -= 0.05f;
            yield return null;
        }
        onCompleted?.Invoke();
    }
    
    public IEnumerator FadeOut(Action onCompleted = null)
    {
        if (fadeCanvasGroup == null)
        {
            Debug.LogError("fadeCanvasGroup没有设置!");
            yield break;
        }
        fadeCanvasGroup.alpha = 0;
        while (fadeCanvasGroup.alpha < 1)
        {
            fadeCanvasGroup.alpha += 0.05f;
            yield return null;
        }
        onCompleted?.Invoke();
    }
}
