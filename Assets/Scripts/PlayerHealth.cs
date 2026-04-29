using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHearts = 3;
    public int currentHearts;

    public GameObject[] hearts;

    public Transform playerToTeleport;
    public Transform loseTeleportLocation;

    private bool isDead = false;

    void Start()
    {
        currentHearts = maxHearts;
        UpdateHeartsUI();
    }

    public void TakeDamage(int damage)
    {
        if (isDead) return;

        currentHearts -= damage;
        currentHearts = Mathf.Clamp(currentHearts, 0, maxHearts);

        UpdateHeartsUI();

        if (currentHearts <= 0)
        {
            Die();
        }
    }

    void UpdateHeartsUI()
    {
        for (int i = 0; i < hearts.Length; i++)
        {
            hearts[i].SetActive(i < currentHearts);
        }
    }

    void Die()
    {
        isDead = true;
        Debug.Log("Player lost all hearts. Teleporting to lose room.");

        if (playerToTeleport != null && loseTeleportLocation != null)
        {
            playerToTeleport.position = loseTeleportLocation.position;
            playerToTeleport.rotation = loseTeleportLocation.rotation;
        }
        else
        {
            Debug.LogWarning("Player To Teleport or Lose Teleport Location is not assigned.");
        }
    }
}