using JKFrame;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player Instance;
    public SkillConfig currentSkill;
    public RoleConfig roleConfig;
    private void Awake()
    {
        Instance = this;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && !UISystem.GetWindow<UI_DialogWindow>().isActiveAndEnabled)
        {
            Vector2 mousePoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hitInfo = Physics2D.Raycast(mousePoint, Vector2.zero, 10000f);
            if (hitInfo.collider != null)
            {
                NPC npc = hitInfo.collider.GetComponent<NPC>();
                UISystem.Show<UI_DialogWindow>().StartDialog(npc.dialogConfig, npc, this);
            }
        }
    }
}
