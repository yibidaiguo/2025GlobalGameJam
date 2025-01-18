using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIScaleParentWithChild : MonoBehaviour
{
    [SerializeField]private TextMeshProUGUI childTextMeshProUGUI;
    [SerializeField]private Button parentButton;
    
    
    void Update()
    {

        RectTransform childRectTransform = childTextMeshProUGUI.rectTransform;

        RectTransform parentRectTransform = parentButton.transform as RectTransform;
        
        parentRectTransform.sizeDelta = childRectTransform.sizeDelta;
    }
}
