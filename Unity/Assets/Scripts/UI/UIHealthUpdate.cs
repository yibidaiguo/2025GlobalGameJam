using UnityEngine;
using UnityEngine.UI;

public class UIHealthUpdate : MonoBehaviour
{
    public Image image;

    void Update()
    {
        float health = HealthManager.Instance.health;
        float healthMax = HealthManager.Instance.healthMax;
        
        image.fillAmount = health / healthMax;
        
    }
}
