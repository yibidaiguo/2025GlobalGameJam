using System.Collections;
using JKFrame;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : SingletonMono<GameManager>
{
    public LevelSceneConfig levelSceneConfig;
    public BubbleConfig bubbleConfig;
    [ShowInInspector] public int currentLevel { get; private set; }
    public CurrentLevel currentLevelInfo { get; private set; }

    public void NextLevel()//下一关
    {
        int nextLevelIndex = currentLevel + 1;
        if (levelSceneConfig.levels.ContainsKey(nextLevelIndex))
        {
            StartCoroutine(LoadLevel(nextLevelIndex));
        }
    }

    public void StartGame()
    {
        StartCoroutine(LoadLevel(1));
    }

    public void RestartLevel()
    {
        StartCoroutine(LoadLevel(currentLevel));
    }

    public void EnterTargetLevel(int targetLevelID)
    {
        if (levelSceneConfig.levels.ContainsKey(targetLevelID))
        {
            StartCoroutine(LoadLevel(targetLevelID));
        }
    }

    public void ExitLevel()//退出当前关卡
    {
        StartCoroutine(LoadLevel(0));
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void RegisterLevel(CurrentLevel currentLevelInfo)
    {
        if (currentLevelInfo != null)
            this.currentLevelInfo = currentLevelInfo;
    }

    public void UnregisterLevel(CurrentLevel currentLevelInfo)
    {
        if (this.currentLevelInfo == currentLevelInfo)
            this.currentLevelInfo = null;
    }

    IEnumerator LoadLevel(int levelID)
    {
        LevelSceneConfig.LevelInfo levelInfo = levelSceneConfig.levels[levelID];

        if (levelInfo.SceneName != null)
        {
            currentLevel = levelID;
            yield return SceneManager.LoadSceneAsync(levelInfo.SceneName);
            
           yield return StartCoroutine(SceneTransition.Instance.FadeIn());
            
            if (levelInfo.HaveStory)
            {
                bool isContinue = true;
                DialogManager.Instance.ShowDialog(levelInfo.StoryID, 0, () => isContinue = false);
                while (isContinue)
                {
                    yield return null;
                }
            }
        }
    }
}