using System;
using JKFrame;
using UnityEngine;

public class DialogManager : SingletonMono<DialogManager>
{
    [SerializeField] private DialogIndexConfig dialogIndexConfig;

    void Start()
    {
        UISystem.AddUIWindowData<UI_DialogWindow>(new UIWindowData(true, nameof(UI_DialogWindow), 1));
    }
    
    public DialogConfig GetDialogConfig(int id)
    {
        dialogIndexConfig.dialogIndex.TryGetValue(id , out DialogConfig config);
        return config;
    }

    public void ShowDialog(int id,int stepIndex = 0,Action onComplete = null)
    {
        UISystem.Show<UI_DialogWindow>().StartDialog(GetDialogConfig(id));
        if (GetDialogConfig(id) == null)
        {
            Debug.Log($"id为{id}的对话配置不存在");
        }
    }
    
    public void ShowDialogAsync(int id)
    {
        UISystem.Show<UI_DialogWindow>().StartDialog(GetDialogConfig(id));
        if (GetDialogConfig(id) == null)
        {
            Debug.Log($"id为{id}的对话配置不存在");
        }
    }
}


