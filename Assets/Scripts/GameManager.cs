using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    private static int scorePoints;

    public void ScorePoints(int score)
    {
        scorePoints += score;
        scoreText.text = SaveMachine.Instance.playerName + "'s score: " + scorePoints;
    }
}
