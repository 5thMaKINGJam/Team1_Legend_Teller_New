using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public static float moveSpeed = 2f;

    private int score = 0;  // Player's score (total points)
    private int coinCount = 0;  // Number of coins collected
    
    public TMP_Text scoreText;  // UI Text element to display the score
    public TMP_Text coinCountText;  // UI Text element to display the coin count

    public GameObject menuSet;
    public GameObject startPage;

    private void Awake()
    {
        // Setup singleton instance
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        UpdateScoreText();
        menuSet.SetActive(false);

        Time.timeScale = 0f;
        startPage.SetActive(true);
    }

    public void GameStart()
    {
        Debug.Log("GameStart 메서드 호출됨");
        startPage.SetActive(false);
        Time.timeScale = 1f;
    }

    public void ResumeGame()
    {
        Time.timeScale = 1f;
        menuSet.SetActive(false);
    }

    public void PauseGame()
    {
        menuSet.SetActive(true);
        Time.timeScale = 0f;
    }

    void Update()
    {
        if (Input.GetButtonDown("Cancel") && !startPage.activeSelf)
        {
            if (menuSet.activeSelf)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }

    }
    
    
   

    public void AddScore(int value)
    {
        score += value;
        UpdateScoreText();
    }

    public void AddCoin()  // New method to update coin count
    {
        coinCount++;
    }

    private void UpdateScoreText()
    {
        if (scoreText != null)
            scoreText.text = "Score: " + score;
    }

    private void UpdateCoinCountText()
    {
        if (coinCountText != null)
            coinCountText.text = "Total Coins Collected: " + coinCount;  // Show final coin count
    }

    public void GameStop()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }

    public void DecreasePlayerHealth()
    {

    }

}
