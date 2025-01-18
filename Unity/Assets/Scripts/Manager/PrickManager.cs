using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrickManager : MonoBehaviour
{
    //[SerializeField] protected int prickMax;//prick�Ĵ���
    //[SerializeField] protected int prickLeft;//prickʣ�����

    [SerializeField] protected Animator animator;//prick����

    [SerializeField] protected float prickCD = 0.2f;//prick��CD
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

    public void prick(GameObject gameobject)//����һ��
    {
        /*
        if (prickLeft >= 0)
        {
            prickLeft--;
            //Todo:��ʾ��������
            //Todo:������Ϊ
        }
        */
        
        if(canbePrick)
        {
            //Todo:��ʾ��������
            
            switch ((int)gameobject.GetComponent<BubbleBase>().Data.type)
            {
                case 0: //NormalBubble
                    Debug.Log("NormalBubble");
                    canbePrick = false;
                    StartCoroutine(PrickTimer());
                    break;
                case 1://SpecialBubble
                    Debug.Log("SpecialBubble");
                    //Todo:��ʾ���ƶ���
                    Destroy(gameobject);

                    break;
                default:
                    Debug.Log("Error");
                    break;
            }
        }
        
    }

    
    IEnumerator PrickTimer()//��CD
    {
        yield return new WaitForSeconds(prickCD);
        canbePrick = true;
    }


}
