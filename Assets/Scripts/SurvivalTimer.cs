using TMPro;
using UnityEngine;

public class LossTimer : MonoBehaviour
{
    public TMP_Text timerText;

    public float startTime = 420f;

    public Transform player;
    public Transform loseRoomSpawnPoint;

    private float timeLeft;
    private bool gameEnded = false;

    void Start()
    {
        timeLeft = startTime;
        UpdateTimerText(); // initialize display
    }

    void Update()
    {
        if (gameEnded) return;

        timeLeft -= Time.deltaTime;

        if (timeLeft <= 0f)
        {
            timeLeft = 0f;
            EndGame();
        }

        UpdateTimerText();
    }

    void UpdateTimerText()
    {
        int minutes = Mathf.FloorToInt(timeLeft / 60f);
        int seconds = Mathf.FloorToInt(timeLeft % 60f);

        timerText.text = string.Format("{0}:{1:00}", minutes, seconds);
    }

    void EndGame()
    {
        gameEnded = true;

        timerText.text = "0:00";

        player.position = loseRoomSpawnPoint.position;
        player.rotation = loseRoomSpawnPoint.rotation;
    }
}