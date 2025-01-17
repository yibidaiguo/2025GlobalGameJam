using System.Collections;
using UnityEngine;

public class DialogRedScreenEvent : IDialogEvent
{
    public float speed;
    public float stay;
    public void ConverString(string excelString)
    {
        string[] args = excelString.Split(",");
        speed = float.Parse(args[0]);
        stay = float.Parse(args[1]);
    }

    public IEnumerator ExcuteBlocking()
    {
        return null;
    }

    public void Execute()
    {
        DialogManager.Instance.StartCoroutine(DoEffect());
    }

    private IEnumerator DoEffect()
    {
        Camera camera = Camera.main;
        Color originalColor = camera.backgroundColor;
        Color targetColor = Color.red;
        float lerpValue = 0;
        while (lerpValue < 1)
        {
            lerpValue += Time.deltaTime * speed;
            camera.backgroundColor = Color.Lerp(originalColor, targetColor, lerpValue);
            yield return null;
        }
        yield return new WaitForSeconds(stay);
        lerpValue = 0;
        while (lerpValue < 1)
        {
            lerpValue += Time.deltaTime * speed;
            camera.backgroundColor = Color.Lerp(targetColor, originalColor, lerpValue);
            yield return null;
        }
    }
}
