using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AngryManager : MonoBehaviour
{
    [SerializeField] protected int angry = 0;
    [SerializeField] protected int angryMax = 100;//爆发时行数
    public static AngryManager Instance { get; private set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }


    public void IncreaseAngry()
    {
        angry++;
    }
    
}
