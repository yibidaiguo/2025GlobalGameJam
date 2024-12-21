using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine.UIElements.Experimental;
using UnityEngine.SceneManagement;
/*
public class INManager : MonoBehaviour
{
    public GameObject interactText;//交互文字
    public TextMeshProUGUI speakerName;     //发言者姓名
    public TextMeshProUGUI speakingContent; //发言内容
    private List<ExcelReader.ExcelData> storyData; //(string)speaker ，(string)content
    private string filePath; //文本文件路径

    public string ObjectName; //对象名
    private int currentLine = 0; //当前行数


    string sceneName;
    //场景 地窖
    private bool key = false;

    //场景 街道
    private bool medication = false;
    public GameObject _medication;

    //场景 6安全屋
    private bool a1 = false;
    private bool a2 = false;
    private bool a3 = false;
    //场景 7rijun
    private int count = 0;//计数器交互到的尸体数
    private bool key1 = false;


    void Awake()
    {
        Scene currentScene = SceneManager.GetActiveScene();

        sceneName = currentScene.name;
    }

    void OnEnable()
    {
        switch (sceneName)
        {
            case "2dijiao":
                switch (ObjectName)
                {
                    case "Bed":
                        if (key == false)
                        {
                            filePath = "Story/BedInteract.xlsx";
                            key = true;
                        }
                        else
                        {
                            filePath = "Story/BedInteract2.xlsx";
                        }
                        break;
                    case "Desk":
                        filePath = "Story/DeskInteract.xlsx";
                        break;
                    case "Door":
                        if(key == false)
                        {    
                            filePath = "Story/DoorInteract.xlsx";
                            break;
                        }
                        else
                        {
                            // 获取当前场景的索引
                            int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
                            // 加载下一个场景
                            SceneManager.LoadScene(currentSceneIndex + 1);
                            break;
                        }
                }
                break;
            case "3Home":
                switch (ObjectName)
                {
                    case "CellarEntrance":
                        filePath = Constants.CellarInteract;
                        break;

                    case "Book":
                        filePath = Constants.book;
                        break;


                    case "cabinet":
                        filePath = Constants.cabinet;
                        break;

                    case "Kitcheen":
                        filePath = Constants.kitchen;
                        break;


                }
                break;
            case "4jiedao":
                switch (ObjectName)
                {
                    case "HomeDoor":
                        filePath = Constants.HomeDoor; 
                        break;
                    case "ShopDoor":
                        filePath = Constants.shopDoor;
                        break;
                    case "man":
                        if(medication == false)
                            filePath = Constants.ManInteract;
                        else 
                        {
                            SceneManager.LoadScene("1wenzi4");
                            
                        }
                        break;
                    case "medication":
                        
                        medication = true;
                        filePath = Constants.medication;
                        _medication .SetActive(false);
                        break;
                    case "nextscene":
                        SceneManager.LoadScene("5chenmei");
                        break;
                }
                break;
            case "6anquanwu":
                switch (ObjectName)
                {
                    case "labei":
                        a1 = true;
                        filePath = Constants.STORY_PATHLABEI;
                        break;
                    case "woman":
                        a2 = true;
                        filePath = Constants.STORY_PATHWOMAN;
                        break;
                    case "woker":
                        a3 = true;
                        filePath = Constants.STORY_PATHWOKER;
                        break;
                }
                if (a1 && a2 && a3)
                {
                    SceneManager.LoadScene("1wenzi14");
                }
                break;
            case "7rijun":
                switch (ObjectName)
                {
                    case "body1":
                    case "body2":
                    case "body3":
                    case "body4":
                    case "body5":
                    case "body6":
                        if(count < 4 )
                        {
                            
                            switch (count)
                            {
                                case 0:
                                    filePath = Constants.STORY_PATHriJun1;
                                    break;
                                case 1:
                                    filePath = Constants.STORY_PATHriJun2;
                                    break;
                                case 2:
                                    filePath = Constants.STORY_PATHriJun3;
                                    break;
                                case 3:
                                    filePath = Constants.STORY_PATHriJun4;
                                    break;
                            }
                            count++;
                        }
                        break;
                    case "labei":
                        if (count < 4 )
                        {
                            filePath = Constants.STORY_PATHlabei;
                        }
                        else
                        {
                            SceneManager.LoadScene("1wenzi10");
                        }
                        break;
                }
                break;
        }
        
        LoadStoryFromFile(filePath);
        DisplayNextLine();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)|| Input.GetKeyDown(KeyCode.Return))
        {
            DisplayNextLine();
        }
    }
    void LoadStoryFromFile(string path)//读取文件到storyData
    {
        Debug.Log("Loading story from file: " + path);
        storyData = ExcelReader.ReadExcel(path);

        if (storyData == null || storyData.Count == 0)
        {
            Debug.LogError("No Data found in the file");
        }

    }

    void DisplayNextLine()//显示下一行
    {
        var data = storyData[currentLine];

        if (data.content == "end!!")
        {
            this.enabled = false;
            interactText.SetActive(false);
            currentLine = 0;
            return;
        }


        
        speakerName.text = data.speaker;
        speakingContent.text = data.content;

        
        currentLine++;
    }
}
*/