using JKFrame;
using UnityEngine;

public class Test : SingletonMono<Test>
{
    public int dialogID;   
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            DialogManager.Instance.ShowDialog(dialogID);
            Debug.Log("开始对话");
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            GameManager.Instance.NextLevel();
            Debug.Log("进入下一关");
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            GameManager.Instance.currentLevelInfo.StartGame();
            Debug.Log("开始游戏");
        }
    }
}
