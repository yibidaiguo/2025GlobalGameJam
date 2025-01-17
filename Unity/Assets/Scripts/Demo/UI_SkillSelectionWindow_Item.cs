using System;
using JKFrame;
using UnityEngine.UI;

public class UI_SkillSelectionWindow_Item : UI_WindowBase
{
    public Button button;
    public Image iconImage;
    public Text nameText;
    public void Init(SkillConfig skillConfig, Action<SkillConfig> onClick)
    {
        button.onClick.AddListener(() => { onClick.Invoke(skillConfig); });
        iconImage.sprite = skillConfig.skillIcon;
        nameText.text = skillConfig.skillName;
    }
}
