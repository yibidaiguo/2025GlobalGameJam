using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrickManager : MonoBehaviour
{
    //[SerializeField] protected int prickMax;//prick的次数
    //[SerializeField] protected int prickLeft;//prick剩余次数

    [SerializeField] protected Animator animator;//prick动画

    [SerializeField] protected float prickCD = 0.2f;//prick的CD
    [SerializeField] protected bool canbePrick; 
    public static PrickManager Instance { get; private set; }

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

    public void prick(GameObject gameobject)//戳击一次
    {
        /*
        if (prickLeft >= 0)
        {
            prickLeft--;
            //Todo:显示戳击动画
            //Todo:戳击行为
        }
        */
        
        if(canbePrick)
        {
            //Todo:显示戳击动画
            
            switch ((int)gameobject.GetComponent<BubbleBase>().Data.type)
            {
                case 0: //NormalBubble
                    Debug.Log("NormalBubble");
                    canbePrick = false;
                    StartCoroutine(PrickTimer());
                    break;
                case 1://SpecialBubble
                    Debug.Log("SpecialBubble");
                    //Todo:显示戳破动画
                    Destroy(gameobject);

                    break;
                default:
                    Debug.Log("Error");
                    break;
            }
        }
        
    }

    
    IEnumerator PrickTimer()//读CD
    {
        yield return new WaitForSeconds(prickCD);
        canbePrick = true;
    }


}
