using UnityEngine;

public class DialogTest : MonoBehaviour
{
    public int dialogID;   
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            DialogManager.Instance.ShowDialog(dialogID);
        }
    }
}
