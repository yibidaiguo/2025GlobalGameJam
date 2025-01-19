using System;
using JKFrame;
using UnityEngine;
using UnityEngine.UI;

public class AngryManager : MonoBehaviour
{
    public int angry = 0;
    public int angryMax = 100; //爆发时行数
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

    private void Update()
    {
        if (angry >= angryMax)
        {
            AudioSystem.PlayOneShot(ResSystem.LoadAsset<AudioClip>("hongwenle"));
        }
    }
}