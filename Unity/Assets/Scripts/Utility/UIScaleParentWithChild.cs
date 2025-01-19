using UnityEngine;

public class UIScaleParentWithChild : MonoBehaviour
{
    [SerializeField]private RectTransform childRectTransform;
    [SerializeField]private RectTransform parentRectTransform;
    
    
    void Update()
    {
        if (childRectTransform != null && parentRectTransform != null)
        {
            parentRectTransform.sizeDelta = childRectTransform.sizeDelta;
        }
        
    }
}
