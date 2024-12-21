using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine.UIElements.Experimental;
using UnityEngine.SceneManagement;
/*
public class VNManager : MonoBehaviour
{
    public TextMeshProUGUI speakerName;     //发言者姓名
    public TextMeshProUGUI speakingContent; //发言内容
    public GameObject interactText;       //发言文本框


    private string filePath = Constants.STORY_PATH; //故事文件路径
    private List<ExcelReader.ExcelData> storyData;  //(string)speaker ，(string)content
    private int currentLine = 0;    //当前行数

    void Start()
    {
        Scene currentScene = SceneManager.GetActiveScene();

        string sceneName = currentScene.name;
        interactText.SetActive(true);
        switch (sceneName)
        {   
            
            case "1wenzi":
                filePath = Constants.STORY_PATH;
                break;
            case "1wenzi2":
                filePath = Constants.STORY_PATH1;
                break;
            case "1wenzi3":
                filePath = Constants.STORY_PATH2;
                break;
            case "1wenzi4":
                filePath = Constants.STORY_PATH3;
                break;
            case "1wenzi5":
                filePath = Constants.STORY_PATH4;
                break;
            case "1wenzi6":
                filePath = Constants.STORY_PATH5;
                break;
            case "1wenzi7":
                filePath = Constants.STORY_PATH6;
                break;
            case "1wenzi8":
                filePath = Constants.STORY_PATH7;
                break;
            case "1wenzi9":
                filePath = Constants.STORY_PATH8;
                break;
            case "1wenzi10":
                filePath = Constants.STORY_PATH9;
                break;
            case "1wenzi11":
                filePath = Constants.STORY_PATH10;
                break;
            case "1wenzi12":
                filePath = Constants.STORY_PATH11;
                break;
            case "1wenzi13":
                filePath = Constants.STORY_PATH12;
                break;
            case "1wenzi14":
                filePath = Constants.STORY_PATH13;
                break;
            case "1wenzi15":
                filePath = Constants.STORY_PATH14;
                break;
            case "1wenzi16":
                filePath = Constants.STORY_PATH15;
                break;
            case "1wenzi17":
                filePath = Constants.STORY_PATH16;
                break;
            case "1wenzi18":
                filePath = Constants.STORY_PATH17;
                break;
            case "1wenzi19":
                filePath = Constants.STORY_PATH18;
                break;
            case "1wenzi20":
                filePath = Constants.STORY_PATH19;
                break;
            case "1wenzi21":
                filePath = Constants.STORY_PATH20;
                break;
            case "1wenzi22":
                filePath = Constants.STORY_PATH21;
                break;
            case "1wenzi23":
                filePath = Constants.STORY_PATH22;
                break;
            case "1wenzi24":
                filePath = Constants.STORY_PATH23;
                break;
            case "1wenzi25":
                filePath = Constants.STORY_PATH24;
                break;
            case "2dijiao":
                filePath = Constants.STORY_PATHdiJiao;
                break;
            
            case "4jiedao":
                filePath = Constants.STORY_PATHjieDao;
                break;

            //case "5":

            case "7rijun":
                filePath = Constants.STORY_PATHriJun;
                break;
            default:
                Debug.LogError("Invalid scene name: " + sceneName);
                break;
        }

        LoadStoryFromFile(filePath);
        DisplayNextLine();
        
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Return))
        {
            DisplayNextLine();
        }

    }


    void LoadStoryFromFile(string path)//读取文件到storyData
    {

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
            // 获取当前场景的索引
            int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
            if (currentSceneIndex == 6)
            {
                SceneManager.LoadScene("1wenzi6");
                return;
            }
            // 加载下一个场景
            SceneManager.LoadScene(currentSceneIndex + 1);
            return;
        }
        else if (data.content == "start!!")
        {
            interactText.SetActive(false);
            this.gameObject.SetActive(false);
            return;
        }


        
        speakerName.text = data.speaker;
        speakingContent.text = data.content;

        
        currentLine++;
    }
}
*/
