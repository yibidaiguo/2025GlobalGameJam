using JKFrame;

public class DialogManager : SingletonMono<DialogManager>
{
    public NPC npc1;

    public DialogConfig GetDialogConfig(string id)
    {
        return ResSystem.LoadAsset<DialogConfig>(id);
    }
    public SkillConfig GetSkillConfig(string id)
    {
        return ResSystem.LoadAsset<SkillConfig>(id);
    }
}


