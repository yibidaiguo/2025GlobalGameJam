using System;
using System.Collections;
using JKFrame;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.UI;

public class BubbleBase : MonoBehaviour
{
    [ShowInInspector]protected BubbleData Data;
    
    [SerializeField] protected Button btn;
    [SerializeField] protected Text text;
    
    [SerializeField] protected Animator animator;
    private string currentText = "";

    protected virtual void OnEnable()
    {
        if (Data!= null)
            text.text = Data.content;
    }
    
    public void SetData(BubbleData data)
    {
        Data = data;
    }

    public virtual void StartContentShow(Action onComplete = null)
    {
        StartCoroutine(ContentShow(onComplete));
    }
    
    public virtual IEnumerator ContentShow(Action onComplete = null)
    {
        if (Data != null)
        {
            for (int i = 0; i < Data.content.Length; i++)
            {
                currentText += Data.content[i];
                text.text = currentText;
                yield return CoroutineTool.WaitForSeconds(GameManager.Instance.bubbleConfig.contentTransitionTime);
            }
        }
        onComplete?.Invoke();
    }
}