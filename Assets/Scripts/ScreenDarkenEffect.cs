using UnityEngine;
using UnityEngine.UI;

public class ScreenDarkenEffect : MonoBehaviour
{
    public Image darkOverlay;
    public float fadeSpeed = 2f;

    private float targetAlpha = 0f;

    void Update()
    {
        Color c = darkOverlay.color;
        c.a = Mathf.MoveTowards(c.a, targetAlpha, fadeSpeed * Time.deltaTime);
        darkOverlay.color = c;
    }

    public void SetDarkness(float alpha)
    {
        targetAlpha = Mathf.Clamp01(alpha);
    }

    public void FlashDark()
    {
        targetAlpha = 0.75f;
        Invoke(nameof(ClearDarkness), 0.4f);
        Debug.Log("flash dark");
    }

    public void ClearDarkness()
    {
        targetAlpha = 0f;
    }
}