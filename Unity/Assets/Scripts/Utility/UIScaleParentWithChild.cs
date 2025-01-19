using UnityEngine;

public class UIScaleParentWithChild : MonoBehaviour
{
    [SerializeField]private RectTransform childRectTransform;
    [SerializeField]private RectTransform parentRectTransform;
    [SerializeField] private float parameter = 1f;
    
    
    void Update()
    {
        if (childRectTransform != null && parentRectTransform != null)
        {
            parentRectTransform.sizeDelta = childRectTransform.sizeDelta * parameter;
        }
        
    }
}
