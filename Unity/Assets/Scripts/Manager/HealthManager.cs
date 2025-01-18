using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//�������е�������Ϊ
public class HealthManager : MonoBehaviour
{
    int healthMax;//����ֵ����
    int health;//����ֵ
    public int damage = 1;//�˺�
    private List<GameObject> harmfulThings;
    public static HealthManager Instance { get; private set; }

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
        health = healthMax;
    }

    public void harmfulThingsAdd(GameObject obj)
    {
        harmfulThings.Add(obj);
    }


    public void HealthCaculate()
    {




        //�����˺�
        foreach (GameObject obj in harmfulThings)
        {
            if (obj != null)
            {
                health -= damage;
                //Todo ��Ѫ����
            }
        }
        //�ж��Ƿ�����
        if (health <= 0)
        {
            //Todo ��������
            //Todo �����߼�
        }
        //����б�
        harmfulThings.Clear();
    }

}

