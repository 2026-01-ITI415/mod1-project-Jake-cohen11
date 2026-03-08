using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;
    public int score = 0;
    public TMP_Text scoreText; // Use TMP_Text for TextMeshPro
    public int lives = 3;
    public TMP_Text livesText;
    private void Awake()
    {
        if (instance == null) instance = this;
        else Destroy(gameObject);
    }
    void Start()
    {
        UpdateUI();
    }

    public void AddScore(int points)
    {
        score += points;
        UpdateUI();
    }

    void UpdateUI()
    {
        Debug.Log("Updating score to: " + score);
        if (scoreText != null)
            scoreText.SetText("Score: {0}", score);
        if (livesText != null)
            livesText.SetText("Lives: {0}", lives);
    }

    public void LoseLife()
    {
        lives--;
        if (lives <= 0)
        {
            Debug.Log("Game Over");
            UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);
        }
        UpdateUI();
    }
}