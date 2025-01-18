using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlowManager : MonoBehaviour
{
    [SerializeField] bool canBlow = true;
    [SerializeField] public float timerDuration = 45f;   //吹风机的冷却时间

    [SerializeField] protected Animator animator;   //吹风机的动画

    public static BlowManager Instance { get; private set; }

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

    void Update()
    {
        //鼠标右键
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            Blow();
        }
    }
    private void Blow()//吹飞（删除当前所有对话）
    {
        if (canBlow)
        {
            canBlow = false;
            StartCoroutine(BlowTimer());
            
        }
    }

    IEnumerator BlowTimer()//计算冷却时间
    {
        yield return new WaitForSeconds(timerDuration);
        canBlow = true;
    }

}
