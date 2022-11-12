using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Text scoreCoins;
    [SerializeField] private Text scoreDistance;
    [SerializeField] private int restartingDelay = 1;
    [SerializeField] private GameObject finishPanel;
    [SerializeField] private GameObject endPanel;
    private bool gameHasEnded;

    public void FinishGame()
    {
        if (SceneManager.GetActiveScene().buildIndex == SceneManager.sceneCountInBuildSettings - 1)
        {
            endPanel.SetActive(true);
        }
        else
        {
            finishPanel.SetActive(true);
            Invoke("LoadNextLevel", 2);
            Debug.Log("Game Finished");
        }
    }
    private void LoadNextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void EndGame()
    {
        if (!gameHasEnded)
        {
            gameHasEnded = true;
            Debug.Log("Game Over");
            Invoke("Restart", restartingDelay);
        } 
    }
    private void Restart()
    {
        gameHasEnded = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void ChangeScoreDistance(float distance)
    {
        scoreDistance.text = distance.ToString("0");
    }
    public void ChangeScoreCoins()
    {
        scoreCoins.text = Convert.ToString(int.Parse(scoreCoins.text) + 1);
    }
    public void ExitPressedUI()
    {
        Application.Quit();
    }
}
