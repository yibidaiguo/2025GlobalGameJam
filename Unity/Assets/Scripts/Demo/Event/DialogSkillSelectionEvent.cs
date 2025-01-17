using System.Collections;
using JKFrame;

public class DialogSkillSelectionEvent : IDialogEvent
{
    public string[] skillIDs;
    public void ConverString(string excelString)
    {
        skillIDs = excelString.Split(",");
    }
    public IEnumerator ExcuteBlocking()
    {
        UI_SkillSelectionWindow selectionWindow = UI_SkillSelectionWindow.Instance;
        SkillConfig selectedSkillConfig = null;
        selectionWindow.Show((config) =>
        {
            selectedSkillConfig = config;
        });
        for (int i = 0; i < skillIDs.Length; i++)
        {
            SkillConfig skillConfig = DialogManager.Instance.GetSkillConfig(skillIDs[i]);
            selectionWindow.AddItem(skillConfig);
        }
        // 一直等待玩家的选择
        while (selectedSkillConfig == null) yield return null;
        Player.Instance.currentSkill = selectedSkillConfig;
        UISystem.GetWindow<UI_DialogWindow>().SetKeyword("{SkillName}", $"<<{selectedSkillConfig.skillName}>>");
    }

    public void Execute()
    {
    }
}
