using UnityEngine;
using TMPro; // if using TextMeshPro

public class CollectCounter : MonoBehaviour
{
    public int count = 0;
    public TextMeshPro text;

    public void AddOne()
    {
        count++;
        text.text = count.ToString();
    }
}