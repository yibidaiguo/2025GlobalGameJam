using Sirenix.OdinInspector;
using UnityEngine;

[CreateAssetMenu(menuName = "Config/SkillConfig")]
public class SkillConfig : SerializedScriptableObject
{
    public Sprite skillIcon;
    public string skillName;
}
