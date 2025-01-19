using JKFrame;
using UnityEngine;
using UnityEngine.UI;

public class UI_MainMenu : MonoBehaviour
{
    [SerializeField]private Button StartGameButton;
    [SerializeField]private Button ExitGameButton;

    void Start()
    {
        StartGameButton.onClick.AddListener(GameManager.Instance.StartGame);
        ExitGameButton.onClick.AddListener(GameManager.Instance.ExitGame);
        //AudioSystem.PlayBGAudio(ResSystem.LoadAsset<AudioClip>());
    }
    
}
