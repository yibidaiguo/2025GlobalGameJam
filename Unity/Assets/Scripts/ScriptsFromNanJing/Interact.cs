using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // ���ڼ��س���
/*
public class Interact : MonoBehaviour
{
    public GameObject player;
    public GameObject interactUI;//������ʾUI
    public GameObject interactText;//��������

    public INManager interactManager;
    private string name;//�����������������

    private bool isPlayerInRange = false;
    public float raycastDistance = 10f; // ���ߵľ���
    public LayerMask interactableLayer; // �ɽ�������Ĳ�
    private Animator animator; // ���ڿ��ƶ��������

    private void Awake()
    {
        interactUI.SetActive(false);
        interactText.SetActive(false);
        animator = GetComponent<Animator>(); // ��ȡ�������
        interactableLayer = LayerMask.GetMask("Interactable"); // ��ȡ�ɽ�������Ĳ�
    }

    private void Update()
    {
        Detect();
        UIupdate();
        if (isPlayerInRange && Input.GetKeyDown(KeyCode.Return)) // ����Ƿ��� Enter ��
        {
            doInteract();
        }
    }
    
    private void Detect()
    {
        Vector3 offset = new Vector3(0, -0.9f, 0); // ƫ����
        Vector3 playerPos = player.transform.position + offset;
        int direct = animator.GetInteger("LastMoveState");
        RaycastHit2D hit = Physics2D.Raycast(playerPos, Vector2.down, raycastDistance, interactableLayer);;
        switch (direct)
        {
            case 0:
                //Debug.Log("��ǰ");
                hit = Physics2D.Raycast(playerPos, Vector2.down, raycastDistance, interactableLayer);
                break;
            case 1:
                //Debug.Log("���");
                hit = Physics2D.Raycast(playerPos, Vector2.up, raycastDistance, interactableLayer);
                break;
            case 2:
                //Debug.Log("����");
                hit = Physics2D.Raycast(playerPos, Vector2.left, raycastDistance, interactableLayer);
                break;
            case 3:
                //Debug.Log("����");
                hit = Physics2D.Raycast(playerPos, Vector2.right, raycastDistance, interactableLayer);
                break;
        }
        if (hit.collider != null)
        {
            //Debug.Log("Hit " + hit.collider.gameObject.name);
            name = hit.collider.gameObject.name;
            isPlayerInRange = true;
        }
        else
        {
            isPlayerInRange = false;
        }
    }
    
    private void UIupdate()
    {
        if (isPlayerInRange)
        {
            interactUI.SetActive(true);
        }
        else
        {
            interactUI.SetActive(false);
        }
    }

    private void doInteract()
    {
        interactUI.SetActive(false);
        interactManager.ObjectName = name;
        interactManager.enabled = true;
        
        interactText.SetActive(true);
        StartCoroutine(WaitForReading());
    }

    IEnumerator WaitForReading()
    {
        //player.GetComponent<PlayerController>().enabled = false;
        while (interactText.activeSelf == true)
            yield return new WaitForSeconds(0);
        //player.GetComponent<PlayerController>().enabled = true;
    }
}
*/