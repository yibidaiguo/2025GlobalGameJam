using UnityEngine;
using UnityEngine.UI;

public class UIAngryUpdate : MonoBehaviour
{
   public Image image;
   
   void Update()
   {
      float angry = AngryManager.Instance.angry;
      float angryMax = AngryManager.Instance.angryMax;
      
      image.fillAmount = angry / angryMax;
   }
}
