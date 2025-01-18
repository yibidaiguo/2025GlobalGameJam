using System;
using System.Collections;
using JKFrame;
using Sirenix.OdinInspector;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BubbleBase : MonoBehaviour
{
    [ShowInInspector]public BubbleData Data;//public 是用于让Prickmanager获得到泡泡种类
    
    [SerializeField] protected Button btn;
    [SerializeField] protected TextMeshProUGUI text;
    
    [SerializeField] protected Animator animator;
    private Coroutine coroutine;
    private bool isSurvive;
    private string currentText = "";
    
    protected virtual void OnEnable()
    {
        if (Data != null)
        {
            text.text = Data.content;
            isSurvive = true;
        }
            
    }
    
    public void SetData(BubbleData data)
    {
        Data = data;
    }

    public virtual void StopContentShow()
    {
        if (coroutine != null)
        {
            StopCoroutine(coroutine);
        }
        isSurvive = false;
    }

    public virtual bool IsSurvive()
    {
        return isSurvive;
    }
    
    public virtual void StartContentShow(Action onComplete = null)
    {
        coroutine = StartCoroutine(ContentShow(onComplete));
    }
    
    
    public virtual IEnumerator ContentShow(Action onComplete = null)
    {
        if (Data != null)
        {
            isSurvive = true;
            
            for (int i = 0; i < Data.content.Length; i++)
            {
                currentText += Data.content[i];
                text.text = currentText;
                yield return CoroutineTool.WaitForSeconds(GameManager.Instance.bubbleConfig.contentTransitionTime);
            }
        }
        onComplete?.Invoke();
    }

    private void OnDestroy()
    {
        isSurvive = false;
    }
}
