using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public Transform playerTransform;
    [SerializeField] private Vector3 secondPosition = new Vector3(16f, 0f, -20f);

    [Header("UI References")]
    public TextMeshProUGUI timerText;
    public TextMeshProUGUI scoreText;

    [Header("Game Settings")]
    public float timeRemaining = 300f; // 5 minutes
    public int totalItemsToEscape = 4;
    private int itemsFound = 0;
    private bool isGameOver = false;
    private bool gameStarted = false;

    void Awake() { Instance = this; }


    // SCENE NAV

    // called from start screen
    public void StartGame()
    {
        // loads the scene
        // SceneManager.LoadScene("EscapeRoom");
        playerTransform.position = secondPosition;
        gameStarted = true;
    }

    // restart the challenge
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void WinGame()
    {
        isGameOver = true;
        gameStarted = false;
        // load win celebration
        playerTransform.position = new Vector3(50f, 0f, -5f);
    }

    public void LoseGame()
    {
        isGameOver = true;
        gameStarted = false;

        playerTransform.position = new Vector3(25f, 0f, 0f);
    }


    // TIMER

    // called every frame
    void Update()
    {
        // update timer as time passes
        if (gameStarted && !isGameOver && timerText != null)
        {
            UpdateTimer();
        }
    }

    void UpdateTimer()
    {
        if (timeRemaining > 0)
        {
            // decrease the timer
            timeRemaining -= Time.deltaTime;
            // update the timer display
            DisplayTime(timeRemaining);
        }
        else
        {
            // player loses
            timeRemaining = 0;
            LoseGame();
        }
    }

    // formats the time display as MM:SS
    void DisplayTime(float timeToDisplay)
    {
        if (timerText == null)
        {
            return;
        }

        float clampedTime = Mathf.Max(0, timeToDisplay);

        // convert time to minutes and seconds format
        float minutes = Mathf.FloorToInt(clampedTime / 60);
        float seconds = Mathf.FloorToInt(clampedTime % 60);
        // 0 for minutes, 1 for seconds, 00 for leading zeros
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }


    // SCOREBOARD

    // called when an item is found
    public void UpdateScore(int amount)
    {
        // when an item is found, update the score and check for win condition
        itemsFound += amount;
        if (scoreText != null)
        {
            scoreText.text = "Progress: " + itemsFound + "/" + totalItemsToEscape;
        }
        
        //if (itemsFound >= totalItemsToEscape)
        //{
        //    WinGame();
        //}
    }

    public void CollectGem(GameObject gem)
    {
        UpdateScore(1);

        Destroy(gem);
    }
}
