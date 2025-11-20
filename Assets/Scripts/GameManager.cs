using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public int lives = 3;
    public TMP_Text livesText;

    public GameObject startPanel;
    public GameObject gameOverPanel;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        Time.timeScale = 0f;  // Oyun durarak baþlar
        UpdateLivesUI();
    }

    public void StartGame()
    {
        startPanel.SetActive(false);
        Time.timeScale = 1f;
    }

    public void LoseLife()
    {
        lives--;
        UpdateLivesUI();

        if (lives <= 0)
        {
            GameOver();
        }
    }

    private void UpdateLivesUI()
    {
        livesText.text = "Lives: " + lives.ToString();
    }

    private void GameOver()
    {
        Time.timeScale = 0f;
        gameOverPanel.SetActive(true);
    }

    public void RestartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
