using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    private static int scorePoints;

    private void Awake()
    {
        ScoreRefresh();
    }

    public void ScorePoints(int score)
    {
        scorePoints += score;
        ScoreRefresh();
    }

    void ScoreRefresh()
    {
        scoreText.text = SaveMachine.Instance.playerName + "'s score: " + scorePoints;
    }
    public void Restart()
    {
        GameReset();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void MainMenu()
    {
        if (scorePoints > SaveMachine.Instance.scorePoints)
        {
            SaveMachine.Instance.scorePoints = scorePoints;
        }
        GameReset();
        SceneManager.LoadScene(0);
    }

    private void GameReset()
    {
        SaveMachine.Instance.level = 1;
        SaveMachine.Instance.shaId = 99;
        scorePoints = 0;
    }
}
