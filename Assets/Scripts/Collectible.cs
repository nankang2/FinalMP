using UnityEngine;

public class Collectible : MonoBehaviour
{
    public CollectCounter counter;

    public void Collect()
    {
        if (counter != null)
        {
            counter.AddOne();
        }

        gameObject.SetActive(false);
    }
}