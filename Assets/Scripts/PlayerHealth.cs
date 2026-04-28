using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public int maxHearts = 3;
    public int currentHearts;

    public GameObject[] hearts; 

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
        Debug.Log("Player died");
    }
}