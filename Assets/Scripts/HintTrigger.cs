using UnityEngine;
using TMPro;

public class HintTrigger : MonoBehaviour
{
    public TextMeshPro hintText;
    [TextArea]
    public string hintMessage = "You can open an unlock door by right controller.";

    public float displayTime = 3f;

    private void Start()
    {
        if (hintText != null)
            hintText.gameObject.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (hintText != null)
            {
                hintText.gameObject.SetActive(true);
                hintText.text = hintMessage;

                Invoke(nameof(HideHint), displayTime);
            }

            Destroy(gameObject, displayTime); 
        }
    }

    void HideHint()
    {
        if (hintText != null)
            hintText.gameObject.SetActive(false);
    }
}