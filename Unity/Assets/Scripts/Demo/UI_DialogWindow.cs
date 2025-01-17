using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using JKFrame;

public class UI_DialogWindow : UI_WindowBase
{
    [SerializeField]private Image npcImage;
    [SerializeField]private Image playerImage;
    [SerializeField]private Text npcNameText;
    [SerializeField]private Text playerNameText;
    [SerializeField]private Text contentText;

    private DialogConfig dialogConfig;
    private int stepIndex;
    public NPC npc { get; private set; }
    public Player player { get; private set; }

    public bool haveNextStep => stepIndex < dialogConfig.stepList.Count - 1;

    private void Awake()
    {
        gameObject.SetActive(false);
    }
    public void Close()
    {
        gameObject.SetActive(false);
        StopAllCoroutines();
        dialogConfig = null;
        npc = null;
        player = null;
    }
    public void StartDialog(DialogConfig dialogConfig, NPC npc, Player player, int stepIndex = 0)
    {
        gameObject.SetActive(true);
        this.dialogConfig = dialogConfig;
        this.npc = npc;
        this.player = player;
        this.stepIndex = stepIndex;
        StartDialogStep(dialogConfig.stepList[stepIndex]);
    }

    private void StartDialogStep(DialogStepConfig stepConfig)
    {
        StartCoroutine(DoDialogStep(stepConfig));
    }

    private IEnumerator DoDialogStep(DialogStepConfig stepConfig)
    {
        RoleConfig roleConfig = stepConfig.player ? player.roleConfig : npc.roleConfig;
        npcImage.sprite = roleConfig.headIcon;
        npcNameText.text = roleConfig.roleName;
        // 开始事件
        DoStepEventsNonBlock(stepConfig.onStartEventList);
        yield return DoStepEventsBlock(stepConfig.onStartEventList);
        // 出现文字
        yield return DoDialogContentEffect(stepConfig.content);
        // 等待点击
        while (!Input.GetMouseButtonDown(0)) yield return null;
        // 结束事件
        DoStepEventsNonBlock(stepConfig.onEndEventList);
        yield return DoStepEventsBlock(stepConfig.onEndEventList);
        // 下一条/结束
        if (haveNextStep)
        {
            stepIndex += 1;
            StartDialogStep(dialogConfig.stepList[stepIndex]);
        }
        else Close();
    }

    private void DoStepEventsNonBlock(List<IDialogEvent> eventList)
    {
        for (int i = 0; i < eventList.Count; i++)
        {
            eventList[i].Execute();
        }
    }
    private IEnumerator DoStepEventsBlock(List<IDialogEvent> eventList)
    {
        for (int i = 0; i < eventList.Count; i++)
        {
            IEnumerator enumerator = eventList[i].ExcuteBlocking();
            if (enumerator == null) continue;
            yield return enumerator;
        }
    }
    private IEnumerator DoDialogContentEffect(string content)
    {
        string current = "";
        // 替换关键词
        foreach (var item in keywordDic)
        {
            content = content.Replace(item.Key, item.Value);
        }

        foreach (var item in content)
        {
            current += item;
            yield return new WaitForSeconds(0.1f);
            contentText.text = current;
        }
    }

    private Dictionary<string, string> keywordDic = new Dictionary<string, string>();
    public void SetKeyword(string key, string value)
    {
        keywordDic[key] = value;
    }
    public void RemoveKeyword(string key)
    {
        keywordDic.Remove(key);
    }
}
