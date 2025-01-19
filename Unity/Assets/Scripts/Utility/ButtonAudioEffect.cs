using JKFrame;
using UnityEngine;
using UnityEngine.UI;

public  class ButtonAudioEffect : MonoBehaviour
{
    void Start()
    {
        GetComponent<Button>().onClick.AddListener(PlayClickButtonSound);
    }
    
    public  void PlayClickButtonSound()
    {
        AudioSystem.PlayOneShot(ResSystem.LoadAsset<AudioClip>("button"));
    }
}
