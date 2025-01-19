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
    
    public BGMConfig normalBGMConfig;
    public BGMConfig fightBGMConfig;
    private Coroutine bgmCoroutine;

    void Start()
    {
        StartBgm(normalBGMConfig);
        AudioSystem.EffectVolume = 1f;
        AudioSystem.BGVolume = 0.5f;
    }
    
    public void NextLevel()
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

    public void GameOver()
    {
        ExitLevel();
        AudioSystem.PlayOneShot(ResSystem.LoadAsset<AudioClip>("gameover"));
        StartCoroutine(PlayBgm(normalBGMConfig));
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

    public void ExitLevel()
    {
        StartCoroutine(LoadLevel(0));
    }

    public void StartBgm(BGMConfig bgmConfig)
    {
        if(bgmCoroutine != null) StopCoroutine(bgmCoroutine);
        bgmCoroutine = StartCoroutine(PlayBgm(bgmConfig));
    }
    
    private IEnumerator PlayBgm(BGMConfig bgmConfig)
    {
        AudioSystem.PlayBGAudio(bgmConfig.Head,false);
        yield return null;
        while (AudioSystem.IsBgmPlaying)
        {
            yield return null;
        }
        AudioSystem.PlayBGAudio(bgmConfig.Body);
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
            if (levelInfo.HaveStory)
            {
                bool isContinue = true;
                DialogManager.Instance.ShowDialog(levelInfo.StoryID, 0, () => isContinue = false);
                while (isContinue)
                {
                    yield return null;
                }
            }
            
            yield return StartCoroutine(SceneTransition.Instance.FadeIn());

            if (!levelInfo.HaveStory)
            {
                currentLevelInfo.StartGame();
            }
            
        }
    }
}