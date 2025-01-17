using System;
using System.Collections;
using System.Collections.Generic;
using JKFrame;
using UnityEngine;

public class UI_SkillSelectionWindow : UI_WindowBase
{
    public static UI_SkillSelectionWindow Instance;
    public Transform itemRoot;
    public GameObject itemTemplate;
    private List<UI_SkillSelectionWindow_Item> itemList = new List<UI_SkillSelectionWindow_Item>();
    private Action<SkillConfig> onSelected;
    private void Awake()
    {
        Instance = this;
        gameObject.SetActive(false);
        itemTemplate.gameObject.SetActive(false);
    }
    public void Close()
    {
        gameObject.SetActive(false);
        CleanItems();
    }
    public void Show(Action<SkillConfig> onSelected)
    {
        this.onSelected = onSelected;
        gameObject.SetActive(true);
        CleanItems();
    }

    public void AddItem(SkillConfig skillConfig)
    {
        GameObject itemObj = Instantiate(itemTemplate, itemRoot);
        itemObj.gameObject.SetActive(true);
        UI_SkillSelectionWindow_Item item = itemObj.GetComponent<UI_SkillSelectionWindow_Item>();
        item.Init(skillConfig, OnItemClick);
    }

    private void OnItemClick(SkillConfig config)
    {
        onSelected?.Invoke(config);
        Close();
    }

    private void CleanItems()
    {
        foreach (var item in itemList)
        {
            Destroy(item);
        }
        itemList.Clear();
    }
}
