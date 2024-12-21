using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // 用于加载场景
/*
public class Interact : MonoBehaviour
{
    public GameObject player;
    public GameObject interactUI;//交互提示UI
    public GameObject interactText;//交互文字

    public INManager interactManager;
    private string name;//交互到的物体的名字

    private bool isPlayerInRange = false;
    public float raycastDistance = 10f; // 射线的距离
    public LayerMask interactableLayer; // 可交互物体的层
    private Animator animator; // 用于控制动画的组件

    private void Awake()
    {
        interactUI.SetActive(false);
        interactText.SetActive(false);
        animator = GetComponent<Animator>(); // 获取动画组件
        interactableLayer = LayerMask.GetMask("Interactable"); // 获取可交互物体的层
    }

    private void Update()
    {
        Detect();
        UIupdate();
        if (isPlayerInRange && Input.GetKeyDown(KeyCode.Return)) // 检测是否按下 Enter 键
        {
            doInteract();
        }
    }
    
    private void Detect()
    {
        Vector3 offset = new Vector3(0, -0.9f, 0); // 偏移量
        Vector3 playerPos = player.transform.position + offset;
        int direct = animator.GetInteger("LastMoveState");
        RaycastHit2D hit = Physics2D.Raycast(playerPos, Vector2.down, raycastDistance, interactableLayer);;
        switch (direct)
        {
            case 0:
                //Debug.Log("向前");
                hit = Physics2D.Raycast(playerPos, Vector2.down, raycastDistance, interactableLayer);
                break;
            case 1:
                //Debug.Log("向后");
                hit = Physics2D.Raycast(playerPos, Vector2.up, raycastDistance, interactableLayer);
                break;
            case 2:
                //Debug.Log("向左");
                hit = Physics2D.Raycast(playerPos, Vector2.left, raycastDistance, interactableLayer);
                break;
            case 3:
                //Debug.Log("向右");
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