using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlowManager : MonoBehaviour
{
    [SerializeField] bool canBlow = true;
    [SerializeField] public float timerDuration = 45f;   //���������ȴʱ��

    [SerializeField] protected Animator animator;   //������Ķ���

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
        //����Ҽ�
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            Blow();
        }
    }
    private void Blow()//���ɣ�ɾ����ǰ���жԻ���
    {
        if (canBlow)
        {
            canBlow = false;
            StartCoroutine(BlowTimer());
            
        }
    }

    IEnumerator BlowTimer()//������ȴʱ��
    {
        yield return new WaitForSeconds(timerDuration);
        canBlow = true;
    }

}
